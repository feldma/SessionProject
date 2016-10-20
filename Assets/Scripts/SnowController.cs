using UnityEngine;
using System.Collections;

public class SnowController : MonoBehaviour {

    private PlayerController player;

    private ParticleSystem.EmissionModule emitter;

    // Use this for initialization
    void Start ()
    {
        emitter = GetComponent<ParticleSystem>().emission;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        emitter.rate = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float karma = player.getKarma();

        if (karma < 1.1f)
            emitter.rate = 1000 / karma;
        else
            emitter.rate = 0;
	}
}
