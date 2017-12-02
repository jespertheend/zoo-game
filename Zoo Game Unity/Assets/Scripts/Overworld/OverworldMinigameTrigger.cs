using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldMinigameTrigger : MonoBehaviour {

	public string sceneToStart;

	void OnTriggerEnter2D(Collider2D collider){
		OverworldCharacter charScript = collider.gameObject.GetComponent<OverworldCharacter>();
		if(charScript != null){
			SceneManager.LoadScene(sceneToStart);
		}
	}
}
