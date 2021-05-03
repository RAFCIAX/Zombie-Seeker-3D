using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public Transform safeZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(safeZone.position, Vector3.up);
        transform.rotation.SetLookRotation(safeZone.position, Vector3.up);
    }
}
