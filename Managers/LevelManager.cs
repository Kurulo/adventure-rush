using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pause;

    [SerializeField] 
    private Text _pauseTimer;
    
    Coroutine _courutinePause;
    
    private void Start()
    {
        if (_pause != null)
        {
            _pause.SetActive(false);
        }
        if (_pauseTimer != null)
        {
            _pauseTimer.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContiniueRun()
    {
        _pause.SetActive(false);
        _courutinePause = StartCoroutine(sleepActiveRun());
        
    }
    
    IEnumerator sleepActiveRun()
    {
        _pauseTimer.enabled = true;
        for (int i = 3; i >= 0; i--)
        {
            _pauseTimer.text = i.ToString();
            Debug.Log("Continue");
            yield return new WaitForSecondsRealtime(1);
        }
        _pauseTimer.enabled = false;
        Time.timeScale = 1;
        
    }
    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadShopScene()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadLeadersScene()
    {
        SceneManager.LoadScene(3);
    }
}
