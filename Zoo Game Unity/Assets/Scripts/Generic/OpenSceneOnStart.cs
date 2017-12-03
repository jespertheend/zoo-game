using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneOnStart : MonoBehaviour {

	public string sceneToStart;

	void Start(){
		SceneManager.LoadScene(sceneToStart);
	}
}
