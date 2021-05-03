using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZoneScript : MonoBehaviour
{
    public GameObject FinishPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        FinishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Finish();
    }

    void Finish()
    {
        FinishPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
