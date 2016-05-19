using UnityEngine;
using System.Collections;

public class ClickMask : MonoBehaviour {
    public Transform indicator;

    private GameManager manager;

	// Use this for initialization
	void Start () {
	    manager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    locateIndicator();
	}

    void locateIndicator() {
        if (Input.GetMouseButtonDown(0)) {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var column = (int)Mathf.Floor(pos.x + 15);
            var row = (int)Mathf.Floor(-pos.y + 8);
            if (canSelected(column, row)) {
                var x = Mathf.Floor(pos.x) + .5f;
                var y = Mathf.Floor(pos.y) + .5f;
                indicator.position = new Vector3(x, y, -9);
            }
        }
    }

    bool canSelected(int c, int r) {
        if (c >= 0 && c < 27 && r >= 0 && r < 16) {
            return manager.gameBoard[c, r] != -1;
        }

        return false;
    }
}
