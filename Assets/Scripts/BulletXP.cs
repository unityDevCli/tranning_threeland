using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletXP : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> newBulletList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Vector3 currentVelocity = rb.velocity;
        Vector3 myVec = new Vector3(0.1f, 0.0f, 0.1f);
       

        if (other.CompareTag("Barrierx4"))
        {
            for(int i = 1; i < 4; i++)
            {
                GameObject newBullet = BulletPools.instance.GetPooledObject();
                newBulletList.Add(newBullet);
                newBullet.transform.position = gameObject.transform.position + myVec*i;
                newBullet.SetActive(true);
                Rigidbody rb2 = newBullet.GetComponent<Rigidbody>();
                rb2.velocity = currentVelocity + Vector3.right * (i + 1);
            }
            Debug.Log(newBulletList.Count);
            StartCoroutine(DeactiveList(1f));
        }
        else if (other.CompareTag("BarrierX2"))
        {
            GameObject newBullet = BulletPools.instance.GetPooledObject();
            newBullet.transform.position = gameObject.transform.position + myVec*2;
            newBullet.SetActive(true);
            Rigidbody rb2 = newBullet.GetComponent<Rigidbody>();
            rb2.velocity = (rb.velocity + Vector3.right* 0.2f);
            EnemyPawn.instance.StartCoroutine(DeactivateBulletAfterTime(newBullet, 1f));
        }
        
    }
    public IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("false");
        bullet.SetActive(false);
    }
    public IEnumerator DeactiveList(float time)
    {
        Debug.Log(newBulletList.Count);
        yield return new WaitForSeconds(time);

        Debug.Log("11111111111111: "+newBulletList.Count);
        foreach (GameObject newbullet in newBulletList)
        {
            newbullet.SetActive(false);
        }
        Debug.Log("true");
        newBulletList.Clear();
    }

// Update is called once per frame
void Update()
    {
        
    }
}
