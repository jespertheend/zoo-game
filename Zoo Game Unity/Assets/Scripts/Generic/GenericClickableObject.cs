using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericClickableObject : MonoBehaviour {

	public bool isClicking {get; private set;}
	public virtual void OnClick(){}
	public virtual void OnRelease(){}

	public void FireClick(){
		isClicking = true;
		OnClick();
	}

	public void FireUnClick(){
		isClicking = false;
		OnRelease();
	}
}
