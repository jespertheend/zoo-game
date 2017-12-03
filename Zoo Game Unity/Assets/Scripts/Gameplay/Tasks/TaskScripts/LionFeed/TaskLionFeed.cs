using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLionFeed : GenericTask {

	public GameObject foodObject;

	public override void OnTaskCreated(){
		foodObject.SetActive(true);
	}
}
