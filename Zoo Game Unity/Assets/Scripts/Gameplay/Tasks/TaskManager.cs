using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

	public Task[] tasks;
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
		Task newTask = null;
		List<Task> availableTasks = new List<Task>();
		foreach(Task task in tasks){
			if(!currentTasks.Contains(task)){
				availableTasks.Add(task);
			}
		}
		float totalSpawnChange = 0f;
		foreach(Task task in availableTasks){
			totalSpawnChange += task.spawnChance;
		}
		totalSpawnChange *= Random.value;

		float totalSpawnChange2 = 0f;
		foreach(Task task in availableTasks){
			totalSpawnChange2 += task.spawnChance;
			if(totalSpawnChange2 > totalSpawnChange){
				newTask = task;
				break;
			}
		}
		if(newTask != null){
			newTask.subTasksDone = new bool[newTask.subTasks.Length];
			GameObject spawned = Instantiate(newTask.taskScriptPrefab);
			GenericTask taskScript = spawned.GetComponent<GenericTask>();
			taskScript.myTask = newTask;
			currentTasks.Add(newTask);
			lastSpawnTime = Time.time;
		}
	}
}

[System.Serializable]
public class Task{
	public enum TaskType { MONKEY_SHIT }
	public GameObject taskScriptPrefab;
	public TaskType taskType;
	public float spawnChance = 1f;
	public string[] subTasks;
	public bool[] subTasksDone;
}