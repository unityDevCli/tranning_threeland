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
    

    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene(gameLevel);
    }
  
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
  
}
