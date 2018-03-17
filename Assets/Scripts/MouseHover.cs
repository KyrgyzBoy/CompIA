﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void onMouseEnter () {
        this.GetComponent<Renderer>().material.color = Color.green;
    }
    void onMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.black;
    }
}
