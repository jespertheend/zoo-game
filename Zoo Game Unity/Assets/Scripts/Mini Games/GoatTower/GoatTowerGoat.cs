﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatTowerGoat : MonoBehaviour {

	int animState = 0;

	Transform spriteTrans;

	void Awake(){
		spriteTrans = transform.GetChild(0);
	}

	void Update () {
		if(animState <= 1){
			spriteTrans.localPosition = Vector3.up * Mathf.Abs(Mathf.Cos(Time.time * 18f)) * 0.04f;
			spriteTrans.localRotation = Quaternion.Euler(0f, 0f, Mathf.Abs(((Time.time * 18f / Mathf.PI) % 2f) - 1f) * 20f - 10f);
		}
		Vector3 pos = transform.position;
		if(animState == 0){
			pos.x += Time.deltaTime * 3f;
			if(pos.x > -0.7f){
				pos.x = -0.7f;
				transform.rotation = Quaternion.Euler(0f, 0f, 90f);
				animState++;
			}
		}
		if(animState == 1){
			pos.y += Time.deltaTime * 3f;
			float maxHeight = GoatTower.self.towerHeight * 0.7f;
			if(pos.y > maxHeight){
				pos.x = 0f;
				pos.y = maxHeight;
				transform.rotation = Quaternion.identity;
				spriteTrans.localPosition = Vector3.zero;
				animState++;
				GoatTower.self.AddGoatToTower(this);
			}
		}

		transform.position = pos;
	}
}
