using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    float karmaWeight;

    private AudioSource fallSource;

    // Use this for initialization
    void Start()
    {
        fallSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float getKarmaWeight()
    {
        return karmaWeight;
    }

    public void playFallingSound()
    {
        fallSource.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            fallSource.volume = 1 / collision.relativeVelocity.magnitude;
            fallSource.PlayDelayed(0.1f);
        }
    }
}
