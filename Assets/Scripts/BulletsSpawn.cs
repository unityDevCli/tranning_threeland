using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawn : MonoBehaviour
{
    public static BulletsSpawn instance;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    //public List<Transform> enemyTransforms;
    //private float bulletLifeTime = 0.75f;
    public float bulletSpeed;  

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        //enemyTransforms = EnemyPawn.instance.enemyTransforms;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Vector3 direction = Vector3.forward.normalized;

        GameObject bullet = BulletPools.instance.GetPooledObject();
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.SetActive(true);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * bulletSpeed;
    }

    public IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bullet.SetActive(false);
    }
}
