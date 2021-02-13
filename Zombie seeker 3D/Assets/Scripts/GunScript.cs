using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public PlayerScript player;
    public EnemyDetector enemyDetector;

    public bool canGunShoot = true;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        enemyDetector = FindObjectOfType<EnemyDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canShoot && canGunShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
            var bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            canGunShoot = false;
            StartCoroutine(WaitToShoot());
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(0.5f);
        canGunShoot = true;
    }
}
