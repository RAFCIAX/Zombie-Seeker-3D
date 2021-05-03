using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject forceField;
    public AddHpScript AHScript;

    [SerializeField] AudioSource a_source;
    [SerializeField] AudioClip ForceFieldEnableSound;
    [SerializeField] AudioClip ForceFieldDisableSound;

    void Start()
    {
        forceField.SetActive(false);
        AHScript = GetComponent<AddHpScript>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            forceField.SetActive(true);
            a_source.PlayOneShot(ForceFieldEnableSound);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            forceField.SetActive(false);
            a_source.PlayOneShot(ForceFieldDisableSound);
            AHScript.fullHpPlayed = false;
        }
    }
}
