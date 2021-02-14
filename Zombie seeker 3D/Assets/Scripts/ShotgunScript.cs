using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public float nextFire;
    public float fireRate;

    public int clipSize;
    public int currentClipSize;

    public GameObject bulletPrefab;
    public GameObject muzzleFlash;

    public PlayerScript player;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public bool reloading;

    [SerializeField] AudioSource a_Source;
    [SerializeField] AudioClip bulletLoading;
    [SerializeField] AudioClip cockingWeapon;
    [SerializeField] AudioClip shotgunShot;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        clipSize = 12;
        currentClipSize = clipSize;
    }

    void Update()
    {
        if (player.canShoot || Input.GetKey(KeyCode.B))
        {
            Shoot();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            CheckIfReload();
        }
    }

    public void Shoot()
    {

        if (Time.time > nextFire && !reloading)
        {
            nextFire = Time.time + fireRate;
            var bullet1 = Instantiate(bulletPrefab, firePoint1.position, transform.rotation);
            var bullet2 = Instantiate(bulletPrefab, firePoint2.position, transform.rotation);
            var bullet3 = Instantiate(bulletPrefab, firePoint3.position, transform.rotation);
            var muzzle = Instantiate(muzzleFlash, firePoint1.position, transform.rotation);
            a_Source.PlayOneShot(shotgunShot);
            currentClipSize--;
            if (currentClipSize <= 0)
            {
                //StartReloading();
                CheckIfReload();
            }
            Debug.Log("Bullet shot");
        }
    }

    void CheckIfReload()
    {
        if (currentClipSize < clipSize)
        {
            LoadBullet();
        }
        else if (currentClipSize == clipSize)
        {
            CockWeapon();
            reloading = false;
        }
    }

    void LoadBullet()
    {
        a_Source.PlayOneShot(bulletLoading);
        currentClipSize++;
        StartCoroutine(LoadingBullet());
    }

    void CockWeapon()
    {
        a_Source.PlayOneShot(cockingWeapon);
    }

    IEnumerator LoadingBullet()
    {
        yield return new WaitForSeconds(0.2f);
        CheckIfReload();
    }
}
