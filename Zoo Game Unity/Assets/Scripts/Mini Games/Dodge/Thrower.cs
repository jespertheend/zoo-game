using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    float timer;

    public float intervalOffset = 0f;
    public float interval = 1.5f;

    public List<Sprite> sprites = new List<Sprite>();

	// Use this for initialization
	void Start () {
        timer += intervalOffset;
	}
	
	// Update is called once per frame
	void Update () {

        if (timer >= interval)
        {
			SpawnProjectile(sprites[Random.Range(0, sprites.Count)]);

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
		var collision = projectile.AddComponent<BoxCollider2D>();

		projectile.name = "Poop";

		//projectile.AddComponent<Rigidbody2D>();

		collision.size = new Vector2(0.16f, 0.16f);
		collision.enabled = false;

        renderer.sprite = sprite;
    }
}
