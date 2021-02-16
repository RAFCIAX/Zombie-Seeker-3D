using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartbuttonsScript : MonoBehaviour
{
    public int current;
    public PlayerScript player;
    public GameObject youDiedPanel;

    void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<PlayerScript>();
        gameObject.SetActive(false);

    }

    void Update()
    {
        if (player.playerDied == true)
        {
            gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(current);
        gameObject.SetActive(false);
    }
}
