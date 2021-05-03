using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    [SerializeField] AudioSource a_Source;
    [SerializeField] AudioClip crateSound;

    public bool canPlay;

    private void Start()
    {
        a_Source = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet" && canPlay)
        {
            a_Source.Play();
            StartCoroutine(WaitForNextSound());
        }
    }

    public IEnumerator WaitForNextSound()
    {
        canPlay = false;
        yield return new WaitForSeconds(4f);
        canPlay = true;
    }
}
