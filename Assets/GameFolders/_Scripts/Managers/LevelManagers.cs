using System;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    /*
  //EventManager
  public static LevelManagers Instance { get; private set; }
[SerializeField] float elapsedTime;
[SerializeField] public float speed=15f;
[SerializeField] public float obstacleSpeed=5f;


 #region Ground
 public event TestDelegateEvent OnDelegateEvent;
 public delegate void TestDelegateEvent(float groundSpeed);
 #endregion

#region Obstacle
public delegate void DelegateEvent(float _obstacleSpeed);
public event DelegateEvent OnObstacleSpeed;

#endregion

void Awake()
{
    Instance=this;
}

void Update()
{
    elapsedTime+=Time.deltaTime;
    if(elapsedTime>=55)
    {
        speed=speed*1.5f;
        obstacleSpeed=obstacleSpeed*1.5f;
        elapsedTime=0;
        OnDelegateEvent?.Invoke(speed);
        OnObstacleSpeed?.Invoke(obstacleSpeed);
     
    }
}
 
*/


private void Update() {
    
Time.timeScale=2f;
}

}
