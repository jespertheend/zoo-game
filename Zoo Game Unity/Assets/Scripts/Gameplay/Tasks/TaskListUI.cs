using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListUI : MonoBehaviour {

	public RectTransform listRect;
	public float animationSpeed = 1f;

	float animationTime = 0f;

	void Update(){
		if(Input.GetKey(KeyCode.Tab)){
			animationTime += Time.deltaTime * animationSpeed;
		}else{
			animationTime -= Time.deltaTime * animationSpeed;
		}
		animationTime = Mathf.Clamp01(animationTime);

		float t = animationTime;
		float w = listRect.sizeDelta.x;
		listRect.anchoredPosition = Vector2.left * (t * w - w);
	}
}
