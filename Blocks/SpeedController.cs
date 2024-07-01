using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {
    public float _speed = -9f;

    private float _curentSpeed;
    private float _maxSpeed;

    private bool _canMove = true;
    public bool CanMove
    {
        get { return _canMove;}
        set { _canMove = value; }
    }
    
    public void StartSpeed() {
         _curentSpeed = _speed;
         CanMove = true;
    }
    
    public void AddSpeed() {
        if (_canMove)
        {
            _curentSpeed += -0.05f;
        }
    }
    
    public float GetSpeed() {
        if (!_canMove)
        {
            return 0f;
        }
        else
        {
            return _curentSpeed;
        }
    }
}
