using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericClickableObject : MonoBehaviour {

	public bool isClicking {get; private set;}
	public virtual void OnClick(bool cameFromOnDown){}
	public virtual void OnRelease(bool cameFromOnUp){}

	public void FireClick(bool cameFromOnDown){
		isClicking = true;
		OnClick(cameFromOnDown);
	}

	public void FireUnClick(bool cameFromOnUp){
		isClicking = false;
		OnRelease(cameFromOnUp);
	}
}
