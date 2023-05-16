using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public bool isPressStart = false;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {
        if (!isPressStart)
        {
            isPressStart= true;
            // B?t ??u game
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
