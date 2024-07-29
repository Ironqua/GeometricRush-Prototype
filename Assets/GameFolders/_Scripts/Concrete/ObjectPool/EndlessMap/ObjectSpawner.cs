using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float groundSpawnDistance;
    [SerializeField] public Transform playerTransform;
    public int level_index = 1;
    public ObjectPooler objectPooler;

   

    private void OnLevelRestart()
    {
        level_index = 1;
    }
    
    private float anotherPosition = 0;
    public void SpawnGround()
    {
        anotherPosition += groundSpawnDistance;
        Vector3 spawnPosition = new Vector3(0, 0, playerTransform.position.z+groundSpawnDistance);
        objectPooler.SpawnFromPool("Ground" + level_index, spawnPosition, Quaternion.identity);

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
