using System;
using UnityEngine;

public class DoublePointsBooster : BoosterBehaviour
{
    [Header("Affects on")]
    [SerializeField] private ScoreManager _scoreManager;

    private int _bonusAmount = 2;
    
    public override void StartBooster() 
    {
        base.StartBooster();
        Debug.Log("Boster start !!!!!");
    }

    public override void ActionBooster()
    {
        base.ActionBooster();
        _scoreManager.AddScore(_bonusAmount);
    }

    public override void EndBooster()
    {
        base.EndBooster();
        Debug.Log("Booster end !!!");
    }
}
