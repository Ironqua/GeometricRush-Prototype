using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
 [SerializeField] float speed=15f;
 private ObstacleManager obstacleManager;
    public int PrefabIndex { get; set; } 
   void Start()
   {
   //LevelManagers.Instance.OnObstacleSpeed+=LevelManager_OnObstacleDelegateEvent;
   }
    void Update() 
    {
        transform.Translate(Vector3.back*Time.deltaTime*speed);
    }

    public void Initialize(ObstacleManager manager, int prefabIndex)
    {
        obstacleManager = manager;
        PrefabIndex = prefabIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obstacleManager.ReturnObstacleToPool(this.gameObject);
        }
    }
    /*
   void LevelManager_OnObstacleDelegateEvent(float obstacleSpeed)
   {
        speed=obstacleSpeed;
   }

   */
}
