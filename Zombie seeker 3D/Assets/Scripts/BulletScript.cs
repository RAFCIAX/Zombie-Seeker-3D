using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;

    public PlayerScript player;

    public GameObject destroyEfffect;

    public GameObject wallHitGO;
    public GameObject metalHitGO;
    public GameObject woodHitGO;

    public Vector3 force = new Vector3(5f, 0, 0);

    public float forcee = 5f;

    public static int damage = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerScript>();

        Destroy(gameObject, 5f);

        //rb.transform.Translate(Vector3.forward);
        //Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        //rb.AddForce(localForward * forcee, ForceMode.Impulse);
    }
    void Update()
    {
        transform.Translate(Vector3.forward);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Wall")
        {
            var wallHit = Instantiate(wallHitGO, transform.position, Quaternion.identity);
            Destroy(wallHit, 1f);
            Debug.Log("Wall - sound played");
            var destroy = Instantiate(destroyEfffect, transform.position, Quaternion.identity);
            Destroy(destroy, 1f);
            Destroy(gameObject);
        }
        else if (target.gameObject.tag == "Metal")
        {
            var mmetalHit = Instantiate(metalHitGO, transform.position, Quaternion.identity);
            Destroy(mmetalHit, 1f);
            Debug.Log("Metal - sound played");
            var destroy = Instantiate(destroyEfffect, transform.position, Quaternion.identity);
            Destroy(destroy, 1f);
            Destroy(gameObject);
        }
        else if (target.gameObject.tag == "Wood")
        {
            var woodHit = Instantiate(woodHitGO, transform.position, Quaternion.identity);
            Destroy(woodHit, 1f);
            Debug.Log("Wood - sound played");
            Destroy(gameObject);
        }
        else
        {
            var destroy = Instantiate(destroyEfffect, transform.position, Quaternion.identity);
            Destroy(destroy, 1f);
            Destroy(gameObject);
        }
    }
}
