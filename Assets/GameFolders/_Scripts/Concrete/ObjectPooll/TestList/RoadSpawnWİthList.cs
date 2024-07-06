using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawnWİthList : MonoBehaviour
{
    [SerializeField] public List<GameObject> roadList;
    public float offset=50;


void Start()
{
    if(roadList!=null&&roadList.Count>0)
    {
        roadList=roadList.OrderBy(r=>r.transform.position.z).ToList();
    }
}


public void MoveRoad()
{
    GameObject moveRoad=roadList[0];
    roadList.Remove(moveRoad);
    float newZ=roadList[roadList.Count-1].transform.position.z+offset;
    moveRoad.transform.position=new Vector3(0,0,newZ);
    roadList.Add(moveRoad);
}
}
