using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpScript : MonoBehaviour
{
    public PlayerScript player;
    [SerializeField] AudioSource a_source;
    [SerializeField] AudioClip AddHp;
    [SerializeField] AudioClip FullHp;

    public bool canAdd;
    public bool fullHpPlayed;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        canAdd = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canAdd)
        {
            if (player.health < 100)
            {
                player.health += 10;
                a_source.PlayOneShot(AddHp);
            }
            else if (player.health == 100 && !fullHpPlayed)
            {
                a_source.PlayOneShot(FullHp);
                fullHpPlayed = true;
            }
            canAdd = false;
            StartCoroutine(AddHealthDealy());
        }
    }

    IEnumerator AddHealthDealy()
    {
        yield return new WaitForSeconds(2);
        canAdd = true;
    }
}
