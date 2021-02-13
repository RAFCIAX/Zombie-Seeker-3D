using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;

    public PlayerScript player;

    public Vector3 force = new Vector3(5f, 0, 0);

    public float forcee = 5f;

    public static int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerScript>();

        Destroy(gameObject, 5f);

        //rb.transform.Translate(Vector3.forward);

        //Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);

        //rb.AddForce(localForward * forcee, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
