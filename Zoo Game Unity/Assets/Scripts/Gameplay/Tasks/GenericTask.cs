using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericTask : MonoBehaviour {

	public Task myTask;

	public virtual void OnTaskCreated(){}
}
