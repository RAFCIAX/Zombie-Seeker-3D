using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpScript : MonoBehaviour
{
    public PlayerScript player;

    public bool canAdd;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        canAdd = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canAdd)
        {
            player.health += 10;
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
