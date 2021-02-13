using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public float nextFire;
    public float fireRate;

    public GameObject bulletPrefab;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public PlayerScript player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var bullet1 = Instantiate(bulletPrefab, firePoint1.position, transform.rotation);
            var bullet2 = Instantiate(bulletPrefab, firePoint2.position, transform.rotation);
            var bullet3 = Instantiate(bulletPrefab, firePoint3.position, transform.rotation);
            Debug.Log("Bullet shot");
        }
    }
}
