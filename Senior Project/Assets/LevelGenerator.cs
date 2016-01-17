using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	public int smallDim;

	public List<GameObject> Rooms = new List<GameObject>();
	
	public int levelColumns;
	public int levelRows;
	Vector3 startPos = Vector3.zero;
	Vector3 nextPos;
	int rowCounter;

	Vector3 rayCastOffSet = new Vector3 (0.001f, -1f, 0f);

	LayerMask roomParentLayer;

	// Use this for initialization
	void Start () {
		while (levelRows * levelColumns > 100) {
			levelRows--;
			levelColumns--;
		}
		roomParentLayer = 1 << LayerMask.NameToLayer ("RoomParent");

		for (int i = 0; i < levelColumns; i++) {

			ChooseNextPiece();

			if (i == levelColumns - 1 && rowCounter != levelRows - 1) {
				int num = Random.Range(0,levelColumns);
				nextPos = startPos + Vector3.down * smallDim * (rowCounter+1);
				nextPos += Vector3.left * num * smallDim;
				i = -1;
				rowCounter += 1;
			}
		}
	}
	
	void ChooseNextPiece () {
		int levelPiece = Random.Range (0, Rooms.Count);
		if (Rooms [levelPiece].tag == "SmallRoom") {
			if (CheckSmall ()) {
				CreatePiece(levelPiece);
			} else {
				nextPos += Vector3.right * smallDim;
				ChooseNextPiece();
			}
		} else if (Rooms [levelPiece].tag == "BigRoom") {
			if (CheckLarge ()) {
				CreatePiece(levelPiece);
			} else {
				ChooseNextPiece();
			}
		} else if (Rooms [levelPiece].tag == "VertRoom") {
			if (CheckVert ()) {
				CreatePiece(levelPiece);
			} else {
				ChooseNextPiece();
			}
		} else if (Rooms [levelPiece].tag == "HorzRoom") {
			if (CheckHorz ()) {
				CreatePiece(levelPiece);
			} else {
				ChooseNextPiece();
			}
		}
		
	}
	
	bool CheckSmall () {
		RaycastHit2D hit = Physics2D.Raycast(nextPos + rayCastOffSet, Vector2.right, 1f, roomParentLayer);

		if (hit.collider == null) {
			return true;
		} else {
			return false;
		}
	}
	
	bool CheckLarge () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos + rayCastOffSet, Vector2.right, smallDim, roomParentLayer);	
		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos + rayCastOffSet + Vector3.down * smallDim, Vector2.right, smallDim, roomParentLayer);

		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckVert () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos + rayCastOffSet, Vector2.right, 1f, roomParentLayer);
		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos + rayCastOffSet, Vector2.right, 1f, roomParentLayer);

		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckHorz () {
		RaycastHit2D hit = Physics2D.Raycast(nextPos + rayCastOffSet, Vector2.right, smallDim, roomParentLayer);

		if (hit.collider == null) {
			return true;
		} else {
			return false;
		}
	}
	
	void CreatePiece (int roomPiece) {
		GameObject nextLevelPiece = (GameObject)Instantiate (Rooms [roomPiece], startPos + nextPos, Quaternion.identity);
		nextPos += Vector3.right * nextLevelPiece.transform.localScale.x;
	}
}