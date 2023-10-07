using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] public float shootSpeed;
    [SerializeField] public float timeToShoot;

    public Transform spawnPosition;
    
    private bool isInTheField = false;
    private Transform targetPlayer;

    public GameObject projectile;
    private float OriginalTime;


    private void Awake()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform;

    }

    private void Start()
    {
        OriginalTime = timeToShoot;
    }

    private void FixedUpdate()
    {
        if (isInTheField)
        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot < 0)
            {
                ShootPlayer();

                timeToShoot = OriginalTime;
            }
        }
    }

    void ShootPlayer(){

        if (isInTheField){

            GameObject bullet = Instantiate(projectile, spawnPosition.position + transform.forward, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * shootSpeed);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Radius"))
        {
            isInTheField = true;
        }
    }

    /*public float range = 10.0f;
    [SerializeField] public float bulletImpulse= 20.0f;

    public GameObject projectile;

    public float shotDelayTime;
    public float shotInterval;

    private bool isInThefield = true;
    void Start(){

        InvokeRepeating("Shoot", shotDelayTime, shotInterval);
    }

    void Shoot(){

        if (isInThefield){

            GameObject bullet = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward*bulletImpulse);
        }

    }*/
}
