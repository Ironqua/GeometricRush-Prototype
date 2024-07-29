using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 [SerializeField] private List<float> _laneHolder;
 [SerializeField] private int _playerLane;  
  

    bool _laneSwapStart;
    bool _isJumping;

    [Header("Values")]
   
    [SerializeField] float xMoveSpeed;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float jumpDuration = 0.5f;
    [SerializeField] float zMoveSpeed;

    void Start()
    {
        _playerLane = 1;
    //gameData=new GameData();
    }



    void Update()
    { 
      
        SetInput();
        PlayerMoveZ();
        
        if (_laneSwapStart)
        {
            PlayerMoveX();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            PlayerMoveY();
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
        Vector3 targetPos = new Vector3(_laneHolder[_playerLane], this.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * xMoveSpeed);
        
        float distance = Vector3.Distance(this.transform.position, targetPos);
        if (distance < 0.01f)
        {
            _laneSwapStart = false;
        }
    }

    
void PlayerMoveZ()
{
    
    this.transform.Translate(Vector3.forward*Time.deltaTime*zMoveSpeed);
}
    void PlayerMoveY()
    {
        _isJumping = true;
        float startY = this.transform.position.y;
        Vector3 jumpUp = new Vector3(this.transform.position.x, startY + jumpHeight, this.transform.position.z);
        Vector3 jumpDown = new Vector3(this.transform.position.x, startY, this.transform.position.z);

    
        this.transform.DOMoveY(jumpUp.y, jumpDuration / 2).OnComplete(() => 
        {
            
            this.transform.DOMoveY(jumpDown.y, jumpDuration / 2).OnComplete(() => 
            {
                _isJumping = false;
            });
        });
    }

}
