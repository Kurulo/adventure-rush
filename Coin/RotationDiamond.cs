using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDiamond : MonoBehaviour
{
    [SerializeField] 
    private AudioSource _audioSourceForDiamond;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
    
    public void PlayMusic()
    {
        _audioSourceForDiamond.Play();
    }
}
