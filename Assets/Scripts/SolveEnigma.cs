using UnityEngine;
using System.Collections;

public class SolveEnigma : MonoBehaviour {

    Door door;
	// Use this for initialization
	void Start () {
        door = (Door)FindObjectOfType(typeof(Door));

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.tag == "EnigmaItem")
        {
            Debug.Log("TRUE");
            //opens the door
            door.enter = true;
        }
    }
}
