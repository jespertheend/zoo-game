using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionFood : GenericClickableObject {

	public TaskLionFeed task;

	public override void OnClick(bool fromDown){
		if(fromDown){
			task.MarkTaskAsDone();
			gameObject.SetActive(false);
		}
	}
}
