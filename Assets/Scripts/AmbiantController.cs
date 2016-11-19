using UnityEngine;
using System.Collections;

public class AmbiantController : MonoBehaviour
{

    private AudioSource ambiant;

    private AudioClip day_ambiant;
    private AudioClip night_ambiant;

    // Use this for initialization
    void Start()
    {
        ambiant = GetComponent<AudioSource>();
        day_ambiant = Resources.Load("Sounds/day_ambiance") as AudioClip;
        night_ambiant = Resources.Load("Sounds/night_ambiance") as AudioClip;

        if (day_ambiant) Debug.Log("Day_ambiant Loaded");
        if (night_ambiant) Debug.Log("Night_ambiant Loaded");
    }

    // Update is called once per frame
    void Update()
    {
        float karmaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getKarma();

        ambiant.clip = karmaPlayer < 2.00f ? night_ambiant : day_ambiant;

        if (!ambiant.isPlaying)
            ambiant.Play();
    }
}
