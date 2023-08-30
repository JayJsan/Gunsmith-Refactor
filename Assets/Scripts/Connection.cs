using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public enum Type
    {
        None,
        Input,
        Output
    }
    public enum Part {
        None,
        Barrel,
        Body,
        Stock,
        Magazine,
        Sight,
        Grip,
        Trigger,
        Holder, // This isn't really a part type but holds the part when the players weapon is empty and no parts are connected.
    }
    [field: SerializeField]
    [field: Tooltip("If the connection type is output, compatible parts are irrelevant.")]
    public Type ConnectionType {get; private set; } = Type.None;

    [field: SerializeField]
    public List<Part> CompatibleParts {get; private set; } = new List<Part>();
    [field: SerializeField]
    private bool isConnected = false;
    [field: SerializeField]
    private bool isHolder = false;

    private Connection connectedTo = null;

    public void Connect(Connection externalConnection) {
        connectedTo = externalConnection;
        isConnected = true;
        if (isHolder) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public Connection CheckConnected() {
        return connectedTo;
    }

    public bool IsConnected() {
        return isConnected;
    }

    public void Disconnect() {
        connectedTo = null;
        isConnected = false;
        if (isHolder) {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
