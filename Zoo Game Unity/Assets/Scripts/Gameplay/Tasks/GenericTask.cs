using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericTask : MonoBehaviour {

	public Task myTask;

	public virtual void OnTaskCreated(){}

	public void MarkTaskAsDone(int subTaskId=0){
		TaskListUI.self.SetTexts();
		myTask.subTasksDone[subTaskId] = true;
		// bool allDone = true;
		// foreach(bool sub in myTask.subTasksDone){
		// 	if(!sub){
		// 		allDone = false;
		// 		break;
		// 	}
		// }
		// if(allDone){

		// }
		TaskListUI.self.ShowUpdate();
	}
}
