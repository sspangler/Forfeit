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

	LayerMask roomParentLayer;

	// Use this for initialization
	void Start () {

		roomParentLayer = 1 << LayerMask.NameToLayer ("RoomParent");

		for (int i = 0; i < levelColumns; i++) {

			ChooseNextPiece();

//			RaycastHit2D hit = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, .1f, roomParentLayer);
//			if (hit.collider != null) {
//				print(hit.transform.name + "  " + i);
//			} else {
//				print ("nothing " + i);
//			}

	
			if (i == levelColumns - 1 && rowCounter != levelRows - 1) {
				nextPos = startPos + Vector3.down * smallDim;
				i = -1;
				rowCounter += 1;
			}
		}
	}
	
	void ChooseNextPiece () {
		int levelPiece = Random.Range (0, Rooms.Count - 1);
		print (Rooms [levelPiece].tag);
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
		RaycastHit2D hit = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		if (hit.collider == null) {
			return true;
		} else {
			return false;
		}
	}
	
	bool CheckLarge () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckVert () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckHorz () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		if (hitTop.collider == null) {
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