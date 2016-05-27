using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class blood : MonoBehaviour {
    public GameObject enemyPrefab;
    public float maxHealth;
    public Slider hpBar;
    public float currentHealth ;
    
	// Use this for initialization
	void Start () {
        maxHealth = enemyPrefab.GetComponent<Enemy>().hp;
        currentHealth = enemyPrefab.GetComponent<Enemy>().hp;
        hpBar.maxValue = maxHealth;
        hpBar.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        hpBar.value = enemyPrefab.GetComponent<Enemy>().currentHp;
	}
}
