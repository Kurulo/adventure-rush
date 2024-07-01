using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    [SerializeField] 
    private AudioSource _audioSource;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime); 
    }

    public void PlayMusic()
    {
        _audioSource.Play();
    }
}
