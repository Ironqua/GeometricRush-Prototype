using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float groundSpawnDistance = 50f;
    public Transform playerTransform;
    public int level_index = 1;
    public ObjectPooler objectSpawner ;

    void Start()
    {
        CoreGameSignals.Instance.onLevelRestart += OnLevelRestart;
        //playerTransform = FindAnyObjectByType<CarMovementController>().transform;
    }

    private void OnLevelRestart()
    {
        level_index = 2;
    }
    
  public void SpawnGround()
{
    Vector3 spawnPosition = new Vector3(0, 0, playerTransform.position.z + groundSpawnDistance);
    GameObject spawnedGround = objectSpawner.SpawnFromPool("Ground" + level_index, spawnPosition, Quaternion.identity);

    if (spawnedGround == null)
    {
        level_index = (level_index % 5) + 1; 
        SpawnGround(); 
        return; 

    }

    if (level_index != 5)
    {
        level_index++;
    }
    else
    {
        level_index = 1;
    }
}


}
