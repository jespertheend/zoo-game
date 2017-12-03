using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMonkeyShit : GenericTask {

	public GameObject miniGameTriggerObject;

	public override void OnTaskCreated(){
		miniGameTriggerObject.SetActive(true);
	}
}
