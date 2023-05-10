using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifeTime;
    public List<Transform> enemyTransforms;

    private List<GameObject> bulletPool = new List<GameObject>();

    void Start()
    {
        // lay danh sach enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemyTransforms.Add(enemy.transform);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform randomEnemyTransform = enemyTransforms[Random.Range(0, enemyTransforms.Count)];
            GameObject bullet = GetPooledBullet();
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.position = bulletSpawnPoint.position;
            // Direction bullet
            Vector3 direction = (randomEnemyTransform.position - bulletSpawnPoint.position).normalized;

            // H??ng b?n cho ??n
            bullet.transform.rotation = Quaternion.LookRotation(direction);

            // Set ??n active và di chuy?n theo h??ng v?a tính toán ???c
            bullet.SetActive(true);
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.velocity = direction * bulletSpeed;

            // L?u tr? th?i gian sinh ??n ?? sau 4 giây SetActive(false)
            StartCoroutine(DeactivateBulletAfterTime(bullet, bulletLifeTime));
        }
    }

    private GameObject GetPooledBullet()
    {
        // Tìm bullet không ho?t ??ng trong pool ?? tái s? d?ng
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }

        // N?u không còn bullet nào trong pool, t?o m?i
        GameObject bullet = Instantiate(bulletPrefab);
        bulletPool.Add(bullet);
        bullet.SetActive(false);

        return bullet;
    }

    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(bullet.GetComponent<Rigidbody>());
        bullet.SetActive(false);
    }
}