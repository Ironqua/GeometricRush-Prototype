using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    


    [SerializeField] float forwardSpeed;
    [SerializeField] float xMoveSpeed;
    [SerializeField] private List<float> _laneHolder;
    [SerializeField] private int _playerLane;  
    Rigidbody _playerRb;

  
    
    bool _laneSwapStart;

void Awake()
{
   _playerRb=GetComponent<Rigidbody>();
}
void Start()
{
   
    _playerLane=1;
}

void Update()
{ 
SetInput();
PlayerMoveZ();
if(_laneSwapStart)
{
    PlayerMoveX();

}

}

private void SetInput()
{
    if (Input.GetKeyDown(KeyCode.A))
    {
        if (_playerLane > 0)
        {
            _playerLane--; 
            _laneSwapStart = true;
   
        

            
           }
         
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
        if (_playerLane < 2)
        {
            _playerLane++;
            
            _laneSwapStart = true;
            
         
        }
      
    }
}


void PlayerMoveX()
{
    Vector3 targetPos=new Vector3(_laneHolder[_playerLane],this.transform.position.y,this.transform.position.z);
    this.transform.position=Vector3.Lerp(this.transform.position,targetPos,Time.deltaTime*xMoveSpeed);
    
  
  
    
    float distance = Vector3.Distance(this.transform.position, targetPos);

        if (distance < 0.01f)
        {
            _laneSwapStart = false;
        }


}

void PlayerMoveZ()
{
    Vector3 forwardMove=Vector3.forward*Time.deltaTime*forwardSpeed;
    this.transform.Translate(forwardMove); 

    
}

void OnCollisionEnter(Collision other)
{
    if(other.gameObject.CompareTag("Obstacle"))
    {
        GameManager.Instance.LoadPanel();
    }
}


}

        
     

        



      
    


