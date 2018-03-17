using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	private GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pos1 = players [0].transform.position;
		Vector3 pos2 = players [1].transform.position;


		transform.position = (pos1+pos2)/2 + offset;
	}
}
