using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector2 mousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = Mathf.Clamp(mousePos.x, -6.5f, 6.5f);
        mousePos.y = Mathf.Clamp(mousePos.y, -1.5f, 1.5f);

        transform.position = mousePos;

        transform.up = -(new Vector2(0f - mousePos.x, -20f - mousePos.y).normalized);
	}
}
