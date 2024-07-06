using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   RoadSpawnWİthList roadSpawnWİthList;
   void Start()
   {
    roadSpawnWİthList=GetComponent<RoadSpawnWİthList>();
   }

   public void SpawnTriggerEnter()
   {
    
        roadSpawnWİthList.MoveRoad();
   }
}
