using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControll : MonoBehaviour
{
    public GameObject barrier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            StartCoroutine(ExampleCoroutine());
        }
    }
    IEnumerator ExampleCoroutine()
    {
        float randomtime = Random.Range(3f, 5f);
        yield return new WaitForSeconds(randomtime);
        barrier.gameObject.SetActive(false);
    }
}
