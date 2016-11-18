using UnityEngine;
using System.Collections;

public class FootStepController : MonoBehaviour {

    private AudioSource source;
    private System.Collections.Generic.Dictionary<string, AudioClip> clips;
    private string previousSurface;

	void Start () {
        source = GetComponent<AudioSource>();
        clips = new System.Collections.Generic.Dictionary<string, AudioClip>();

        clips.Add("Ground", Resources.Load("Sounds/ground_footstep") as AudioClip);
        clips.Add("Grass", Resources.Load("Sounds/grass_footstep") as AudioClip);

        source.clip = clips["Ground"];
    }

    public void play(string onTheGround)
    {
        onChange(onTheGround);
        if (!source.isPlaying)
            source.Play();
    }

    public void mute()
    {
        source.mute = true;
    }

    public void onChange(string onTheGround)
    {
        if (previousSurface != onTheGround && clips.ContainsKey(onTheGround))
        {
            source.clip = clips[onTheGround];
            previousSurface = onTheGround;
        }
    }

}
