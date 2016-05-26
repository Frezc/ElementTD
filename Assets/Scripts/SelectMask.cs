using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectMask : MonoBehaviour {
    public Transform indicator;

    [Range(0, 9)]
    public int maxSelected = 1;

    private GameManager manager;
    public List<Transform> indicatorPool = new List<Transform>(9);

	// Use this for initialization
	void Start () {
	    manager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    captureClick();
	}

    void captureClick() {
        if (Input.GetMouseButtonDown(0)) {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var column = (int)Mathf.Floor(pos.x + 15);
            var row = (int)Mathf.Floor(-pos.y + 8);
            if (!manager.gameBoard.unSelect(column, row)) {
                if (canSelected(column, row)) {
                    manager.gameBoard.Select(column, row);
                }
            }

            updateIndicator();
        }
    }

    void updateIndicator() {
        var currentSelected = manager.gameBoard.currentSelected;
//        Debug.Log(currentSelected);
        int i;
        for (i = 0; i < currentSelected.Count; i++) {
            var c = currentSelected[i];
            var x = c.x - 15 + .5f;
            var y = -c.y + 7 + .5f;
            if (indicatorPool.Count <= i) {
                indicatorPool.Add((Transform) Instantiate(indicator, new Vector3(x, y, -9), Quaternion.identity));
            } else {
                indicatorPool[i].gameObject.SetActive(true);
                indicatorPool[i].position = new Vector3(x, y, -9);
            }
        }

        if (i < indicatorPool.Count) {
            for (;i < indicatorPool.Count; i++) {
                indicatorPool[i].gameObject.SetActive(false);
            }
        }
    }

    bool canSelected(int c, int r) {
        if (manager.gameBoard.selectedCount < maxSelected) {
            if (c >= 0 && c < 27 && r >= 0 && r < 16) {
                return manager.gameBoard.getAt(c, r) != -1;
            }
        }

        return false;
    }
}
