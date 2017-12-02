using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Vector2 startPosition;
    Vector2 goalPosition;

    public float beginSize = 2.5f;
    public float finalSize = 25f;

    public float minDuration = 1f;
    public float maxDuration = 2f;

    float duration;
    float timer = 0f;

	float turnSpeed;

	float alpha = 1f;

	bool hit = false;

    // Use this for initialization
    void Start () {

        //Setting it's starting transform
        startPosition = transform.position;
        transform.localScale = new Vector2(beginSize, beginSize);
		transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-180f, 180f));

        //Determining the hit goal, 50/50 for either random, or on the players current position
        if (Random.Range(0f, 1f) > 0.5f)
        {
            goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            goalPosition.x = Mathf.Clamp(goalPosition.x, -6.5f, 6.5f);
            goalPosition.y = Mathf.Clamp(goalPosition.y, -1.5f, 1.5f);
        }
        else
        {
            goalPosition = new Vector2(
                Random.Range(-8f, 8f),  //x
                Random.Range(-1f, 3f)   //y
                );                
        }

        //Determining the speed of the projectile
        duration = Random.Range(minDuration, maxDuration);
		turnSpeed = Random.Range(-90f, 90f);
    }
	

	// Update is called once per frame
	void Update () {

        Vector2 newPosition;
        float newScale;

        newPosition = Vector2.Lerp(startPosition, goalPosition, timer / duration);
        newScale = Mathf.Lerp(beginSize, finalSize, timer / duration);

        float halfDuration = duration / 2f;
        float powTwoHalfDur = Mathf.Pow(halfDuration, 2f);
        float heightOffset = (-Mathf.Pow((timer - halfDuration), 2f) + powTwoHalfDur) / powTwoHalfDur * 2f;

        transform.position = newPosition + new Vector2(0f, heightOffset);
        transform.localScale = new Vector2(newScale, newScale);

        timer += Time.deltaTime;

		if (timer > duration)
		{
			if (alpha < 0f)
			{
				Destroy(gameObject);
			}

			alpha -= Time.deltaTime * 2f;
			Color c = new Color(1f, 1f, 1f, alpha);

			GetComponent<SpriteRenderer>().color = c;

			if (hit == false)
			{
				GetComponent<BoxCollider2D>().enabled = true;

				hit = true;
			}
			else
			{
				GetComponent<BoxCollider2D>().enabled = false;
			}
		}
		else
		{
			transform.eulerAngles += new Vector3(0f, 0f, turnSpeed * Time.deltaTime);
		}
	}

    public void Initialize(float startSize, float endSize, float minimumDuration, float maximumDuration)
    {
        beginSize = startSize;
        finalSize = endSize;

        minDuration = minimumDuration;
        maxDuration = maximumDuration;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Player player = collision.collider.gameObject.GetComponent<Player>();
		if (player != null)
		{
			player.Hit();
		}
	}
}
