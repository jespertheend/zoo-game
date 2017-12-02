using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour {

	public OverworldCharacter character;
	[Range(0,1)]
	public float cameraSmoothFactor = 0.8f;

	void Update(){
		Vector3 newPos = transform.position;
		newPos = Vector3.Lerp(newPos, character.transform.position, cameraSmoothFactor);
		newPos.z = -10f;
		transform.position = newPos;
	}
}
