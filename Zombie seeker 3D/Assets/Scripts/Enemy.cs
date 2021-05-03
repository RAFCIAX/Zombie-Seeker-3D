using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int enemyHP;
    public PlayerScript player;
    public Vector3 playerPos;
    public Camera cam;
    public NavMeshAgent agent;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip zombieSound1;
    [SerializeField] AudioClip zombieSound2;
    [SerializeField] AudioClip zombieSound3;

    public float seconds;

    public int damage = 20;
    public bool canDealDamage = true;

    public ParticleSystem deathEffect;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        cam = FindObjectOfType<Camera>();
        agent = GetComponent<NavMeshAgent>();

        PlaySounds();
    }

    void Update()
    {
        NavigationMesh();
    }

    void NavigationMesh()
    {
        playerPos = player.transform.position;

        Ray ray = cam.ScreenPointToRay(playerPos);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        agent.SetDestination(playerPos);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            TakeDamage(BulletScript.damage);
        }

        if (coll.gameObject.tag == "Player" && canDealDamage == true)
        {
            player.TakeDamage(damage);
            StartCoroutine(WaitForDamage());
        }
    }

    void TakeDamage(int damage)
    {
        enemyHP -= damage;
        Debug.Log(enemyHP);
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
            //Instantiate(deathEffect, transform.position, transform.rotation);
        }

    }

    void PlaySounds()
    {
        int selectedClip = Random.Range(1, 3);
        if (selectedClip == 1)
        {
            audioSource.PlayOneShot(zombieSound1, 0.6f);
            seconds = zombieSound1.length + 2f;
            StartCoroutine(WaitForSound());
        }
        else if (selectedClip == 2)
        {
            audioSource.PlayOneShot(zombieSound2, 0.6f);
            seconds = zombieSound2.length + 2f;
            StartCoroutine(WaitForSound());
        }
        else if (selectedClip == 3)
        {
            audioSource.PlayOneShot(zombieSound3, 0.6f);
            seconds = zombieSound3.length + 2f;
            StartCoroutine(WaitForSound());
        }
    }

    public IEnumerator WaitForDamage()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(3);
        canDealDamage = true;
    }

    public IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(seconds);
        PlaySounds();
    }
}
