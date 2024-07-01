using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedDodge = 15f;
    
    public float distToGround;
    public LayerMask groundMask;
    
    private Transform _transform;
    private CapsuleCollider _capsuleCollider;
    private Rigidbody _rb;

    private PlayerAnimationController _playerAnimation;

    private float[] _posMoving = new float[] {-4f, 0f, 4f};
    [SerializeField] private int _currentPos = 1;
    
    private bool _canMoveLeft = false;
    private bool _canMoveRight = false;
    private bool _canMoveBottom = false;
    private bool _grounded;
    
    public bool Grounded
    {
        get { return _grounded; }
    }

    private bool _doubleJumpBonus = false;
    private int _jumpAmount = 0;

    public void SetCanMoveLeft(bool can) => _canMoveLeft = can;
    public void SetCanMoveRight(bool can) => _canMoveRight = can;
    public void SetCanMoveBottom(bool can) => _canMoveBottom = can; 
    public void SetCanDoubleJump(bool can) => _doubleJumpBonus = can; 

    private void Start() {
        if (GetComponent<Transform>()) {
            _transform = GetComponent<Transform>();
        }
        if (GetComponent<Rigidbody>()) {
            _rb = GetComponent<Rigidbody>();
        }
        if (GetComponent<PlayerAnimationController>())
        {
            _playerAnimation = GetComponent<PlayerAnimationController>();
        }

        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update() {
        CheckGround();
        _playerAnimation.SetBoolGround(_grounded);
        
        if (_canMoveLeft) {
            MovingLeft();
        }
        
        if (_canMoveRight) {
            MovingRight();
        }
        
        if (_canMoveBottom) {
            MoveBottom();
        }
    }

    public void MovingLeft() {
        float currentXPos = _transform.position.x;
        
        _transform.Translate(-speedDodge * Time.deltaTime, 0f, 0f);
        
        if (Mathf.Round(currentXPos) <= _posMoving[_currentPos] && _currentPos != 0) {
            if (currentXPos < _posMoving[_currentPos - 1]) {
                _transform.position = new Vector3(Mathf.Round(_transform.position.x), _transform.position.y, 
                    _transform.position.z);
                
                _currentPos--;
                _canMoveLeft = false;
            }
        } else {
            _transform.position = new Vector3(Mathf.Round(_transform.position.x), _transform.position.y, 
                _transform.position.z);
            
            _canMoveLeft = false;
        }
    }
    
    public void MovingRight() {
        float currentXPos = _transform.position.x;
        
        _transform.Translate(+speedDodge * Time.deltaTime, 0f, 0f);
        
        if (Mathf.Round(currentXPos) >= _posMoving[_currentPos] && _currentPos != 2) {
            if (currentXPos >= _posMoving[_currentPos + 1]) {
                _transform.position = new Vector3(Mathf.Round(_transform.position.x), _transform.position.y, 
                    _transform.position.z);
                
                _currentPos++;
                _canMoveRight = false;
            }
        } else {
            _transform.position = new Vector3(Mathf.Round(_transform.position.x), 
                _transform.position.y, _transform.position.z);
            
            _canMoveRight = false;
        }
    }
    
    public void Jumping() {
        if (_grounded)
        {
            _jumpAmount = 0;
            _rb.AddForce(_transform.up * 9f, ForceMode.Impulse);
        }
        else if (!_grounded && _doubleJumpBonus)
        {
            Debug.Log("Double jump");
            DoubleJump();
        } 
    }
    
    public void StartRoll()
    {
        Vector3 _newVector3 = _capsuleCollider.center;
        _newVector3.y /= 2;
        _capsuleCollider.height /= 2;
        _capsuleCollider.center = _newVector3;
    }
    
    public void EndRoll()
    {
        Vector3 _newVector3 = _capsuleCollider.center;
        _newVector3.y *= 2;
        _capsuleCollider.height *= 2;
        _capsuleCollider.center = _newVector3;
    }
    
    public void DoubleJump()
    {
        if (_jumpAmount != 1) 
        {
            _rb.AddForce(_transform.up * 9f, ForceMode.Impulse);
            _jumpAmount++; 
        }
    }
    
    public void MoveBottom() {
        if (!_grounded) {
            _rb.AddForce(_transform.up * -1f, ForceMode.Impulse);
        } else {
            _canMoveBottom = false;
        }
    }
    
    private void CheckGround() {
        _grounded = Physics.Raycast(_transform.position, Vector3.down, distToGround, groundMask);
    }
    
}
