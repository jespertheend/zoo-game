using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldAnimalAI : MonoBehaviour {

	public Collider2D walkableArea;

	public bool flipXWhenWalking = false;
	public bool invertFlipX = false;

	float lastPosChangeTime;
	float currentPosChangeDelay;
	Vector2 currentWalkTarget;
	SpriteRenderer sprite;

	void Awake(){
		sprite = GetComponent<SpriteRenderer>();
	}

	public void Update(){
		if(Time.time - lastPosChangeTime > currentPosChangeDelay){
			ChangePos();
		}

		Vector2 delta = currentWalkTarget - ((Vector2)transform.position);
		delta = Vector2.ClampMagnitude(delta, Time.deltaTime);
		transform.position += (Vector3)delta;

		if(flipXWhenWalking && delta.magnitude > 0.01){
			sprite.flipX = delta.x > 0;
			if(invertFlipX) sprite.flipX = !sprite.flipX;
		}
	}

	void ChangePos(){
		lastPosChangeTime = Time.time;
		currentPosChangeDelay = Random.Range(4f, 8f);

		Bounds bounds = walkableArea.bounds;
		currentWalkTarget.x = Random.Range(bounds.min.x, bounds.max.x);
		currentWalkTarget.y = Random.Range(bounds.min.y, bounds.max.y);
	}
}
