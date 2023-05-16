using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPools : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int initialSize = 50;
    private List<GameObject> pool = new List<GameObject>();
    public static BulletPools instance;
    public Transform spawnPoint;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        GameObject newObj = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        pool.Add(newObj);
        return newObj;

    }
}
