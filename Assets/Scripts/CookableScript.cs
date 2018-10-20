using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableScript : MonoBehaviour {

	public Sprite meat_uncooked;
	public Sprite meat_cooked;
	public Sprite beans_uncooked;
	public Sprite beans_cooked;

	float time = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if object is on a burner
		if (transform.parent.transform.tag == "burner") {
			time += Time.deltaTime;
			// if it has been on a burner for 10 seconds change sprite to cooked
			if (time == 10) {
				// meat
				if (this.GetComponent<SpriteRenderer>().sprite == meat_uncooked) {
					this.GetComponent<SpriteRenderer>().sprite = meat_cooked;
				}
				// beans
				else if (this.GetComponent<SpriteRenderer>().sprite == beans_uncooked) {
					this.GetComponent<SpriteRenderer>().sprite = beans_cooked;
				}
			}
			// if it has been on burner for 15 seconds destroy it
			else if (time == 15) {
				Destroy(this);
			}
		}
	}
}
