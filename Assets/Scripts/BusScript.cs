using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour {
	Rigidbody2D rb;
	float speed;
	Renderer rend;
	// Use this for initialization
	void Start () {
		speed = 50;
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(speed);
		if(Input.GetKey("w")){
			rb.velocity += Vector2.up * .05f;
			speed += .005f;
		}else{
			speed -= .005f;
			rb.velocity += Vector2.down * .02f;
		}
		if(Input.GetKey("s")){
			rb.velocity += Vector2.down * .01f;
			speed -= .05f;
		}
		if(Input.GetKey("a")){
			rb.velocity += Vector2.left * .05f;
		}
		if(Input.GetKey("d")){
			rb.velocity += Vector2.right * .05f;
		}
	}
}
