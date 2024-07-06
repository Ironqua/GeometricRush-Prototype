using System.Collections;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{


void OnTriggerEnter(Collider other)
{
    if(other.gameObject.CompareTag("Player"))
    {
         ObjectSpawner.instance.SpawnGround();
        //  this.gameObject.SetActive(false);
         //Test.instance.SpawnRandomChunk();
    }
}




}
