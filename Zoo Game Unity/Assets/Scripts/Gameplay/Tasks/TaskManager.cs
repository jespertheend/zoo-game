﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

	public Task[] tasks;
	public List<Task> currentTasks = new List<Task>();

	public float taskSpawnRate = 30f;
	float lastSpawnTime;

	static public TaskManager self;
	void Awake(){
		self = this;
	}

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
			newTask.taskScript.myTask = newTask;
			newTask.taskScript.OnTaskCreated();
			currentTasks.Add(newTask);
			lastSpawnTime = Time.time;
		}
	}

	public IEnumerable<string> GetTaskStrings(){
		foreach(Task task in currentTasks){
			for(int i=0; i < task.subTasks.Length; i++){
				string str = task.subTasks[i];
				bool done = task.subTasksDone[i];
				if(done){

				}
				yield return str;
			}
		}
	}
}

[System.Serializable]
public class Task{
	public enum TaskType { MONKEY_SHIT }
	public GenericTask taskScript;
	public TaskType taskType;
	public float spawnChance = 1f;
	public string[] subTasks;
	public bool[] subTasksDone;
}