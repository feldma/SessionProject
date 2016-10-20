using UnityEngine;
using System.Collections;

public class SolveEnigma : MonoBehaviour
{

    Door door;
    // Use this for initialization
    void Start()
    {
        door = (Door)FindObjectOfType(typeof(Door));

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (other.tag == "EnigmaItem")
        {
            player.setKarma(other.GetComponent<SphereController>().getKarmaWeight());
            //opens the door
            door.enter = true;
        }
    }
}
