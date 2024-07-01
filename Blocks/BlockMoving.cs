using UnityEngine;

public class BlockMoving : MonoBehaviour {
    public GameObject SpeedContainer;

    private Transform _transform;

    private SpeedController _speedController;

    private bool _canMove = false;

    void Start() {
        if (GetComponent<Transform>()) {
            _transform = GetComponent<Transform>();
        }
        if (SpeedContainer.GetComponent<SpeedController>()) {
            _speedController = SpeedContainer.GetComponent<SpeedController>();
            _speedController.StartSpeed();
        }
    }
    
    void Update() {
        Debug.Log(_speedController.GetSpeed().ToString());
        _transform.Translate(0f, 0f, _speedController.GetSpeed() * Time.deltaTime);
    }
    
    public void SetCanMove(bool can) {
        _canMove = can;
    }
}    
    
