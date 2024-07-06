using UnityEngine;

public class GameSpeedTimer : MonoBehaviour
{

float elapsedTime=0;
[SerializeField] float nextPhaseTime;

   void Update()
   {
    elapsedTime+=Time.deltaTime;
        //Debug.Log(elapsedTime);
    if(elapsedTime>=nextPhaseTime)
    {
        //playerSpeed=playerSpeed+1f;
        //obstacleSpeed=obstacleSpeed+1f;
        elapsedTime=0;
       // GameManagerState.Instance.onGameSpeedChanged?.Invoke(true);
        GameManagerState.Instance.onGameSpeedUp?.Invoke();
        Debug.Log($"Game Speed Up");
        //GameManagerState.Instance.onGamePassTime?.Invoke(playerSpeed,obstacleSpeed);
    }
   }
}
