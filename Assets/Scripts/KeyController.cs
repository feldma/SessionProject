using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

    [SerializeField]
    PlayerController Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player.canTakeKey = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player.canTakeKey = false;
        }
    }
}
