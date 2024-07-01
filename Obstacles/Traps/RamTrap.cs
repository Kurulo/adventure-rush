using System;
using UnityEngine;

public class RamTrap : BaseTrap {
    public float speed;
    public Transform _connectBlockT;
    
    private void Update() {
        if (GetTransform().position.x < -10) {
            GetTransform().position = new Vector3(25f, GetTransform().position.y, GetTransform().position.z);
        }
        GetTransform().Translate(speed * Time.deltaTime, 0f, 0f);
    }
}
