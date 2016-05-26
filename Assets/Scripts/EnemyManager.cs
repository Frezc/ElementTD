using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using SimpleJson;

public delegate void OnCompleted();

public class EnemyManager : MonoBehaviour {

    public Transform enemy;
    public OnCompleted OnCompleted;

    private static Vector2 spawnLocation = new Vector2(-14.5f, -5.5f);

    private Queue<MonsterData> currentWave = null;
    private Transform enemyGroup;

    public void StartWave(List<MonsterData> wave) {
        currentWave = new Queue<MonsterData>(wave);
    }

	// Use this for initialization
	void Start () {
	    enemyGroup = new GameObject("EnemyGroup").transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if (currentWave != null) {
	        while (currentWave.Count > 0 && currentWave.Peek().offset <= 0) {
	            var monster = currentWave.Dequeue();
	            var newEnemy = (Transform)Instantiate(enemy, spawnLocation, Quaternion.identity);
                newEnemy.SetParent(enemyGroup);

            }

	        if (currentWave.Count > 0) {
	            currentWave.Peek().offset -= Time.deltaTime;
            }

            if (currentWave.Count <= 0 && enemyGroup.childCount <= 0) {
	            OnCompleted.Invoke();
	            currentWave = null;
	        }
        }
    }
}
