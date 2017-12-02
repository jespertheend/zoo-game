using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    float timer;

    public float intervalOffset = 0f;
    public float interval = 2f;

    public List<Sprite> sprites = new List<Sprite>();

	// Use this for initialization
	void Start () {
        timer += intervalOffset;
	}
	
	// Update is called once per frame
	void Update () {

        if (timer >= interval)
        {
            SpawnProjectile(sprites[0]);

            timer -= interval;
        }

        timer += Time.deltaTime;
     }

    void SpawnProjectile (Sprite sprite)
    {
        GameObject projectile = new GameObject();

        projectile.transform.position = transform.position;
        projectile.AddComponent<Projectile>();
        var renderer = projectile.AddComponent<SpriteRenderer>();

        renderer.sprite = sprite;
        renderer.color = Color.blue;
    }
}
