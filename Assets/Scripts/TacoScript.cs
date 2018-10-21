using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoScript : MonoBehaviour {
public BusScript bus;
public Taco taco;
	void Start () {
		taco = ScriptableObject.CreateInstance<Taco>();	
		
	}

	public void addIngredient(int ingedient) {
		switch (ingedient) {
			case 0:
				taco.Beans = true;
				break;
			case 1:
				taco.Meat = true;
				break;
			case 2:
				taco.Lettuce = true;
				break;
			case 3:
				taco.Tomato = true;
				break;
			default:
				break;
		}
	}

	public void addIngredient(string shellType) {
		if (shellType == "soft" || shellType == "SOFT") {
			taco.Shell = Shell.SOFT;
		} else if (shellType == "hard" || shellType == "HARD") {
			taco.Shell = Shell.HARD;
		} else {
			int softOrHARD = Random.Range(0,2);
			if (softOrHARD == 0) {
				taco.Shell = Shell.SOFT;
			} else {
				taco.Shell = Shell.HARD;
			}
		}
	}
}