using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerScript player;

    public bool canGunShoot = true;
    private bool canShoot = true;

    [SerializeField] GameObject muzzleFlash;

    private AudioSource audioSource;

    private void OnEnable()
    {
        canGunShoot = true;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player.canShoot && canGunShoot || Input.GetKey(KeyCode.H) && canGunShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        var muzzle = Instantiate(muzzleFlash, firePoint.position, transform.rotation);
        Destroy(muzzle, 1f);
        audioSource.Play();
        canGunShoot = false;
        StartCoroutine(WaitToShoot());
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(0.5f);
        canGunShoot = true;
    }
}
