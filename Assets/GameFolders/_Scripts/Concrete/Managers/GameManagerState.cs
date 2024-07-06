using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerState : MonoBehaviour
{
   public static GameManagerState Instance { get; private set; }



void Awake()
{
    Instance = this;
}

public UnityAction onGameStarted=delegate { };
public UnityAction onGamePause=delegate { };
public UnityAction onGameEnd=delegate { };
public UnityAction onGameRestart=delegate { };
public UnityAction onGameResume=delegate { };

public UnityAction<float,float> onGamePassTime;


public UnityAction onGameSpeedUp=delegate { };
public UnityAction onGameSpeedDown=delegate { };
public UnityAction onGameSpeedReset=delegate { };
public UnityAction<bool> onGameSpeedChanged=delegate { };






  








}
