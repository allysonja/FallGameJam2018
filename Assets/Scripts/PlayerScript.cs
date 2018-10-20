using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	float speed;
	InteractionScript interS;
	// Use this for initialization
	void Start () {
		speed = 1f;
		interS = GetComponent<InteractionScript>();

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("i")){
			transform.position += Vector3.up * speed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
		if(Input.GetKey("k")){
			transform.position += Vector3.down * speed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler(0,0,180);
		}
		if(Input.GetKey("j")){
			transform.position += Vector3.left * speed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler(0,0,90);
		}
		if(Input.GetKey("l")){
			transform.position += Vector3.right * speed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler(0,0,270);
		}
		// initially, the temporary vector should equal the player's position
     	Vector3 clampedPosition = transform.position;
     	// Now we can manipulte it to clamp the y element
     	clampedPosition.y = Mathf.Clamp(transform.position.y, transform.parent.position.y + -1.6f,transform.parent.position.y + 1.4f);
		clampedPosition.x = Mathf.Clamp(transform.position.x, transform.parent.position.x + -.5f,transform.parent.position.x + .5f);
     	transform.position = clampedPosition;

		Debug.DrawRay(transform.position, transform.up * 0.2f, Color.green);
		if(Input.GetKeyDown("u")){
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
			if(hit.collider != null){
				Debug.Log("hit " + hit.collider.name + "!");
				if(hit.collider.transform.tag.Equals("Container") && interS.held == null){
					interS.getIngredient(hit);
				}
				if(hit.collider.transform.tag == "Burner"){
					if(interS.held != null){
						interS.held.transform.SetParent(hit.collider.transform);
						interS.held.transform.position = hit.collider.transform.position;
						interS.held = null;
						Debug.Log("this was run");
					}
					else if(interS.held == null && hit.collider.transform.childCount != 0){
						interS.held = hit.collider.transform.GetChild(0).transform.gameObject;
						hit.collider.transform.GetChild(0).transform.SetParent(this.gameObject.transform);
						Debug.Log("this was run too");
					}
				}
				
			}
		}
	}
}
