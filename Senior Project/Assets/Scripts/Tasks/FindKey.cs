using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FindKey : MonoBehaviour {

	public LevelGenerator levelGen;

	public List<GameObject> availKeyRooms = new List<GameObject> ();

	public GameObject exitDoorKey;

	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		SpawnExitKey ();
	}

	void SpawnExitKey () {
		foreach (GameObject room in levelGen.availRooms) {
			if (Vector2.Distance(room.transform.position, GameObject.FindGameObjectWithTag("ExitDoor").transform.position) > 40) {
				availKeyRooms.Add(room);
			}
		}

		if (availKeyRooms.Count == 0) {
			Instantiate(exitDoorKey,levelGen.GeneratedRooms[Random.Range(0,levelGen.GeneratedRooms.Count)].transform.position + new Vector3(3,-10,0), Quaternion.identity);
		} else {
			Instantiate(exitDoorKey, availKeyRooms[Random.Range(0,availKeyRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
		}
	}
}
