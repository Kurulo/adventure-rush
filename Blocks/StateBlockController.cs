using System;
using UnityEngine;

public class StateBlockController : MonoBehaviour {
   private Transform _playerTransform;

   private float _distanceToPlayer;
   [SerializeField] private float _maxDistance;
   private bool _isActive = false;

   private void OnEnable() {
      _isActive = false;
   }

   private void Start() {
      _maxDistance = transform.GetChild(0).localScale.z * 5;
      _playerTransform = FindObjectOfType<PlayerController>().transform;
   }

   private void Update() {
      _distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);

      if (IsClose()) {
         transform.GetChild(1).gameObject.SetActive(true);
         _isActive = true;
      } else if (!IsClose() && !_isActive){
         transform.GetChild(1).gameObject.SetActive(false);
      }
   }
   
   private bool IsClose() {
      if (_distanceToPlayer < _maxDistance) {
         return true;
      }

      return false;
   }
}
