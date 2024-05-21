using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Data 

    [System.Serializable]
    public class Pool
    {
        public GameObject RoadPrefab;
        public int PoolSize;
    }

    #endregion

    #region Instance
    public static ObjectPooler instance;

    void Awake()
    {
        instance=this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
    GameObject ObjectToSpawn;

    void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.PoolSize; i++)
            {
                GameObject obj = Instantiate(pool.RoadPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.RoadPrefab, objectPool);
        }
    }

    public GameObject SpawnForPool(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        ObjectToSpawn = poolDictionary[prefab].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = pos;
        ObjectToSpawn.transform.rotation = rot;

        poolDictionary[prefab].Enqueue(ObjectToSpawn);

        return ObjectToSpawn;
    }  
}
