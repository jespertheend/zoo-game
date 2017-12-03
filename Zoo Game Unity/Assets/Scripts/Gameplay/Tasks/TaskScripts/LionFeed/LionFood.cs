using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionFood : GenericClickableObject {


	public override void OnClick(bool fromDown){
		if(fromDown){
			TaskManager.self.GetComponent<TaskLionFeed>().MarkTaskAsDone();
			gameObject.SetActive(false);
		}
	}
}
