using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
    public GameObject player;
    
    private PlayerController _playerController;
    private PlayerAnimationController _playerAnimation;
    
    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private float _deadZone = 50f;

    private bool _isSwiping;
    private bool _isMobile;

    private void Start() {
        if (player.GetComponent<PlayerController>()) {
            _playerController = player.GetComponent<PlayerController>();
        }

        _playerAnimation = player.GetComponent<PlayerAnimationController>();
        _isMobile = Application.isMobilePlatform;
    }

    private void Update() {
        if (!_isMobile) {
            if (Input.GetMouseButtonDown(0)) {
                _isSwiping = true;
                _tapPosition = Input.mousePosition;
            } else if (Input.GetMouseButtonUp(0)) {
                ResetSwipe();
            }
        } else {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                _isSwiping = true;
                _tapPosition = Input.GetTouch(0).position;
            } else if (Input.GetTouch(0).phase == TouchPhase.Canceled || 
                       Input.GetTouch(0).phase == TouchPhase.Ended) {
                ResetSwipe();
            }
        }
        
        CheckSwipe();
        // if (Input.GetKeyDown(KeyCode.A)) {
        //     _playerController.SetCanMoveLeft(true);
        // }
        // if (Input.GetKeyDown(KeyCode.D)) {  
        //     _playerController.SetCanMoveRight(true);
        // }
        // if (Input.GetKeyDown(KeyCode.W)) {
        //     _playerController.Jumping();
        // }
        // if (Input.GetKeyDown(KeyCode.S)) {
        //     _playerController.SetCanMoveBottom(true);
        // }
    }
    
    private void CheckSwipe() {
        _swipeDelta = Vector2.zero;
        
        if (_isSwiping) {
            if (!_isMobile && Input.GetMouseButton(0)) {
                _swipeDelta = (Vector2) Input.mousePosition - _tapPosition;
            } else if (Input.touchCount > 0) {
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
            }
        }
        
        if (_swipeDelta.magnitude > _deadZone) {
             if (Math.Abs(_swipeDelta.x) > Math.Abs(_swipeDelta.y)) {
                 if (_swipeDelta.x > 0) 
                 {
                     _playerController.SetCanMoveRight(true);
                     if (_playerController.Grounded)
                        _playerAnimation.SetTriggerJogRight();
                 } 
                 else 
                 {
                     _playerController.SetCanMoveLeft(true);
                     if (_playerController.Grounded)
                        _playerAnimation.SetTriggerJogLeft();
                 }
             } else 
             {
                 if (_swipeDelta.y > 0) 
                 {
                     _playerController.Jumping();
                     _playerAnimation.PlayTriggerJump();
                 } else 
                 {
                     _playerController.SetCanMoveBottom(true);
                     if (_playerController.Grounded)
                     {
                         _playerAnimation.SetTriggerRoll();
                         _playerAnimation.ResetTriggersJog();
                     }
                 }
             }
             
             ResetSwipe(); 
        }
    }
    
    private void ResetSwipe() {
        _isSwiping = false;
        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
