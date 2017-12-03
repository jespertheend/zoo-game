using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMonkeyShit : GenericTask {

	public override void OnTaskCreated(){
		SetColliderEnabled(true);
	}

	void SetColliderEnabled(bool e){
		GameObject.Find("dodgeMiniGameTrigger").GetComponent<Collider2D>().enabled = e;
	}
}
