using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour {
	Rigidbody2D rb;
	float speed;
	Renderer rend;
	public string customerTagName = "customer";
	float time = 0f;
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
			//rb.velocity += Vector2.down * .02f;
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

		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.2f);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.2f);
		Debug.DrawRay(transform.position, new Vector2(1, 0) * 1.2f, Color.green);
		Debug.DrawRay(transform.position, new Vector2(-1, 0) * 1.2f, Color.green);
		if(hitRight.collider != null){
			if(hitRight.transform.tag.Equals(customerTagName)){ //if car is a customer
				time += Time.deltaTime;
				if(time >= 1f){
					Debug.Log("hit " + hitRight.collider.name + "!");
					time = 0f;
				}
			}
		}
		if(hitLeft.collider != null){
			if(hitLeft.transform.tag.Equals(customerTagName)){
				time += Time.deltaTime;
				if(time >= 1f){
					Debug.Log("hit " + hitLeft.collider.name + "!");
					time = 0f;
				}
			}
		}
	}
}
