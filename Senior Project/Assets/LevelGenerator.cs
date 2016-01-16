using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public List<GameObject> Rooms = new List<GameObject>();

	public int levelColumns;
	public int levelRows;
	Vector3 startPos = Vector3.zero;
	Vector3 nextYPos;
	Vector3 nextXPos;
	int rowCounter;
	Vector3 topRight;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < levelColumns; i++) {
			RaycastHit2D hit = Physics2D.Raycast (topRight, Vector2.right, 1f);
			if (!hit) { //didnt hit something
				
				int levelPiece = Random.Range (0, Rooms.Count - 1);
				GameObject nextLevelPiece = (GameObject)Instantiate (Rooms [levelPiece], startPos + nextXPos, Quaternion.identity);
				nextXPos += Vector3.right * nextLevelPiece.transform.GetChild (0).localScale.x;

				if (i == levelColumns - 1 && rowCounter != levelRows - 1) {
					nextXPos = (startPos + (Vector3.down * (rowCounter + 1))) * nextLevelPiece.transform.localScale.x;
					i = -1;
					rowCounter += 1;
				}
			} else { //hit something
				nextXPos += Vector3.right * hit.transform.localScale.x;
			}
		}
	}

	void OnLevelWasLoaded () {
		
	}
}
