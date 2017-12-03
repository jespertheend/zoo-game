using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCharacter : MonoBehaviour {

	Rigidbody2D rb;

	static bool hasLastWorldPosition;
	static Vector3 lastWorldPosition;

	public SpriteRenderer spriteRenderer;
	public ChangeSprite changeSpriteScript;

	public float maxWalkForce = 1f;
	public float walkForceMultiplier = 1f;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start(){
		if(hasLastWorldPosition){
			transform.position = lastWorldPosition;
		}
	}

	void Update() {
		Vector2 force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		force *= walkForceMultiplier;
		force = Vector2.ClampMagnitude(force, maxWalkForce);
		rb.AddForce(force);
		hasLastWorldPosition = true;
		lastWorldPosition = transform.position;
		bool walking = rb.velocity.magnitude > 0.1;
		changeSpriteScript.enabled = walking;
		if(walking){
			spriteRenderer.flipX = rb.velocity.x > 0;
		}
	}
}
