using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

	public Task[] availableTasks;
	public List<Task> currentTasks = new List<Task>();

	public float taskSpawnRate = 30f;
	float lastSpawnTime;

	void Start(){
		SpawnTask();
	}

	void Update(){
		if(Time.time - lastSpawnTime > taskSpawnRate){
			SpawnTask();
		}
	}

	public void SpawnTask(){
		Task newTask = GetRandomTask();
		if(newTask != null){
			currentTasks.Add(newTask);
			lastSpawnTime = Time.time;
		}
	}

	public Task GetRandomTask(){
		float totalSpawnChange = 0f;
		foreach(Task task in availableTasks){
			totalSpawnChange += task.spawnChance;
		}
		totalSpawnChange *= Random.value;

		float totalSpawnChange2 = 0f;
		foreach(Task task in availableTasks){
			totalSpawnChange2 += task.spawnChance;
			if(totalSpawnChange2 > totalSpawnChange){
				return task;
			}
		}
		return null;
	}
}

[System.Serializable]
public class Task{
	public enum TaskType { MONKEY_SHIT }
	public TaskType taskType;
	public float spawnChance = 1f;
	public string[] subTasks;
	public bool[] tasksDone;
}