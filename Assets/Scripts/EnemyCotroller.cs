using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    private int hitCount;
    public int maxHits;
    public static EnemyCotroller instance;  
    private Animator animator;
    //public float time;
    public Health health;
    public HealthBarPlayer healthBarPlayer;
    public int myScore;


    private void OnEnable()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            
            if (hitCount >= maxHits)
            {
                animator.SetBool("IsDie", true); 
                AddScore(1);
                StartCoroutine(ExampleCoroutine(1f));
            }
        }

    }
    public void AddScore(int scoreAdd)
    {
        myScore += scoreAdd;
        MenuControll.instance.SetScore(myScore);
    }
    IEnumerator ExampleCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
