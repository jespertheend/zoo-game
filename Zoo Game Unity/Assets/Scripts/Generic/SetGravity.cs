using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour {

	public Vector3 gravity = new Vector3(0f, -9.81f, 0f);
	public Vector2 gravity2D = new Vector3(0f, -9.81f);

	void Start () {
		Physics.gravity = gravity;
		Physics2D.gravity = gravity2D;
	}
}
