using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletXP : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        GameObject newbullet = BulletPools.instance.GetPooledObject();
        Vector3 myVec = new Vector3(0.1f, 0.0f, 0.1f);
        newbullet.transform.position = gameObject.transform.position + myVec;

        if (other.CompareTag("Barrierx4"))
        {
            
            newbullet.SetActive(true);
            Rigidbody rb2 = newbullet.GetComponent<Rigidbody>();
            rb2.velocity = (rb.velocity + Vector3.right )*2 ;
            Debug.Log(rb2.velocity);
        }
        if (other.CompareTag("BarrierX2"))
        {
            newbullet.SetActive(true);
            Rigidbody rb2 = newbullet.GetComponent<Rigidbody>();
            rb2.velocity = (rb.velocity + Vector3.up) * 4;
            Debug.Log(rb2.velocity);
           
        }
        StartCoroutine(DeactivateBulletAfterTime(newbullet, 1f));
    }
    public IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bullet.SetActive(false);
    }


// Update is called once per frame
void Update()
    {
        
    }
}
