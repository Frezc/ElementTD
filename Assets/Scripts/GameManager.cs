using System;
using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEngine.UI;

public enum GameState {
    Waiting,
    Attacking
}

public class GameManager : MonoBehaviour {
    // 0 empty -1 road
    public GameBoard gameBoard = new GameBoard();
    public string stage = "stage1";

    public Tower AttackTower;
    public Tower BuffTower;

    public Text message;

    public GameState gameState = GameState.Waiting;

    private StageData currentStage;
    private int waveIndex = 0;

    private EnemyManager enemyManager;

    void readDataFromFiles() {
        var sr = new StreamReader(Application.dataPath + "/Scripts/JsonData/" + stage + ".json");
        var fileContents = sr.ReadToEnd();
        sr.Close();

        currentStage = JsonMapper.ToObject<StageData>(fileContents);
//        Debug.Log(currentStage.waves[0].offset);
//        var enemyManager = GetComponent<EnemyManager>();
//        if (enemyManager) {
//            enemyManager.StageData = data[stage];
//        }
    }

    // Use this for initialization
	void Start () {
	    enemyManager = GetComponent<EnemyManager>();
	    enemyManager.OnCompleted += OnWaveCompleted;
        readDataFromFiles();
	}
	
	// Update is called once per frame
	void Update () {
	    var currentWave = currentStage.waves[waveIndex];
	    if (currentWave.offset > 0) {
	        currentWave.offset -= Time.deltaTime;
	        message.text = String.Format("第{0}波在{1:F0}秒后开始", waveIndex + 1, currentWave.offset);
	    } else if (gameState != GameState.Attacking) {
	        gameState = GameState.Attacking;
            message.text = String.Format("第{0}波正在进攻！", waveIndex + 1);
            enemyManager.StartWave(currentWave.monsters);
	    }
	}

    void OnWaveCompleted() {
        gameState = GameState.Waiting;
        if (++waveIndex >= currentStage.waves.Count) {
            GameOver();
        }

    }

    void GameOver() {
        message.text = "游戏结束";
    }
}
