using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] private int poolSize = 2; 
   
    [SerializeField] private float obstacleLifeTime = 10f; 
    [SerializeField] Vector3 spawnpOS;
    [SerializeField] Transform playerTransform;
     [SerializeField] float playerSpawnDistance;

    private List<Queue<GameObject>> obstaclePools; 

    private float nextSpawnTime = 0f;
    private float spawnInterval = 1;

    void Start()
    {
        obstaclePools = new List<Queue<GameObject>>();
        InitializePools();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            
                SpawnRandomObstacle();
                nextSpawnTime = Time.time + spawnInterval;
                   
        }
    }

    private void InitializePools()
    {
        for (int i = 0; i < obstaclePrefabs.Count; i++)
        {
            Queue<GameObject> newPool = new Queue<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject newObj = Instantiate(obstaclePrefabs[i]);
                newObj.SetActive(false);
                newObj.AddComponent<ObstacleMover>().Initialize(this, i);
                newPool.Enqueue(newObj);
            }
            obstaclePools.Add(newPool);
        }
    }

    private void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePools.Count);
        if (obstaclePools[randomIndex].Count > 0)
        {
            GameObject obstacle = obstaclePools[randomIndex].Dequeue();
            Vector3 pos=new Vector3(0,0,playerTransform.position.z+playerSpawnDistance);
            obstacle.transform.position = new Vector3(spawnpOS.x,spawnpOS.y,pos.z); 
            obstacle.SetActive(true);
            StartCoroutine(DisableAfterTime(obstacle, obstacleLifeTime));
        }
    }

    private IEnumerator DisableAfterTime(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObstacleToPool(obstacle);
    }

    public void ReturnObstacleToPool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        int prefabIndex = obstacle.GetComponent<ObstacleMover>().PrefabIndex; 
        obstaclePools[prefabIndex].Enqueue(obstacle); 
    }
}
