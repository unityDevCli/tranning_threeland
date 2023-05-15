using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public Transform barrierSpawnPoint;
    public float spawnInterval = 8f;

    private void Start()
    {
        StartCoroutine(SpawnBarriers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void SpawnBarrier()
    {
        var randomGateIndex = Random.Range(0, gameObjects.Count);
        Debug.Log(randomGateIndex);
        GameObject barrier = Instantiate(gameObjects[randomGateIndex], barrierSpawnPoint.position, Quaternion.identity);
        barrier.SetActive(true);
        timelife--;
        if (timelife <= 0)
        {
            barrier.SetActive(false);
        }
    }*/
    private IEnumerator SpawnBarriers()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            var randomGateIndex = Random.Range(0, gameObjects.Count);
   
            GameObject barrier = Instantiate(gameObjects[randomGateIndex], barrierSpawnPoint.position, Quaternion.identity);
            barrier.SetActive(true);


            if (barrier != null)
            {
                float destroyDelay = Random.Range(3f, 6f);
                StartCoroutine(DestroyBarrierAfterDelay(barrier, destroyDelay));
                Destroy(barrier, destroyDelay);
            }

        }
    }
    private IEnumerator DestroyBarrierAfterDelay(GameObject barrier, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(barrier);
    }
}
