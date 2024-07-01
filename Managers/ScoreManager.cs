using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public GameObject SpeedContainer;

    private SpeedController _speedController;
    
    private int _currentScore;
    private int _forCheckScore = 0;
    private int _totalScore;
    
    void Start() {
        scoreText.text = "0";
        if (SpeedContainer.GetComponent<SpeedController>()) {
            _speedController = SpeedContainer.GetComponent<SpeedController>();
        }
    }
    
    void Update() { 
        if (_speedController.CanMove && Time.timeScale != 0)
        {
            AddScore();
            CheckSpeedAdd();
        
            UpdateText();
        }
    }
    
    public void AddScore(int x2Bonus = 1)
    {
        _currentScore += 1 * x2Bonus;
    }
    
    private void CheckSpeedAdd() 
    {
        if (_currentScore == _forCheckScore + 2000) {
            _forCheckScore += 2000;
            _speedController.AddSpeed();
        }
    }
    
    private void UpdateText()
    {
        scoreText.text = $"{_currentScore.ToString()}";
    }
    
    public int GetCurrentScore() {
        return _currentScore;
    }
}
