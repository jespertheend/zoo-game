using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

	float timer = 0f;

	public float interval = 0.75f;

	public List<Sprite> sprites = new List<Sprite>();

	int size = 0;
	int index = 0;

	// Use this for initialization
	void Start () {

		size = sprites.Count;

	}
	
	// Update is called once per frame
	void Update () {

		if (timer >= interval)
		{
			timer -= interval;

			index = index == size - 1 ? 0 : index + 1;

			GetComponent<SpriteRenderer>().sprite = sprites[index];
		}

		timer += Time.deltaTime;
	}
}
