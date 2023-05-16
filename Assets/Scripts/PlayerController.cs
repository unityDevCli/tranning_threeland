using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
    //public HealthBarPlayer healthBarPlayer;
    private int curHealth;
    private int maxHealth = 100;
    public float time;
    public Transform playerTransform;
    public MenuControll menuControl;
    private void OnEnable()
    {
        instance = this;
    }

    void Start()
    {
        curHealth = maxHealth;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DamagePlayer(5);
        }
        PlayerDie();
    }
    
    // Update is called once per frame
    public void IncreateHP(int hp)
    {
        curHealth += hp;
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        HealthBarPlayer.instance.SetHealth(curHealth);
    }
    public void PlayerDie()
    {
        if(curHealth <= 0)
        {
            Animator animator = playerTransform.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isDie", true);
                StartCoroutine(ExampleCoroutine());
                menuControl.GameOver();               
            }
            
        }

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(time);
        playerTransform.gameObject.SetActive(false);
        //Time.timeScale = 0f;
    }
}
