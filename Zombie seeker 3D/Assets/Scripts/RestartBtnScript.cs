using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtnScript : MonoBehaviour
{
    public int current;

    // Start is called before the first frame update
    void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart(int current)
    {
        SceneManager.LoadScene(current);
    }
}
