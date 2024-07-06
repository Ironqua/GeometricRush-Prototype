using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    

bool _firstTimeTouch;
bool _isAvailableTouch;
bool _isTouching;


Vector2 mousePos;
public Vector2 deltaPos;
public Vector2 _moveVector2;



void Update()
{
    if(!_isAvailableTouch) return;
    if(Input.GetMouseButtonDown(0))
    {
        InputSignals.Instance.OnInputTaken?.Invoke();
        if(_firstTimeTouch==true)
        {
        InputSignals.Instance.OnInputFirstTouch?.Invoke();
            Debug.Log($"First touch");
            _firstTimeTouch=false;
        }
        _isTouching=true;
    }

    else if(Input.GetMouseButtonUp(0))
    {
        InputSignals.Instance.OnInputRelased?.Invoke();
        Debug.Log($"Relased");
        _isTouching=false;
        _firstTimeTouch=true;
    }

    if(_isTouching==true)
    {
         deltaPos=(Vector2) Input.mousePosition-mousePos;
         
         
         Debug.Log($"deltaPos: {deltaPos}");

    }
}



void OnEnable()
{
    SubscribeEvents();
}

void OnDisable()
{
    UnSubscribeEvents();
}






    void SubscribeEvents()
    {
        
        InputSignals.Instance.OnInputEnable+=OnInputEnable;
        InputSignals.Instance.OnInputDisable+=OnInputDisable;
    }

    private void OnInputDisable()
    {
        _isAvailableTouch=false;
    }

    private void OnInputEnable()
    {
        _isAvailableTouch=true;
    }

 

    void UnSubscribeEvents()
    {   
        
        InputSignals.Instance.OnInputEnable-=OnInputEnable;
        InputSignals.Instance.OnInputDisable-=OnInputDisable;
    }




}
