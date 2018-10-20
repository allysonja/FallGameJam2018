using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[SerializeField]
public enum Shell {SOFT, HARD}

public class Taco : ScriptableObject {
	public int OrderNum;
	public Shell Shell;
	public bool Meat;
	public bool Beans;
	public bool Lettuce;
	public bool Tomato;
}
