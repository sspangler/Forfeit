﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	public int smallDim;
	public GameObject exitDoor;
	public GameObject exitDoorKey;

	[HideInInspector]
	public List<GameObject> Rooms = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> availRooms = new List<GameObject> ();
	public List<GameObject> availKeyRooms = new List<GameObject> ();
	public int levelColumns;
	public int levelRows;
	Vector3 startPos = Vector3.zero;
	Vector3 nextPos;
	int rowCounter;

	Vector3 rayCastOffSet = new Vector3 (0.001f, -1f, 0f);

	LayerMask roomParentLayer;

	List<GameObject> GeneratedRooms = new List<GameObject>();
	Vector3 playerPos;

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

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerPos = GeneratedRooms[Random.Range(0,GeneratedRooms.Count)].transform.position + new Vector3(3,-10,0);
		player.transform.position = playerPos;

		SpawnExit ();
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
		GeneratedRooms.Add (nextLevelPiece);
	}

	void SpawnExit () {
		foreach (GameObject room in GameObject.FindGameObjectsWithTag("SmallRoom")) {
			if (Vector2.Distance(room.transform.position, playerPos) > 100)
				availRooms.Add(room);
		}
		foreach (GameObject room in GameObject.FindGameObjectsWithTag("BigRoom")) {
			if (Vector2.Distance(room.transform.position, playerPos) > 100)
				availRooms.Add(room);
		}
		foreach (GameObject room in GameObject.FindGameObjectsWithTag("HorzRoom")) {
			if (Vector2.Distance(room.transform.position, playerPos) > 100)
				availRooms.Add(room);
		}
		foreach (GameObject room in GameObject.FindGameObjectsWithTag("VertRoom")) {
			if (Vector2.Distance(room.transform.position, playerPos) > 100)
				availRooms.Add(room);
		}
		Instantiate (exitDoor, availRooms [Random.Range (0, availRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
		SpawnExitKey ();
	}
	
	void SpawnExitKey () {
		foreach (GameObject room in availRooms) {
			if (Vector2.Distance(room.transform.position, GameObject.FindGameObjectWithTag("ExitDoor").transform.position) > 40) {
				availKeyRooms.Add(room);
			}
		}

		if (availKeyRooms == null) {
			Instantiate(exitDoorKey,GeneratedRooms[Random.Range(0,GeneratedRooms.Count)].transform.position + new Vector3(3,-10,0), Quaternion.identity);
		} else {
			Instantiate(exitDoorKey, availKeyRooms[Random.Range(0,availKeyRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
		}
	}
}



