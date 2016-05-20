using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {
    public void MENU_ACTION_GotoPage(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
