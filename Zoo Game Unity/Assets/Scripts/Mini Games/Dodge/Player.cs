using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform background;
	public Transform monkeys;

	public Transform thrower1;
	public Transform thrower2;

	Vector2 mousePos;

	public Sprite frame1;
	public Sprite frame2;

	bool spriteIndex = true;

	SpriteRenderer child;


	float timer;
	public float duration = 0.75f;

	public float scaleDif = 0.1f;
	public float posDif = 0.5f;

	float hitTimer = 0f;

	Collider2D col;

	Color brown = new Color(0.46f, 0.29f, 0.22f);

	public float goal = 20f;

	// Use this for initialization
	void Start () {
		child = GetComponentInChildren<SpriteRenderer>();
		col = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update () {
		if (goal < 0f)
		{
			//End minigame code here
		}

		background.position = Vector2.Lerp(new Vector2(0f, -7.5f), new Vector2(0f, 0f), goal / 20f);
		background.position += new Vector3(0f, 0f, 10f);
		background.localScale = Vector2.Lerp(new Vector2(50f, 55f), new Vector2(19f, 21f), goal / 20f);

		monkeys.position = Vector2.Lerp(new Vector2(0f, 1.91f), new Vector2(0f, 4.5f), goal / 20f);
		monkeys.position += new Vector3(0f, 0f, 5f);
		monkeys.localScale = Vector2.Lerp(new Vector2(35f, 40f), new Vector2(8f, 9f), goal / 20f);

		thrower1.position = Vector2.Lerp(new Vector2(-1.24f, 0.14f), new Vector2(-0.7f, 4.16f), goal / 20f);
		thrower2.position = Vector2.Lerp(new Vector2(3.27f, 1.63f), new Vector2(0.8f, 4.16f), goal / 20f);

		if (hitTimer > 0f)
		{
			transform.localScale = new Vector2(1f + 0.2f * hitTimer, 1f + 0.2f * hitTimer);
			transform.up = new Vector3(0f, 1f, 0f);
			transform.position = new Vector3(0f, 0f - 2 * hitTimer, 0f);

			hitTimer -= Time.deltaTime;

			child.color = Color.Lerp(brown, Color.white, 1f - hitTimer);

			goal += 4.0f * Time.deltaTime;

			return;
		}

		col.enabled = true;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = Mathf.Clamp(mousePos.x, -6.5f, 6.5f);
        mousePos.y = Mathf.Clamp(mousePos.y, -1.5f, 0.85f);

        transform.up = -(new Vector2(0f - mousePos.x, -20f - mousePos.y).normalized);

		Vector3 pos = mousePos;

		transform.position = pos + transform.up * Mathf.Lerp(0f, posDif, timer/duration);

		transform.localScale = (1 - Mathf.Lerp(0f, scaleDif, timer / duration)) * new Vector2(1f, 1f);


		if (timer >= duration)
		{
			child.sprite = (spriteIndex == true) ? frame2 : frame1;
			spriteIndex = (spriteIndex == true) ? false : true;

			goal -= 0.15f;
			timer -= duration;
		}

		timer += Time.deltaTime;
		goal -= Time.deltaTime;
	}

	public void Hit()
	{
		hitTimer = 1f;
		col.enabled = false;
	}
}
