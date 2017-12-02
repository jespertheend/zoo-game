using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatTower : MonoBehaviour {

	public GameObject goatPrefab;
	public float spawnFrequency = 3f;
	float lastSpawnTime;
	public int towerHeight{
		get{
			return goatsInTower.Count;
		}
	}
	List<GoatTowerGoat> goatsInTower = new List<GoatTowerGoat>();

	static public GoatTower self {get; private set;}
	void Awake(){
		self = this;
	}

	void Start(){
		SpawnGoat();
	}

	void Update(){
		if(Time.time - lastSpawnTime > spawnFrequency){
			SpawnGoat();
		}
	}

	void SpawnGoat(){
		lastSpawnTime = Time.time;
		Instantiate(goatPrefab);
	}

	public void AddGoatToTower(GoatTowerGoat goat){
		goatsInTower.Add(goat);
	}
}
