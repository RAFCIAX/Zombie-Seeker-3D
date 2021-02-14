using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGunScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireRate = 1f;
    public float nextFire = 0f;

    public float seconds = 5f;
    public bool X2FRPickedUp = false;

    public PlayerScript player;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Y) || player.canShoot)
        {
            Shoot();
        }

        if (X2FRPickedUp)
        {
            StartCoroutine(X2FireRate());
        }
    }

    public void Shoot()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            Debug.Log("Bullet shot");
        }
    }

    public IEnumerator X2FireRate()
    {
        fireRate = 0.1f;
        yield return new WaitForSeconds(seconds);
        fireRate = 0.2f;
        X2FRPickedUp = false;
    }
}
