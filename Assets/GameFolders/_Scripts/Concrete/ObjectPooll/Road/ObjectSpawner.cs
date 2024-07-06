using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
   [Header("Values")]
    [SerializeField] private float groundSpawnDistance = 50f;

[SerializeField] Transform playerTransform;

    public static ObjectSpawner instance;

    void Awake()
    {
        instance = this;
    }
    

    public void SpawnGround()
    {
        Vector3 spawnPosition = new Vector3(0, 0, playerTransform.position.z + groundSpawnDistance);
       // ObjectPooler.instance.SpawnForPool(ObjectPooler.instance.pools[0].RoadPrefab, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        ObjectPooler.Instance.SpawnFromPool("Road1", spawnPosition, Quaternion.identity);
        


    }
}
