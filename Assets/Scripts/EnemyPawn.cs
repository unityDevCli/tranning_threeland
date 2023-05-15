using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPawn : MonoBehaviour
{
    public static EnemyPawn instance;
    public float speedEnemy;
    public GameObject enemyPrefab; 
    public Transform enemySpawnPoint;
    public Transform enemyTile; 
    //private List<GameObject> enemyPool = new List<GameObject>();
    public List<Transform> enemyTransforms;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = ObjectPools.instance.GetPooledObject();
            enemy.transform.position = enemySpawnPoint.position;
            enemy.SetActive(true);
            UpdateEnemyTransforms();
            RotationEnemy(enemy);
            StartCoroutine(MoveEnemy(enemy));
            yield return new WaitForSeconds(1f);
        }
    }
   
    private void RotationEnemy(GameObject enemy)
    {
        Vector3 direction = (enemyTile.position - enemy.transform.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(direction);
        enemy.transform.rotation = lookDir;

    }
    private void UpdateEnemyTransforms()
    {
        enemyTransforms.Clear(); 

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf) 
            {
                enemyTransforms.Add(enemy.transform);
            }
        }
    }

    private IEnumerator MoveEnemy(GameObject enemy)
    {
        Vector3 direction = (enemyTile.position - enemy.transform.position).normalized; 
        float distance = Vector3.Distance(enemy.transform.position, enemyTile.position);
        while (distance > 0.1f)
        {
            enemy.transform.Translate(-direction  * Time.deltaTime);
            distance = Vector3.Distance(enemy.transform.position, enemyTile.position);
            yield return null;
        } 
        
    }
    
    void Update()
    {
    }
}


