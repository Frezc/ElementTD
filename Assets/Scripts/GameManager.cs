using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // 0 empty -1 road
    public int[,] gameBoard = new int[27,16];

    // Use this for initialization
	void Start () {
        for (int i = 0; i <= 3;i++ )
        {
            gameBoard[i, 13] = -1;
        }
        for (int i = 2; i <= 13; i++)
        {
            gameBoard[4, i] = -1;
        }
        for (int i = 4; i <= 8; i++)
        {
            gameBoard[i, 2] = -1;
        }
        for (int i = 2; i <= 11; i++)
        {
            gameBoard[8, i] = -1;
        }
        for (int i = 8; i <= 11; i++)
        {
            gameBoard[i, 11] = -1;
        }
        for (int i = 5; i <= 11; i++)
        {
            gameBoard[11, i] = -1;
        }
        for (int i = 11; i <= 14; i++)
        {
            gameBoard[i, 5] = -1;
        }
        for (int i = 5; i <= 8; i++)
        {
            gameBoard[14, i] = -1;
        }
        for (int i = 14; i <= 18; i++)
        {
            gameBoard[i, 8] = -1;
        }
        for (int i = 3; i <= 13; i++)
        {
            gameBoard[18, i] = -1;
            gameBoard[25, i] = -1;
        }
        for (int i = 18; i <= 25; i++)
        {
            gameBoard[i, 3] = -1;
            gameBoard[i, 13] = -1;
        }
        gameBoard[26, 8] = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
