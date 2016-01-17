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

			if (i == levelColumns - 1 && rowCounter != levelRows - 1) {
				int num = Random.Range(0,levelColumns);
				print(num);
				nextPos = startPos + Vector3.down * smallDim * (rowCounter+1);
				nextPos += Vector3.left * num * smallDim;
				print(nextPos);
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
				print("in small");
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
		Debug.DrawRay (nextPos * 1.001f, Vector2.right, Color.black, 5f);
		if (hit.collider == null) {
			return true;
		} else {
			return false;
		}
	}
	
	bool CheckLarge () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, smallDim, roomParentLayer);
		Debug.DrawRay (nextPos * .90f, Vector2.right * smallDim, Color.red, 5f);
	
		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos * 1.001f + Vector3.down * smallDim, Vector2.right, smallDim, roomParentLayer);
		Debug.DrawRay (nextPos * 1.001f + Vector3.down * smallDim, Vector2.right * smallDim, Color.red, 5f);

		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckVert () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		Debug.DrawRay (nextPos * 1f, Vector2.right, Color.blue, 5f);

		RaycastHit2D hitBottom = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, 1f, roomParentLayer);
		Debug.DrawRay (nextPos * 1f, Vector2.right, Color.blue, 5f);

		if (hitTop.collider == null && hitBottom.collider == null) {
			return true;
		} else {
			return false;
		}
	}

	bool CheckHorz () {
		RaycastHit2D hitTop = Physics2D.Raycast(nextPos * 1.001f, Vector2.right, smallDim, roomParentLayer);
		Debug.DrawRay (nextPos * 1.1f, Vector2.right * smallDim, Color.yellow, 5f);
		if (hitTop.collider == null) {
			return true;
		} else {
			return false;
		}
	}
	
	void CreatePiece (int roomPiece) {
		GameObject nextLevelPiece = (GameObject)Instantiate (Rooms [roomPiece], startPos + nextPos, Quaternion.identity);
		//print ("Before   " + nextPos);
		nextPos += Vector3.right * nextLevelPiece.transform.localScale.x;
		//print (nextPos);
	}
}