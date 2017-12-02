using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	GenericClickableObject prevClickScript;

	void Update () {
		GenericClickableObject clickScript = null;
		if(Input.GetMouseButton(0)){
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if(hit.collider != null){
				clickScript = hit.collider.gameObject.GetComponent<GenericClickableObject>();
			}
		}
		if(clickScript != prevClickScript){
			if(prevClickScript != null){
				prevClickScript.FireUnClick();
				prevClickScript = null;
			}
			if(clickScript != null){
				clickScript.FireClick();
				prevClickScript = clickScript;
			}
		}
	}
}
