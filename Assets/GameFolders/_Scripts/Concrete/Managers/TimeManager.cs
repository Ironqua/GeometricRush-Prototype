using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float elapsedTime;
    float dataValue=1f;
    [SerializeField] float maxSpeedValue=128F;
    [SerializeField] float passedTime;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > passedTime)
        {
            elapsedTime = 0;
            if(dataValue<=maxSpeedValue)
            {
            dataValue+=dataValue;
            CoreGameSignals.Instance.onNextLevelPhase?.Invoke(dataValue);
                
            }
            else
            {
               Debug.Log("max value");
            }
            Debug.Log("data value "+dataValue);
        }
    }
}
