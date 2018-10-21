using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

	public void changeScene() {
		SceneManager.LoadScene("combination_of_ryan_and_player-pickup");
	}
	
}
