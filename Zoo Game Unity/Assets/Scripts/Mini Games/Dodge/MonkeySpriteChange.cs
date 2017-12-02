using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpriteChange : MonoBehaviour {

	public Sprite frame1;
	public Sprite frame2;

	SpriteRenderer rend;

	float timer = 0f;

	bool sprite = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();

		rend.sprite = frame1;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (timer >= 0.75f)
		{
			rend.sprite = sprite ? frame1 : frame2;
			sprite = sprite ? false : true;

			timer -= 0.75f;
		}

		timer += Time.deltaTime;
	}
}
