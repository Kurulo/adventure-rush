using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    
    public void OnCanvans()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        _canvas.SetActive(true);    
    }
}
