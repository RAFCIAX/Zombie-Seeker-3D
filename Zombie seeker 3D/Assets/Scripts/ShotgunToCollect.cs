using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunToCollect : MonoBehaviour
{
    public PlayerScript player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, speed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.ShotgunCollected();
            Destroy(gameObject);
        }
    }
}
