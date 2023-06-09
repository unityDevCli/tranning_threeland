using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    private int hitCount;
    public int maxHits;
    public static EnemyCotroller instance;  
    private Animator animator;
    public HealthBarPlayer healthBarPlayer;
    public int myScore = 0;
    //public MenuControll MenuControll;
    [SerializeField] private GameObject scoreFloating;
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
                AddScore();
                StartCoroutine(ExampleCoroutine(0.75f));
                StartCoroutine(AddScoreFloating());
            }
        }

    }
    public IEnumerator AddScoreFloating()
    {
        Vector3 height = Vector3.up * 2;
        GameObject text = Instantiate(scoreFloating, (gameObject.transform.position + height), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        
    }
    public void AddScore()
    {
        MenuControll.instance.myScore++;
    }
    IEnumerator ExampleCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
