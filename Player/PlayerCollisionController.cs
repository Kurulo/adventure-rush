using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionController : MonoBehaviour
{

    [SerializeField] private SaveBehaviour _saveBehaviour;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private ParticleSystem TakeCoin;

    private int resurrectionCoin = 5;
    private int coins;
    
    public int Dimonds
    {
        get { return resurrectionCoin; }
    }
    
    public int Coins
    {
        get { return coins; }
    }
    
    [SerializeField] private Text coinText;
    [SerializeField] private Text resurrectionCoinText;

    [SerializeField] private SpeedController _speedController;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            GetComponent<PlayerAnimationController>().SetTriggerDeath();
            _speedController.CanMove = false;
            GetComponent<PlayerController>().enabled = false;
            _saveBehaviour.SaveIntoFile();
        }   
    }
    
    public void Losing()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Start()
    {
        losePanel.SetActive(false);
        resurrectionCoinText.text = resurrectionCoin.ToString();
    }
    

    public void Resurrection()
    {
        if (resurrectionCoin >= 1)
        {
            losePanel.SetActive(false);
            Time.timeScale = 1;
            _speedController.CanMove = true;
            GetComponent<PlayerController>().enabled = true;
            GetComponent<PlayerAnimationController>().SetTriggerRun();
            resurrectionCoin--;
            resurrectionCoinText.text = resurrectionCoin.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Coroutine _courutine;
        Coroutine _courutine2; 
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinText.text = coins.ToString();
            // TakeCoin.Play();
            other.gameObject.GetComponent<RotationCoin>().PlayMusic();
            _courutine = StartCoroutine(sleepSetActive());
        }
        IEnumerator sleepSetActive()
        {
            yield return new WaitForSeconds(0.2f);
            other.gameObject.SetActive(false);
            _courutine = null;
        }
         if (other.gameObject.tag == "Diamond")
         {
             resurrectionCoin++;
             resurrectionCoinText.text = resurrectionCoin.ToString();
             other.gameObject.GetComponent<RotationDiamond>().PlayMusic();
             _courutine2 = StartCoroutine(sleepSetActive2());
         }
         IEnumerator sleepSetActive2()
         {
             yield return new WaitForSeconds(0.2f);
             other.gameObject.SetActive(false);
             _courutine2 = null;
         }
    }
}
