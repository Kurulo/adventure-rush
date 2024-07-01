using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnDiamond : MonoBehaviour
{

    [SerializeField] private GameObject Diamond;
    [SerializeField] private GameObject Coin;

    private int rnd;
    
    private void OnEnable()
    {
        GetRandomSpawn();
    }

    public void GetRandomSpawn()
    {
        rnd = Random.Range(1, 100);
        if (rnd >= 75)
        {
            Diamond.SetActive(true);
            Coin.SetActive(false);
        }
        if(rnd <= 74)
        {
            Coin.SetActive(true);
            Diamond.SetActive(false);
        }
    }
}
