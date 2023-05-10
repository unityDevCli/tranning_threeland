using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public static BulletCreator instance;
    //public GameObject bullet;
    public GameObject bulletPrefab;
    //public GameObject[] bullets;
   //public int bulletCount;
    [SerializeField] private int speedBullet;
    public Transform enemyTransform;
    private void OnEnable()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Tìm ??i t??ng enemy trong scene
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObject != null)
        {
            enemyTransform = enemyObject.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = (enemyTransform.position - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                //Vector3 direction = (enemyTransform.position - transform.position).normalized;
                bulletRigidbody.velocity = direction * speedBullet;
            }
        }

    }
}
