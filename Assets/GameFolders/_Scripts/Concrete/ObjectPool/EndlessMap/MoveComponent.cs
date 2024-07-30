using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    private ObjectSpawner objectSpawner;

    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player trigger entered");
            objectSpawner?.SpawnGround();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
