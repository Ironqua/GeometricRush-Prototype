using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
   
    [SerializeField] private float groundSpawnDistance = 50f;

    public static ObjectSpawner instance;

    void Awake()
    {
        instance = this;
    }

    public void SpawnGround()
    {
        ObjectPooler.instance.SpawnForPool(ObjectPooler.instance.pools[0].RoadPrefab, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        
    }
}
