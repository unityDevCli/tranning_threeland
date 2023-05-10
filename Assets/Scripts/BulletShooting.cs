using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
   // [SerializeField] private int timeDestroy;
    [SerializeField] private int maxHits;
    public int hitCount;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;

            if (hitCount >= maxHits)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        else
            Debug.Log("NoCollision");
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
