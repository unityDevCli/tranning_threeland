using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //public bool isPressStart = false;
    //public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        //startButton.onClick.AddListener(StartGame);
    }
    public void StartPlaying()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex+1;
        Time.timeScale = 1f;
        Debug.Log(currentScene);
        SceneManager.LoadScene(currentScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
