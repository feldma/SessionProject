﻿using UnityEngine;
using System.Collections;

public class endController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider col)
    {
        GetComponent<AudioSource>().Play();
    }
}
