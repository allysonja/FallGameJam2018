using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableScript : MonoBehaviour {
	public bool cooked;
	public Sprite meat_uncooked;
	public Sprite meat_cooked;
	public Sprite beans_uncooked;
	public Sprite beans_cooked;
	SpriteRenderer sr;

	float time = 0f;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		cooked = false;
	}
	
	// Update is called once per frame
	void Update () {
		// if object is on a burner
		if (transform.parent.transform.tag == "Burner") {
			Debug.Log(time);
			time += Time.deltaTime;
			// if it has been on a burner for 10 seconds change sprite to cooked
			if (time > 10 && time < 15) {
				cooked = true;
				// meat
				if (sr.sprite == meat_uncooked) {
					sr.sprite = meat_cooked;
				}
				// beans
				else if (sr.sprite == beans_uncooked) {
					sr.sprite = beans_cooked;
				}
			}
			// if it has been on burner for 15 seconds destroy it
			if (time > 15) {
				Destroy(this.gameObject);
			}
		}

	}

	
}
