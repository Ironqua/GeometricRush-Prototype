using System.Collections;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    Transform playerTransform;
    void Start()
    {
        playerTransform=FindObjectOfType<PlayerController>().transform;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ObjectSpawner objectS = FindObjectOfType<ObjectSpawner>();
            if (objectS != null)
            {
                objectS.SpawnGround();
                // Zemini geçtikten sonra pasif hale getirme
                //if(playerTransform.transform.position.z<this.gameObject.transform.position.z)
                Debug.Log($"Player spawned");
            }
        }
    }

   
}
