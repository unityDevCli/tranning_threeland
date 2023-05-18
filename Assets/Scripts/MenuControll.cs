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
    [SerializeField] private GameObject winPanel;
    [SerializeField] int gameLevel;
    public Text display1;
    [SerializeField] private Text display2;
    public Text display3;
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
    public IEnumerator YouWin()
    {
        yield return new WaitForSeconds(0.5f);
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void SetWin()
    {
        bool allEnemiesInactive = true;

        foreach (GameObject enemy in EnemyPawn.instance.enemyPool)
        {
            if (enemy.activeSelf)
            {
                allEnemiesInactive = false;
                break;
            }
        }

        if (allEnemiesInactive)
        {
            StartCoroutine(YouWin());
        }
    }
    private void Update()
    {
        display1.text = myScore.ToString();
        display2.text = myScore.ToString();
        display3.text = myScore.ToString();
        SetWin();
        
    }

}
