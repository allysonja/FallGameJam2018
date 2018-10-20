using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
	Rigidbody2D rb;
	public int orderNum;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.down * 1f;
		//Debug.Log(rb.velocity);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = Vector2.down * 1f;
	}
}
