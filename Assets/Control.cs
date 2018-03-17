using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

    public GameObject[] pickups;

    public GameObject otherPlayer;

	void Start(){
        otherPlayer = GameObject.FindGameObjectWithTag("YellowPlayer");
		rb = GameObject.FindGameObjectWithTag("RedPlayer").GetComponent<Rigidbody>();
        count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Fire1");
		float moveVertical = Input.GetAxis ("Fire2");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        pickups = GameObject.FindGameObjectsWithTag("Pick-Up");
        rb.AddForce (movement * speed);
        count = (12 - pickups.Length + 1);
        SetCountText();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick-Up")){
			other.gameObject.SetActive(false);
			SetCountText ();
		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Respawn"))
		{ 
			winText.text = "You Suck!";
			rb.transform.position = new Vector3(0, -20, 0);
            otherPlayer.transform.position = new Vector3(0, -20, 0);
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count;
		if (count >= 12) {
			winText.text = "You Win!";
			rb.transform.position = new Vector3(0, -20, 0);
            otherPlayer.transform.position = new Vector3(0, -20, 0);
        }
	}
}
