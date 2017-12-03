using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour {

	public Task[] tasks;
	public List<Task> currentTasks = new List<Task>();

	public float taskSpawnRate = 30f;
	float spawnTimer;

	static public TaskManager self;
	void Awake(){
		self = this;
	}

	void Start(){
		SpawnTask();
	}

	void Update(){
		if(SceneManager.GetActiveScene().name == "Overworld"){
			spawnTimer += Time.deltaTime;
			if(spawnTimer > taskSpawnRate){
				SpawnTask();
			}
		}
	}

	public void SpawnTask(){
		TaskListUI.self.SetTexts();
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
			newTask.taskScript.myTask = newTask;
			newTask.taskScript.OnTaskCreated();
			currentTasks.Add(newTask);
			spawnTimer = 0f;
		}
		TaskListUI.self.ShowUpdate();
	}

	public IEnumerable<string> GetTaskStrings(){
		foreach(Task task in currentTasks){
			for(int i=0; i < task.subTasks.Length; i++){
				string str = task.subTasks[i];
				bool done = task.subTasksDone[i];
				if(done){
					str += "[done]";
				}
				yield return str;
			}
		}
	}

	public void ClearOldTasks(){
		for(int i = currentTasks.Count - 1; i >= 0; i--){
			Task task = currentTasks[i];
			bool allDone = true;
			foreach(bool subTask in task.subTasksDone){
				if(!subTask){
					allDone = false;
					break;
				}
			}
			if(allDone){
				currentTasks.Remove(task);
			}
		}
	}
}

[System.Serializable]
public class Task{
	public GenericTask taskScript;
	public float spawnChance = 1f;
	public string[] subTasks;
	public bool[] subTasksDone;
}