using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveBehaviour : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private PlayerCollisionController _playerCollision;
    
    [SerializeField] private Text _recordText;
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _dimondText;
    
    private string _savePath = Directory.GetCurrentDirectory() + "/Assets/Common/Saves/Save.json" ;

    private void Awake()
    {
        _recordText.text = GetFromJson().score.ToString();
        if (_coinText != null)
        {
            _coinText.text = GetFromJson().coins.ToString();
        }
        
        if (_dimondText != null)
        {
            _dimondText.text = GetFromJson().dimonds.ToString();
        }
    }
    
    public void SaveIntoFile()
    {
        try
        {
            int addCoins = GetFromJson().coins + _playerCollision.Coins;
            SaveInfo saveInfo = new SaveInfo(
                _scoreManager.GetCurrentScore(), addCoins, _playerCollision.Dimonds);
            
            string json = JsonUtility.ToJson(saveInfo);
            System.IO.File.WriteAllText(_savePath, json);
        } 
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }

    public SaveInfo GetFromJson()
    {
        var jsonString = File.ReadAllText(_savePath);
        var saveInfo = JsonUtility.FromJson<SaveInfo>(jsonString);

        return saveInfo;   
    }
    
    public class SaveInfo
    { 
        public int score;
        public int coins;
        public int dimonds;
    
        public SaveInfo(int score, int coins, int dimonds)
        {
            this.score = score;
            this.coins = coins;
            this.dimonds = dimonds;
        }
    }
}


