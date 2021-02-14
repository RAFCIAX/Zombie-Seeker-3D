using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Joystick joysick;
    public GunScript gun;
    public SubmachineGunScript subGun;
    public ShotgunScript shotgun;
    public HealthBarScript hpBar;
    public RestartbuttonsScript restertBtn;
    public EnemyDetector enemyDetector;

    public Transform raySource;

    public float speed;
    public float distanceToRecognize;
    public float distanceToShoot;

    public Vector3 playerMovement;
    public Vector3 movement;

    public int health;
    public int maxHealth = 100;

    public bool playerDied = false;

    public bool usingPistol;
    public bool usingSMG;
    public bool usingShotgun;
    public bool canShoot = false;

    public GameObject pistolGO;
    public GameObject smgGO;
    public GameObject shotgunGO;


    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joysick = FindObjectOfType<Joystick>();
        gun = FindObjectOfType<GunScript>();
        subGun = FindObjectOfType<SubmachineGunScript>();
        shotgun = FindObjectOfType<ShotgunScript>();
        hpBar = FindObjectOfType<HealthBarScript>();
        enemyDetector = FindObjectOfType<EnemyDetector>();

        rb.freezeRotation = true;

        playerDied = false;

        health = maxHealth;

        PistolCollected();
    }

    void Update()
    {
        playerMovement = new Vector3(joysick.Horizontal * speed, 0, joysick.Vertical * speed);
        movement = new Vector3(joysick.Horizontal, 0, joysick.Vertical);
        transform.position += playerMovement;

        FindClosestEnemy();

        if (health <= 0)
        {
            Die();
        }

        hpBar.SetHealth(health);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            PistolCollected();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SMGCollected();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ShotgunCollected();
        }
    }

    public void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - raySource.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if (distanceToClosestEnemy < distanceToRecognize)
        {
            Debug.DrawLine(raySource.transform.position, closestEnemy.transform.position);
            transform.LookAt(closestEnemy.transform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        if (distanceToClosestEnemy < distanceToShoot)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hpBar.SetHealth(health);
    }

    public void Die()
    {
        Time.timeScale = 0;
        restertBtn.gameObject.SetActive(true);
    }

    public void PistolCollected()
    {
        pistolGO.SetActive(true);
        smgGO.SetActive(false);
        shotgunGO.SetActive(false);
    }

    public void SMGCollected()
    {
        pistolGO.SetActive(false);
        smgGO.SetActive(true);
        shotgunGO.SetActive(false);
    }

    public void ShotgunCollected()
    {
        pistolGO.SetActive(false);
        smgGO.SetActive(false);
        shotgunGO.SetActive(true);
    }





    /*
    ALL COMMENTS - moved for cleaning purposes

        //hpBar.slider.value = health;
        //hpBar.SetHealth(health);
        //rb.velocity = new Vector3(joysick.Horizontal * speed, rb.velocity.y, joysick.Vertical * speed);
        //FindClosestEnemy();
        //Debug.Log(distanceToClosestEnemy);
        //transform.LookAt(movement);
        //playerDied = true;
        usingPistol = true;
        usingSMG = false;
        usingShotgun = false;

        //if (usingPistol)
        //{
        //    gun.gameObject.SetActive(true);
        //    subGun.gameObject.SetActive(false);
        //    shotgun.gameObject.SetActive(false);
        //}
        //else if (usingSMG)
        //{
        //    gun.gameObject.SetActive(false);
        //    subGun.gameObject.SetActive(true);
        //    shotgun.gameObject.SetActive(false);
        //}
        //else if (usingShotgun)
        //{
        //    gun.gameObject.SetActive(false);
        //    subGun.gameObject.SetActive(false);
        //    shotgun.gameObject.SetActive(true);
        //}

    */


}
