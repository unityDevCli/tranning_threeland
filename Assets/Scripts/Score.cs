using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int myScore;
    public static Score instance;

    private void OnEnable()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myScore = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AddScore(1);
            //Debug.Log(myScore);
           
        }
    }
    public void AddScore(int scoreAdd)
    {
        myScore += scoreAdd;
        MenuControll.instance.SetScore(myScore);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
