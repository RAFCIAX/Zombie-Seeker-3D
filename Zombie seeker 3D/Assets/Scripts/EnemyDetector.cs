using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public PlayerScript playerScript;

    public Transform raySource;
    public int distanceToRecognize;
    public int distanceToShoot;

    public bool canShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        raySource = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                //Debug.Log(distanceToClosestEnemy);
            }
        }

        if (distanceToClosestEnemy < distanceToRecognize)
        {
            Debug.DrawLine(raySource.transform.position, closestEnemy.transform.position);
            transform.LookAt(closestEnemy.transform.position, Vector3.forward);
        }
        else
        {
            //transform.LookAt(movement);
            transform.rotation = Quaternion.LookRotation(playerScript.movement);
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
}
