using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject forceField;

    // Start is called before the first frame update
    void Start()
    {
        forceField.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            forceField.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
            forceField.SetActive(false);
    }
}
