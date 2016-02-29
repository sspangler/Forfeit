using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyObjects : MonoBehaviour {
	
	public LevelGenerator levelGen;

	public GameObject desObj;

	public List<GameObject> availSpawnRooms = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		SpawnDesObj ();
	}

	void SpawnDesObj () {
		foreach (GameObject room in levelGen.availRooms) {
			if (Vector2.Distance(room.transform.position, GameObject.FindGameObjectWithTag("ExitDoor").transform.position) > 40) {
				availSpawnRooms.Add(room);
			}
		}

		for (int i = 0; i < 4; i++) {
			if (availSpawnRooms.Count == 0) {
				int num1 = Random.Range (0, levelGen.GeneratedRooms.Count);
				Instantiate (desObj, levelGen.GeneratedRooms [num1].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
				levelGen.GeneratedRooms.RemoveAt (num1);
			} else {
				int num2 = Random.Range (0, availSpawnRooms.Count);
				Instantiate (desObj, availSpawnRooms [num2].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
				availSpawnRooms.RemoveAt (num2);
			}
		}
	}
}