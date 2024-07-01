using System;
using UnityEngine;

public class ObstaclDetector : MonoBehaviour {
    public GameObject TrapController;
    
    private TrapController _trapController;

    private void Start() {
        if (TrapController.GetComponent<TrapController>()) {
            _trapController = TrapController.GetComponent<TrapController>();
        } else {
            throw new NullReferenceException("No TrapController");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerController>()) {
            Debug.Log("Detect");
            _trapController.trapObj = gameObject;
        }
    }
}
