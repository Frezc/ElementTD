﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int hp = 100;
    public int speed = 1;
    public int currentHp = 100;
	// Use this for initialization
	void Start () {
        currentHp = hp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
