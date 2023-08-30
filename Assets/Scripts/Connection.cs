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
    }

    [field: SerializeField]
    public Type ConnectionType {get; private set; } = Type.None;
    [field: SerializeField]
    public List<Part> CompatibleParts {get; private set; } = new List<Part>();
    [field: SerializeField]
    private bool isConnected = false;

    private Connection connectedTo = null;

    public void Connect(Connection externalConnection) {
        connectedTo = externalConnection;
        isConnected = true;
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
    }
}
