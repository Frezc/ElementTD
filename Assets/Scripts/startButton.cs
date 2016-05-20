using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {
    public void MENU_ACTION_GotoPage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
