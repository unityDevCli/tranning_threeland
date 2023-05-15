using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    private int hitCount;
    public int maxHits;
    private Animator animator;
    public float timeDelay;
    public Health health;
    public HealthBarPlayer healthBarPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
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
                StartCoroutine(ExampleCoroutine());
            }
        }

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(timeDelay);
        gameObject.SetActive(false);
    }
}
