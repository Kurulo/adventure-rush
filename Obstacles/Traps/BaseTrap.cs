using System;
using UnityEngine;

public abstract class BaseTrap : MonoBehaviour, ITrap {
    private Transform _transform;
    private bool _canEmerg = false;

    private void Start() {
        if (GetComponent<Transform>()) {
            _transform = GetComponent<Transform>();
        }
    }

    public Transform GetTransform() {
        return _transform;
    }
    
    public void SetCanEmerg(bool can) {
        _canEmerg = can;
    }
    
    // Виникаючий
    public virtual void Emergencing() {
        
    }
    
    public void Emergence() {
        Emergencing();
    }
}
