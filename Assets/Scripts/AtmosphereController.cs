using UnityEngine;
using System.Collections;

public class atmosphereController : MonoBehaviour {

    private AudioSource ambiant;

    [SerializeField]
    public AudioClip day_ambiance;

    [SerializeField]
    public AudioClip night_ambiance;

    // Use this for initialization
    void Start () {
        ambiant = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
