using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    public static MenuControll instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] int gameLevel;
    [SerializeField] Text display1;
    [SerializeField] private Text display2;
    public int myScore;

    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        //myScore = Score.instance.myScore;
        //PlayerPrefs.SetInt("score", myScore);
    }
    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene);
    }
    public void Exit()
    {
        int exitScene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(exitScene);
    }
  
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void SetScore(int score)
    {
        display1.text = score.ToString();
        
    }
    private void Update()
    {
        int score = EnemyCotroller.instance.myScore;
        display1.text = score.ToString();
        display2.text = score.ToString();
    }
}
