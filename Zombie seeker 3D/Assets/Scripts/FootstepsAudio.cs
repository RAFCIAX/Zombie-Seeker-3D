using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] AudioSource a_source;
    [SerializeField] AudioClip fs1;
    [SerializeField] AudioClip fs2;
    [SerializeField] AudioClip fs3;
    [SerializeField] AudioClip fs4;
    [SerializeField] AudioClip fs5;
    [SerializeField] AudioClip fs6;

    private bool playFS;
    private bool letFS;

    void Start()
    {
        playFS = true;
    }

    void Update()
    {
        if (player.joysick.Horizontal != 0 || player.joysick.Vertical != 0)
            letFS = true;
        else
            letFS = false;

        if (letFS)
            PlayFootsteps();
    }

    void PlayFootsteps()
    {
        if (playFS)
        {
            int picked = Random.Range(1, 7);
            Debug.Log("Picked FS sound: " + picked);

            switch (picked)
            {
                case 1:
                    a_source.PlayOneShot(fs1);
                    StartCoroutine(WaitForNextStep());
                    break;
                case 2:
                    a_source.PlayOneShot(fs2);
                    StartCoroutine(WaitForNextStep());
                    break;
                case 3:
                    a_source.PlayOneShot(fs2);
                    StartCoroutine(WaitForNextStep());
                    break;
                case 4:
                    a_source.PlayOneShot(fs2);
                    StartCoroutine(WaitForNextStep());
                    break;
                case 5:
                    a_source.PlayOneShot(fs2);
                    StartCoroutine(WaitForNextStep());
                    break;
                case 6:
                    a_source.PlayOneShot(fs2);
                    StartCoroutine(WaitForNextStep());
                    break;
                default:
                    a_source.PlayOneShot(fs1);
                    StartCoroutine(WaitForNextStep());
                    break;
            }

        }

    }

    IEnumerator WaitForNextStep()
    {
        playFS = false;
        yield return new WaitForSeconds(.35f);
        playFS = true;
    }
}
