using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartbuttonsScript : MonoBehaviour
{
    public int current;
    public PlayerScript player;
    public GameObject youDiedPanel;

    // Start is called before the first frame update
    void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<PlayerScript>();
        gameObject.SetActive(false);

    }

    // Update is called once per frame
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
