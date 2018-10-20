using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablesScript : MonoBehaviour {

	public Sprite lettuce;
	public Sprite tomato;
	public Sprite hard_shell;
	public Sprite soft_shell;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.transform.tag == "counter") {
			
			Destroy(this);
		}
	}
}
