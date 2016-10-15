using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float rotationSpeed = 100.0f;

    [SerializeField]
    float moveSpeed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, rotation, 0);
	}
}
