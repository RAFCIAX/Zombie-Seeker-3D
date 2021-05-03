using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2FireRateCollectibleScript : MonoBehaviour
{
    public SubmachineGunScript smg;

    // Start is called before the first frame update
    void Start()
    {
        smg = FindObjectOfType<SubmachineGunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            smg.X2FRPickedUp = true;
            //StartCoroutine(smg.X2FireRate());
            Destroy(gameObject);
        }
    }
}
