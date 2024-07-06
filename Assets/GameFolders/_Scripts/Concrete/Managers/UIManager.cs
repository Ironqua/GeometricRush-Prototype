using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
[SerializeField] GameObject endPanel;



void OnEnable()
{
    Subscribe();    
}


void OnDisable()
{
    UnSubscribe();
}




void Subscribe()
{
GameManagerState.Instance.onGameEnd+=OnGameEnd;
}

void UnSubscribe()
{
    GameManagerState.Instance.onGameEnd-=OnGameEnd;
}





void OnGameEnd()
{

    endPanel.SetActive(true);
}






}
