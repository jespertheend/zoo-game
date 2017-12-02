using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCharacter : MonoBehaviour {

	Rigidbody2D rb;

	public float maxWalkForce = 1f;
	public float walkForceMultiplier = 1f;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		Vector2 force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		force *= walkForceMultiplier;
		force = Vector2.ClampMagnitude(force, maxWalkForce);
		rb.AddForce(force);
	}
}
