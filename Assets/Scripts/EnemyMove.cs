using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	public Transform target;
	public Transform myTransform;
	public float EnemySpeed;

    public GameObject redPlayer;
    public GameObject yellowPlayer;

    private void Start()
    {
        redPlayer = GameObject.FindGameObjectWithTag("RedPlayer");
        yellowPlayer = GameObject.FindGameObjectWithTag("YellowPlayer");
    }

    // Update is called once per frame
    void Update () {
        if(Vector3.Distance(transform.position, redPlayer.transform.position)<Vector3.Distance(transform.position, yellowPlayer.transform.position))
        {
            transform.LookAt(redPlayer.transform);
            transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
        }
        else
        {
            transform.LookAt(yellowPlayer.transform);
            transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
        }
		
	}
}
