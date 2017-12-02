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

    // Use this for initialization
    void Start () {

        //Setting it's starting position and scale
        startPosition = transform.position;
        transform.localScale = new Vector2(beginSize, beginSize);

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
	}

    public void Initialize(float startSize, float endSize, float minimumDuration, float maximumDuration)
    {
        beginSize = startSize;
        finalSize = endSize;

        minDuration = minimumDuration;
        maxDuration = maximumDuration;
    }
}
