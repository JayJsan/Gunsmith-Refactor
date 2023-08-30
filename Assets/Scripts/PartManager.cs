using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    public static PartManager Instance { get; private set; }
    private GameObject m_currentlyHolding = null;
    private List<GameObject> m_listOfHolders = new List<GameObject>();
    [SerializeField]
    private GameObject holderContainer = null;
    private void Awake() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        DontDestroyOnLoad(gameObject);

        // Set list of holders
    }

    public void SetCurrentlyHolding(GameObject obj)
    {
        m_currentlyHolding = obj;
    }

    public GameObject GetCurrentlyHolding()
    {
        return m_currentlyHolding;
    }
    
    public bool IsHoldingPart()
    {
        return m_currentlyHolding != null;
    }

    public void SetCurrentlyHoldingNull()
    {
        m_currentlyHolding = null;
    }

}
