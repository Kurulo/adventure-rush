using System;
using UnityEngine;

public abstract class BoosterBehaviour : MonoBehaviour, IBooster
{
    [SerializeField] private float _timeWork = 8f;
    public float TimeWork { get { return _timeWork;} }
                                                                
    private bool _isBoosterActive = false;
    private float _leftTime;

    private void Update() 
    {
        if (_isBoosterActive)
        {
            LeftTimeChecker();
            ActionBooster();
        }    
    }

    public virtual void StartBooster() 
    {
        _isBoosterActive = true;
        _leftTime = TimeWork;
    }

    public virtual void ActionBooster() 
    {
        
    }

    public virtual void EndBooster() 
    {
        _isBoosterActive = false;
        _leftTime = TimeWork;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            StartBooster(); 
        }
    }

    private void LeftTimeChecker() 
    {
        if (_leftTime < 0)
        {
            EndBooster();
        }
        else
        {
            if (!_isBoosterActive)
            {
                _isBoosterActive = true;
            }

            _leftTime -= Time.deltaTime;
        }
    }
}
