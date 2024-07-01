using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpBooster : BoosterBehaviour
{
    // [Header("Affects on")]
    private PlayerController _playerController;

    public override void StartBooster() 
    {
        base.StartBooster();
        Debug.Log("Boster start !!!!!");
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.SetCanDoubleJump(true);
    }

    public override void ActionBooster()
    {
        base.ActionBooster();
    }

    public override void EndBooster()
    {
        base.EndBooster();
        Debug.Log("Booster end !!!");
        _playerController.SetCanDoubleJump(false);
    }
}
