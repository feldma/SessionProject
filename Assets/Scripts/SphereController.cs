using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    float karmaWeight;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float getKarmaWeight()
    {
        return karmaWeight;
    }
}
