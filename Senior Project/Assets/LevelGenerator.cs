using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {


	public int levelColumns;
	public int levelRows;
	Vector3 startPos = Vector3.zero;
	Vector3 nextYPos;
	Vector3 nextXPos;
	public GameObject levelPiece;
	int rowCounter;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < levelColumns; i++) {
			Instantiate (levelPiece, startPos + nextXPos, Quaternion.identity);
			nextXPos += Vector3.right;
		}
	}

	void OnLevelWasLoaded () {
		
	}
}
