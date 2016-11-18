using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{

    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameObject.GetComponent<Light>().intensity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float playerKarma = player.getKarma();
        float lightIntensity = gameObject.GetComponent<Light>().intensity;

        if (lightIntensity < playerKarma)
        {
            gameObject.GetComponent<Light>().intensity += 0.01f;
        }
        else if (lightIntensity > playerKarma && lightIntensity > 0)
        {
            gameObject.GetComponent<Light>().intensity -= 0.01f;
        }
    }
}
