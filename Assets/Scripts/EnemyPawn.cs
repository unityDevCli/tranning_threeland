using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPawn : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform enemySpawnPoint;
    public Transform enemyTile; 
    private List<GameObject> enemyPool = new List<GameObject>(); 

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = GetPooledEnemy(); 
            enemy.SetActive(true); 

            StartCoroutine(MoveEnemy(enemy)); 
            RotationEnemy(enemy);

            yield return new WaitForSeconds(3f);
        }
    }

    private GameObject GetPooledEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
        enemyPool.Add(enemy);

        return enemy;
    }
    private void RotationEnemy(GameObject enemy)
    {
        Vector3 direction = (enemyTile.position - enemy.transform.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(direction);
        enemy.transform.rotation = lookDir;

    }

    private IEnumerator MoveEnemy(GameObject enemy)
    {
        Vector3 direction = (enemyTile.position - enemy.transform.position).normalized; 
        float distance = Vector3.Distance(enemy.transform.position, enemyTile.position);

        while (distance > 0.1f)
        {
            enemy.transform.Translate(-direction * Time.deltaTime);
            //Quaternion lookDir = Quaternion.LookRotation(direction);
            //enemy.transform.rotation = lookDir;
            distance = Vector3.Distance(enemy.transform.position, enemyTile.position); 

            yield return null;
        }
        KilledEnemy(enemy);
    }
    public int hitCount;
    public int maxHits;

    private void KilledEnemy(GameObject enemy)
    {
        if (gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            if (hitCount >= maxHits)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {

    }
}


