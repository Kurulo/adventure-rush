using System;
using UnityEngine;

public class TrapController : MonoBehaviour {
    public GameObject trapObj;

    private ITrap _iTrap;

    private void Update() {
        if (trapObj && trapObj.GetComponentInChildren<ITrap>() != null) {
            _iTrap = trapObj.GetComponentInChildren<ITrap>();
            Debug.Log("Emergence");
            _iTrap.Emergence();
        } else {
            throw new NullReferenceException("Oppps no ITrap");
        }
    }
}
