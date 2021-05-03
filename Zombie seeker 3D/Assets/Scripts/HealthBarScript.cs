using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public PlayerScript player;

    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        slider = GetComponent<Slider>();
        //slider.value = player.health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
