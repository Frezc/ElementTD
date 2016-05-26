using UnityEngine;
using System.Collections;

public enum TowerType {
    Attack,
    Buff
}

public class Tower : MonoBehaviour {
    public TowerType type = TowerType.Attack;
    public int attack = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
