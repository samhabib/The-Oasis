using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour {

	public float jumpSpeed = 2.0f;
	public float moveSpeed = 1.0f;
	public float turnSpeed = 2.0f;
	public Text winText;
	public Text collectableText;
	private int collectableTotal;
	
	public AudioClip collectSound;
	private AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
		GameObject[] collectableArray = GameObject.FindGameObjectsWithTag ("Collectable");
		collectableTotal = collectableArray.Length;
		collectableText.text = "Boxes Remaining: " + collectableTotal;
		winText.text = "";
		audioPlayer = this.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
			this.transform.position = 
				this.transform.position + 
				this.transform.localRotation * Vector3.forward * moveSpeed;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			this.transform.position = 
				this.transform.position + 
				this.transform.localRotation * Vector3.back * moveSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.localRotation =
				Quaternion.Euler (0, -turnSpeed, 0) * this.transform.localRotation;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.localRotation =
				Quaternion.Euler (0, turnSpeed, 0) * this.transform.localRotation;
		}

		if (Input.GetKey (KeyCode.Space)) {
			this.transform.position = 
				this.transform.position + 
				this.transform.localRotation * Vector3.up * jumpSpeed;			
		}
	}

	void OnCollisionEnter(Collision col)
	{	print ("collision detected");
		print (col.gameObject.tag);
		if (col.gameObject.tag == "Collectable") {
			audioPlayer.PlayOneShot (collectSound);
			Destroy(col.gameObject);
			collectableTotal -= 1;
			collectableText.text = "Boxes Remaining: " + collectableTotal;
			if (collectableTotal <= 0) {
				collectableText.text = "";
				winText.text = "You Win";

			}
		}
	}
		
}
