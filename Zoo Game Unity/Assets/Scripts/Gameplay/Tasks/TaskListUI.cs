using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListUI : MonoBehaviour {

	public RectTransform listRect;
	public float animationSpeed = 1f;
	public Color textColor;
	public Font font;

	float animationTime = 0f;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			SetTexts();
		}
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

	void SetTexts(){
		foreach(Transform child in listRect){
			Destroy(child.gameObject);
		}
		foreach(string item in TaskManager.self.GetTaskStrings()){
			GameObject spawned = new GameObject("list item");
			spawned.transform.parent = listRect;
			RectTransform rect = spawned.AddComponent<RectTransform>();
			rect.sizeDelta = new Vector2(0f, 50f);
			spawned.transform.localScale = Vector3.one;
			Text text = spawned.AddComponent<Text>();
			text.text = item;
			text.color = textColor;
			text.resizeTextForBestFit = true;
			text.font = font;
			text.supportRichText = true;
		}
	}
}
