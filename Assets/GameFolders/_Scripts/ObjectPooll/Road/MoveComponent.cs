using UnityEngine;

public class MoveComponent : MonoBehaviour
{
   // EventSub
[SerializeField] public float speed=15f;

void Start()
{
  //  LevelManagers.Instance.OnDelegateEvent+=LevelManagers_OnDelegateEvent;
}

void Update()
{
    Movement(speed);
   
    
}

void Movement(float initialSpeed)
{
    transform.Translate(Vector3.back*Time.deltaTime*initialSpeed);
}
/*
void LevelManagers_OnDelegateEvent(float newSpeed)
{
    speed=newSpeed;
}
*/


void OnTriggerEnter(Collider other)
{
    if(other.gameObject.CompareTag("Player"))
    {
          ObjectSpawner.instance.SpawnGround();
          //this.gameObject.SetActive(false);
    }
}



}
