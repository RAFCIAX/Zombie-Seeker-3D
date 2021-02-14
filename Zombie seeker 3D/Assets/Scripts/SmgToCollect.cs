using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgToCollect : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(new Vector3(0f, speed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().SMGCollected();
            Destroy(gameObject);
        }
    }
}
