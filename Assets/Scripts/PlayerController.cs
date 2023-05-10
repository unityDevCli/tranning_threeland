using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isShooting;
    [SerializeField] private Rigidbody myRigidbody;
    public int speedBullet;
    public static PlayerController instance;

    private void OnEnable()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void IsShooting()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
