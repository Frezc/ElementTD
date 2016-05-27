using UnityEngine;
using System.Collections;

public class buildButton : MonoBehaviour {
    public GameObject towerBuilderPrefab;
    public Transform towerBuilderParent;
    private GameObject towerBuilder;
    private bool  show = false ;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick() {
        if (show == false)
        {
            towerBuilder = (GameObject)Instantiate(towerBuilderPrefab, transform.position, Quaternion.identity);
            towerBuilder.transform.parent = towerBuilderParent;
            show = true;
            
        }
        else {
            Destroy(towerBuilder);
            show = false;
        }
    }
}
