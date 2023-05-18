using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    public static MenuControll instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] int gameLevel;
    public Text display1;
    [SerializeField] private Text display2;
    public int myScore;

    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        //display1.text = "0";
    }
    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
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
    //public void SetScore(int score)
    //{
    //    myScore = score;
    //    display1.text = myScore.ToString();
    //    display2.text = score.ToString();

    //}
    private void Update()
    {
        display1.text = myScore.ToString();
        display2.text = myScore.ToString();
    }

}
