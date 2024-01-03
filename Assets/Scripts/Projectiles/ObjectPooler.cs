using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for pooling objects.
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    [Header("Configuration")]
    public int poolSize = 10;
    public bool willGrow = true;

    [Header("References")]
    public GameObject pooledObject;

    // #### VARIABLES ####
    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    /// <summary>
    /// Returns an inactive pooled object.
    /// </summary>
    /// <returns></returns>
    public GameObject GetPooledObject()
    {
        // loop through pooled objects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if object is inactive, return it
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // if no inactive objects are found, create a new one
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            pooledObjects.Add(obj);
            return obj;
        }   

        return null;
    }
}
