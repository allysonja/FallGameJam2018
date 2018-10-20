using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
	SpriteRenderer heldSR;
	public string ingredientName;
	public GameObject ingredient;
	public GameObject held;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void getIngredient(RaycastHit2D hit){
		ingredientName = hit.collider.transform.name;
		if(hit.collider.transform.name == "Lettuce"){
			held = Instantiate(ingredient, this.transform.position+ new Vector3(-.25f,0,0), transform.rotation);
			held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
			heldSR = held.GetComponent<SpriteRenderer>();
			heldSR.sprite = held.GetComponent<VegetablesScript>().lettuce;
		}
		if(hit.collider.transform.name == "Meat"){
			held = Instantiate(ingredient, transform.position + new Vector3(-.1f,0,0), transform.rotation);
			held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
		    heldSR = held.GetComponent<SpriteRenderer>();
			heldSR.sprite = held.GetComponent<CookableScript>().meat_uncooked;
		}
		if(hit.collider.transform.name == "Beans"){
			held = Instantiate(ingredient, transform.position + new Vector3(-.1f,0,0), transform.rotation);
		    heldSR = held.GetComponent<SpriteRenderer>();
			held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
			heldSR.sprite = held.GetComponent<CookableScript>().beans_uncooked;
		}
		if(hit.collider.transform.name == "HardShell"){
			held = Instantiate(ingredient, transform.position + new Vector3(-.1f,0,0), transform.rotation);
		    heldSR = held.GetComponent<SpriteRenderer>();
		    held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
			heldSR.sprite = held.GetComponent<VegetablesScript>().hard_shell;
		}
		if(hit.collider.transform.name == "SoftShell"){
			held = Instantiate(ingredient, transform.position + new Vector3(-.1f,0,0), transform.rotation);
		    heldSR = held.GetComponent<SpriteRenderer>();
			held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
			heldSR.sprite = held.GetComponent<VegetablesScript>().soft_shell;
		}
		if(hit.collider.transform.name == "Tomato"){
			held = Instantiate(ingredient, transform.position + new Vector3(-.1f,0,0), transform.rotation);
		    heldSR = held.GetComponent<SpriteRenderer>();
			held.transform.localScale = new Vector3(4,4,0);
			held.transform.parent = this.gameObject.transform;
			heldSR.sprite = held.GetComponent<VegetablesScript>().tomato;
		}
	}

}
