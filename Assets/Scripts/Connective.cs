using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using UnityEditor.Search;

public class Connective : MonoBehaviour
{
    private Draggable m_draggable;
    private Connection m_partInputConnection = null;
    private Connection m_partOutputConnection = null;

    private Connection m_externalInputConnection = null;
    private Connection m_externalOutputConnection = null;
    private bool m_hasConnected = false;
    
    [field: SerializeField]
    public Connection.Part PartType {get; private set; }= Connection.Part.None;

    [SerializeField]
    private float connectionRange = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        m_draggable = GetComponent<Draggable>();
    }

    void Start() {
        GetConnectionsFromChildren();
    }

    // Update is called once per frame
    void Update()
    {
        // We connect to the closest once we are no longer dragging.

        // We only look for connections if we are being dragged
        if (!m_draggable.isDragging) {
            return;
        }
        LookForConnections();
    }

    private void ConnectConnections() {
        // If hasConnected is true, we return.
        if (m_hasConnected) {
            return;
        }
        // Otherwise, we connect our part output connection to the external input connection
        // If one is null, we do not connect.
        if (m_partOutputConnection == null || m_externalInputConnection == null) {
            return;
        }


        // Afterwards, we set hasConnected to true.
        m_hasConnected = true;
    }

    private void LookForConnections() {

        if (m_partInputConnection == null && m_partOutputConnection == null) {
            Debug.Log("No connections found on " + gameObject.name);
            return;
        }

        bool connectionMade = false;
        float closestConnection = 99999f;
        // At this point, this part is currently being dragged and we have at least one output connection.
        // We need to check if we are near another part's input connection.
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, connectionRange).ToList();
        Debug.DrawLine(transform.position, transform.position + new Vector3(connectionRange, 0, 0), Color.red, 0.1f);
        Debug.DrawLine(transform.position, transform.position + new Vector3(-connectionRange, 0, 0), Color.red, 0.1f);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, connectionRange, 0), Color.red, 0.1f);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -connectionRange, 0), Color.red, 0.1f);
        foreach (Collider2D collider in colliders) {
            if (collider.TryGetComponent<Connection>(out Connection c)) {
                // Here we check what type of connection and also need to check if it is the right part type.
                // If the connection found is this parts connection, we ignore it.
                if (c == m_partInputConnection || c == m_partOutputConnection) {
                    Debug.Log("Connection is this parts connection");
                    continue;
                }

                // If it isn't an input type we can ignore it.
                if (c.ConnectionType != Connection.Type.Input) {
                    Debug.Log("Connection is not input type");
                    continue;
                }
                // If this connection isn't compatible with this part, we can ignore it.
                if (!c.CompatibleParts.Contains(PartType)) {
                    Debug.Log("Connection " + c.gameObject.name + " is not compatible with part type" + this.PartType.ToString());
                    continue;
                }
                // If we are here, we have a compatible input connection and are in range.
                // We check if this connection is the closest to us.
                float distance = Vector2.Distance(c.transform.position, transform.position);
                // If so, we assign the reference to it.
                if (distance < closestConnection) {
                    connectionMade = true;
                    closestConnection = distance;
                    m_externalInputConnection = c;
                }
            }
        }

        // Drawline towards closest connection
        if (m_externalInputConnection != null) {
            Debug.DrawLine(transform.position, m_externalInputConnection.transform.position, Color.green, 0.1f);
        }

        // If we have checked all the connections and found none that are compatible or are not in range
        // We set our reference to null and hasConnected to false.
        if (!connectionMade) {
            m_hasConnected = false;
            m_externalInputConnection = null;
        }
    }

    private void GetConnectionsFromChildren() {
        List<Connection> connections = GetComponentsInChildren<Connection>().ToList();
        if (connections.Count > 0) {
            foreach (Connection c in connections) {
                switch (c.ConnectionType) {
                    case Connection.Type.Input:
                        m_partInputConnection = c;
                        break;
                    case Connection.Type.Output:
                        m_partOutputConnection = c;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
