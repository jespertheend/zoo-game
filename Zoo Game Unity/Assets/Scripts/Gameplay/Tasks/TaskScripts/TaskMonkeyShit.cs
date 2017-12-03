using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMonkeyShit : GenericTask {

	static bool finishOnStart = false;

	public GameObject miniGameTriggerObject;

	void Start(){
		if(finishOnStart){
			MarkTaskAsDone();
			finishOnStart = false;
		}
	}

	public override void OnTaskCreated(){
		finishOnStart = true;
		miniGameTriggerObject.SetActive(true);
	}
}
