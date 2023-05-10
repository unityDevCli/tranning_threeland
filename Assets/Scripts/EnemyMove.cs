using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform enemyTile;
    [SerializeField] private float speedMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTile != null)
        {
            Vector3 direction = (enemyTile.position - transform.position).normalized;
            transform.position += direction * speedMove * Time.deltaTime;
        }
    }
}
