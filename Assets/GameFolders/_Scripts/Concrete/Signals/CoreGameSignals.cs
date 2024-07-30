using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    public static CoreGameSignals Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }



    public UnityAction<byte> onLevelInit = delegate { };
    public UnityAction onLevelFailed = delegate { };
    public UnityAction onLevelRestart = delegate { };



    #region Next Level
    public UnityAction<float> onNextLevelPhase = delegate { };
    public UnityAction onRestartLevelPhase = delegate { };
    #endregion
}
