using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour {
	
	public LevelGenerator levelGen;

	public List<GameObject> miniBosses = new List<GameObject> ();

	public List<GameObject> availSpawnRooms = new List<GameObject> ();

	public Text taskText;


	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		SpawnMiniBoss ();
		taskText = GameObject.Find ("Player UI/TaskImage/TaskText").GetComponent<Text> ();
	}

	void SpawnMiniBoss () {
		foreach (GameObject room in levelGen.availRooms) {
			if (Vector2.Distance(room.transform.position, GameObject.FindGameObjectWithTag("ExitDoor").transform.position) > 40) {
				availSpawnRooms.Add(room);
			}
		}

		int num1 = Random.Range (0, miniBosses.Count);
		if (availSpawnRooms.Count == 0) {
			Instantiate(miniBosses[num1],levelGen.GeneratedRooms[Random.Range(0,levelGen.GeneratedRooms.Count)].transform.position + new Vector3(3,-10,0), Quaternion.identity);
		} else {
			Instantiate(miniBosses[num1], availSpawnRooms[Random.Range(0,availSpawnRooms.Count)].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
		}

		taskText.text = "Slay " + miniBosses [num1].name;
	}
}
