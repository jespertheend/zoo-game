using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListUI : MonoBehaviour {

	public RectTransform listRect;
	public RectTransform contentRect;
	public float animationSpeed = 1f;
	public Color textColor;
	public Color textColorDone;
	public Font font;

	bool isShowingUpdate = false;
	bool didShowUpdateSetText = false;
	float showUpdateTimer;

	float animationTime = 0f;

	static public TaskListUI self {get; private set;}
	void Awake(){
		self = this;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			SetTexts();
		}
		if(isShowingUpdate){
			showUpdateTimer += Time.deltaTime;
			if(showUpdateTimer > 0.5f && !didShowUpdateSetText){
				SetTexts();
				didShowUpdateSetText = true;
			}
			if(showUpdateTimer > 1f){
				isShowingUpdate = false;
			}
		}
		if(Input.GetKey(KeyCode.Tab) || isShowingUpdate){
			animationTime += Time.deltaTime * animationSpeed;
		}else{
			animationTime -= Time.deltaTime * animationSpeed;
		}
		animationTime = Mathf.Clamp01(animationTime);

		float t = animationTime;
		float w = listRect.sizeDelta.x;
		listRect.anchoredPosition = new Vector2(-1f, 1f) * (t * w - w);
	}

	public void SetTexts(){
		foreach(Transform child in contentRect){
			Destroy(child.gameObject);
		}
		foreach(string item in TaskManager.self.GetTaskStrings()){
			string itemText = item;
			bool done = itemText.EndsWith("[done]");
			if(done){
				itemText = itemText.Substring(0, itemText.Length - 6);
			}
			GameObject spawned = new GameObject("list item");
			spawned.transform.parent = contentRect;
			RectTransform rect = spawned.AddComponent<RectTransform>();
			rect.sizeDelta = new Vector2(0f, 50f);
			rect.localRotation = Quaternion.identity;
			spawned.transform.localScale = Vector3.one;
			Text text = spawned.AddComponent<Text>();
			text.text = itemText;
			text.color = done ? textColorDone : textColor;
			text.font = font;
			text.fontSize = 12;
			text.supportRichText = true;
		}
		TaskManager.self.ClearOldTasks();
	}

	public void ShowUpdate(){
		isShowingUpdate = true;
		didShowUpdateSetText = false;
		showUpdateTimer = 0f;
	}
}
