using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	public Transform target;
	public Transform myTransform;
	public float EnemySpeed;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		transform.Translate (Vector3.forward * EnemySpeed * Time.deltaTime);
	}
}
