using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard {
    // 0 empty -1 road
    public int[,] gameBoard = new int[27, 16];
    public List<Vector2> currentSelected = new List<Vector2>();

    public int selectedCount  {
        get { return currentSelected.Count; }
    }

    public static Vector2 transformPos(int c, int r) {
        return new Vector2(c - 15, -r + 6);
    }

    public GameBoard() {
        init();
    }

    public int getAt(int c, int r) {
        return gameBoard[c, r];
    }

    public bool unSelect(int c, int r) {
        for (int i = 0; i < currentSelected.Count; i++) {
            if (currentSelected[i].Equals(new Vector2(c, r))) {
                currentSelected.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public void Select(int c, int r) {
        
        currentSelected.Add(new Vector2(c, r));
    }

    public Vector2? getRandomEmpty() {
        var random = Random.Range(0, 27 * 16);

        var c = random / 16;
        var r = random % 16;
        if (gameBoard[c, r] == 0) {
            return new Vector2(c, r);
        }

        int k = 0;
        for (int i = 0; i < 27 * 16; i++) {
            var ic = i / 16;
            var ir = i % 16;
            if (gameBoard[ic, ir] == 0) {
                if (++k >= random) {
                    return new Vector2(ic, ir);
                }
            }
        }

        if (k == 0) return null;

        var last = random % k;
        k = 0;
        for (int i = 0; i < 27 * 16; i++) {
            var ic = i / 16;
            var ir = i % 16;
            if (gameBoard[ic, ir] == 0) {
                if (++k >= last) {
                    return new Vector2(ic, ir);
                }
            }
        }

        return null;
    }

    void init() {
        for (int i = 0; i <= 3; i++) {
            gameBoard[i, 13] = -1;
        }
        for (int i = 2; i <= 13; i++) {
            gameBoard[4, i] = -1;
        }
        for (int i = 4; i <= 8; i++) {
            gameBoard[i, 2] = -1;
        }
        for (int i = 2; i <= 11; i++) {
            gameBoard[8, i] = -1;
        }
        for (int i = 8; i <= 11; i++) {
            gameBoard[i, 11] = -1;
        }
        for (int i = 5; i <= 11; i++) {
            gameBoard[11, i] = -1;
        }
        for (int i = 11; i <= 14; i++) {
            gameBoard[i, 5] = -1;
        }
        for (int i = 5; i <= 8; i++) {
            gameBoard[14, i] = -1;
        }
        for (int i = 14; i <= 18; i++) {
            gameBoard[i, 8] = -1;
        }
        for (int i = 3; i <= 13; i++) {
            gameBoard[18, i] = -1;
            gameBoard[25, i] = -1;
        }
        for (int i = 18; i <= 25; i++) {
            gameBoard[i, 3] = -1;
            gameBoard[i, 13] = -1;
        }
        gameBoard[26, 8] = -1;
    }
}
