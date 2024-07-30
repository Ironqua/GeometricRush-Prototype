using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Data 

    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab; 
        public int size; 
    }

    #endregion

    //#region Instance
    //public static ObjectPooler Instance;

    //void Awake()
    //{
    //    if(Instance == null) 
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    //#endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                objectsStart.Add(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
            
        }
        CoreGameSignals.Instance.onLevelRestart += OnLevelRestart;
        // ObjectSpawner.instance.SpawnGround();
    }
    List<GameObject> objects = new List<GameObject>();
    List<GameObject> objectsStart = new List<GameObject>();

    private void OnLevelRestart()
    {
        while(objectsStart.Count > 0)
        {
            Destroy(objectsStart[objectsStart.Count - 1]);
            objectsStart.Remove(objectsStart[objectsStart.Count - 1]);
        }
    }


   public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
{
    if (!poolDictionary.ContainsKey(tag))
    {
         return null;
    }

    GameObject objectToSpawn = poolDictionary[tag].Dequeue();
    objects.Add(objectToSpawn);
    objectToSpawn.transform.position = position;
    objectToSpawn.transform.rotation = rotation;
    objectToSpawn.SetActive(true);
    poolDictionary[tag].Enqueue(objectToSpawn);

    return objectToSpawn;
}


}
