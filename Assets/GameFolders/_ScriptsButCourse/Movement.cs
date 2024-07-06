using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] float _movementSpeed;




    void Update()
    {
       Vector2 mouseDelta = _inputManager.deltaPos; // Fare hareketini al

            // Fare hareketiyle nesneyi hareket ettir
            Vector3 movement = new Vector3(mouseDelta.x, 0f, mouseDelta.y) * _movementSpeed * Time.deltaTime;
            transform.Translate(movement);
    }
}
