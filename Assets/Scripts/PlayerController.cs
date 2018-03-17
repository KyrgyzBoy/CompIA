using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

    public GameObject[] pickups;

    public GameObject otherPlayer;

	void Start(){
        otherPlayer = GameObject.FindGameObjectWithTag("RedPlayer");
		rb = GameObject.FindGameObjectWithTag("YellowPlayer").GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        pickups = GameObject.FindGameObjectsWithTag("Pick-Up");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        count = (12 - pickups.Length + 1);
		rb.AddForce (movement * speed);
        
        SetCountText();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick-Up")){
			other.gameObject.SetActive(false);
            SetCountText();
			
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
