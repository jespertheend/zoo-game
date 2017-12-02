using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatTowerSwipeable : GenericClickableObject {

	public bool isBottomGoat = false;
	public GoatTowerGoat goatScript;
	bool didStartClicking = false;

	public override void OnClick(bool fromDown){
		if(fromDown && isBottomGoat){
			didStartClicking = true;
		}
	}

	public override void OnRelease(bool fromUp){
		if(!fromUp && didStartClicking && Input.GetAxis("Mouse X") > 0){
			goatScript.RemoveFromTower();
		}
		didStartClicking = false;
	}
}
