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

        if (gameObject.GetComponent<Light>().intensity < playerKarma)
        {
            gameObject.GetComponent<Light>().intensity += Time.deltaTime;
        }
        else if (gameObject.GetComponent<Light>().intensity > playerKarma && gameObject.GetComponent<Light>().intensity > 0)
        {
            gameObject.GetComponent<Light>().intensity -= Time.deltaTime;
        }
    }
}
