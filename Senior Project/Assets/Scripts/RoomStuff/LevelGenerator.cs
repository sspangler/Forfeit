using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelGenerator : MonoBehaviour {
	public int smallDim;
	public GameObject exitDoor;
	public GameObject exitDoorKey;

	List<GameObject> tier1Rooms, tier2Rooms, tier3Rooms, tier4Rooms, tier5Rooms;

	public List<GameObject> Rooms; //list of rooms that can be spawned
	public List<GameObject> tasks = new List<GameObject>(); //list of tasks that can be chosen to open the gate without penilty
	[HideInInspector] public List<GameObject> GeneratedRooms = new List<GameObject>(); // rooms that are in this level
	public List<GameObject> availRooms = new List<GameObject> (); //rooms that the exit can be put into
	public int levelColumns;
	public int levelRows;
	Vector3 nextPos;

	Vector3 rayCastOffSet = new Vector3 (0.001f, -1f, 0f);
	LayerMask roomParentLayer;
	Vector3 playerPos;

	SpawnEnemies spawnEnemies;

	void Start () {
		spawnEnemies = GetComponent<SpawnEnemies> ();
		tier1Rooms = Resources.LoadAll<GameObject> ("Rooms/Tier1").ToList ();
		tier2Rooms = Resources.LoadAll<GameObject> ("Rooms/Tier2").ToList ();
		tier3Rooms = Resources.LoadAll<GameObject> ("Rooms/Tier3").ToList ();
		tier4Rooms = Resources.LoadAll<GameObject> ("Rooms/Tier4").ToList ();
		tier5Rooms = Resources.LoadAll<GameObject> ("Rooms/Tier5").ToList ();
	}

	void OnLevelWasLoaded () {
		int rowCounter = 0;
		nextPos = Vector3.zero;
		availRooms.Clear ();
		GeneratedRooms.Clear ();

		int diffLevel = GetComponent<DifficultyModifier> ().difModifier;

		if (diffLevel == 1) {
			Rooms.AddRange (tier1Rooms);
			Rooms.AddRange (tier2Rooms);
		} else if (diffLevel == 2) {
			Rooms.AddRange (tier1Rooms);
			Rooms.AddRange (tier2Rooms);
			Rooms.AddRange (tier3Rooms);
		} else if (diffLevel == 3) {
			Rooms.AddRange (tier2Rooms);
			Rooms.AddRange (tier3Rooms);
			Rooms.AddRange (tier4Rooms);
		} else if (diffLevel == 4) {
			Rooms.AddRange (tier3Rooms);
			Rooms.AddRange (tier4Rooms);
			Rooms.AddRange (tier5Rooms);
		} else {
			Rooms.AddRange (tier4Rooms);
			Rooms.AddRange (tier5Rooms);
		}

		while (levelRows * levelColumns > 100) {
			levelRows--;
			levelColumns--;
		}
		roomParentLayer = 1 << LayerMask.NameToLayer ("RoomParent");
		
		for (int i = 0; i < levelColumns; i++) {
			
			ChooseNextPiece();
			
			if (i == levelColumns - 1 && rowCounter != levelRows - 1) {
				int num = Random.Range(0,levelColumns);
				nextPos = Vector3.down * smallDim * (rowCounter+1);
				nextPos += Vector3.left * num * smallDim;
				i = -1;
				rowCounter += 1;
			}
		}
		
		PlacePlayer ();
		SpawnExit ();


		int num1 = Random.Range (0, tasks.Count);
		Instantiate (tasks [num1]);
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
		GameObject nextLevelPiece = (GameObject)Instantiate (Rooms [roomPiece], nextPos, Quaternion.identity);
		nextPos += Vector3.right * nextLevelPiece.transform.localScale.x;
		GeneratedRooms.Add (nextLevelPiece);
	}

	void PlacePlayer () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		int num1 = Random.Range (0, GeneratedRooms.Count);
		GameObject chosenRoom = GeneratedRooms [num1];

		Vector2 roomPos = chosenRoom.transform.position;
		Vector2 offset = chosenRoom.GetComponent<BoxCollider2D>().offset;

		offset.Scale (chosenRoom.transform.localScale);
		playerPos = offset + roomPos;
		player.transform.position = playerPos;

		GeneratedRooms.RemoveAt (num1);
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
		if (availRooms.Count != 0)
			Instantiate (exitDoor, availRooms [Random.Range (0, availRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
		else
			Instantiate (exitDoor, GeneratedRooms [Random.Range (0, availRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
	}


	bool CheckTopLeft (GameObject room) {
		RaycastHit2D hitLeft = Physics2D.Raycast(room.transform.position + Vector3.down * smallDim, Vector2.left, smallDim, roomParentLayer);	

		if (hitLeft.collider == null)
			return true;
		else 
			return false;
	}

	bool CheckTopRight (GameObject room) {
		RaycastHit2D hitRight = Physics2D.Raycast(room.transform.position + Vector3.down * smallDim, Vector2.right, smallDim, roomParentLayer);	

		if (hitRight.collider == null)
			return true;
		else 
			return false;
	}

	bool CheckBotLeft (GameObject room) {
		RaycastHit2D hitBotLeft = Physics2D.Raycast(room.transform.position + Vector3.down * smallDim * 2, Vector2.left, smallDim, roomParentLayer);	

		if (hitBotLeft.collider == null)
			return true;
		else 
			return false;
	
	}

	bool CheckBotRight (GameObject room) {
		RaycastHit2D hitBotRight = Physics2D.Raycast(room.transform.position + Vector3.down * smallDim * 2, Vector2.right, smallDim, roomParentLayer);	

		if (hitBotRight.collider == null)
			return true;
		else 
			return false;
	}
}