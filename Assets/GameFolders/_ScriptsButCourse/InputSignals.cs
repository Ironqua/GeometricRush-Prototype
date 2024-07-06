using UnityEngine;
using UnityEngine.Events;

public class InputSignals : MonoBehaviour
{
 public static  InputSignals Instance { get; set; }


#region  GameState


[SerializeField] bool isChoose;

public  UnityAction OnInputFirstTouch=delegate { };
public UnityAction OnInputTaken=delegate { };
public UnityAction OnInputRelased=delegate { };
public UnityAction OnInputEnable=delegate { };
public UnityAction OnInputDisable=delegate { };


void Start()
{
    if(isChoose==true)
    {
        InputEnable();
    }
    else 
    {
        InputDisable();
    }
}



public void InputEnable()
{
OnInputEnable?.Invoke();
}
public void InputDisable()
{
    OnInputDisable?.Invoke();
}



#endregion





 void Awake()
 {
     Instance = this;
 }


}
