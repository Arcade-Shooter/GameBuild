using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManagement : MonoBehaviour
{
    public static ObjectPoolManagement Instance { get; private set; }

    private Dictionary<GameObject, List<GameObject>> objectPools = new Dictionary<GameObject, List<GameObject>>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void CreatePool(GameObject objectToPool, int initialPoolSize)
    {
        List<GameObject> newObjectPool = new List<GameObject>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject newObj = Instantiate(objectToPool);
            newObj.SetActive(false);
            newObjectPool.Add(newObj);
        }
        objectPools[objectToPool] = newObjectPool;
    }


    // Method to get an object from the pool
    public GameObject GetPooledObject(GameObject objectToPool)
    {
        if (objectPools.ContainsKey(objectToPool))
        {
            List<GameObject> pool = objectPools[objectToPool];
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }
            //all objects in the pool are in use, so add a new one
            GameObject newObj = Instantiate(objectToPool);
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }
        else
        {
            //there is no pool for the requested object
            Debug.LogError("No pool exists for " + objectToPool.name);
            return null;
        }
    }


}
