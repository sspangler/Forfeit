using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClearRoom : MonoBehaviour {
	public LevelGenerator levelGen;
	public List<GameObject> availClearRooms = new List<GameObject> ();
	public Text taskText;

	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		taskText = GameObject.Find ("Player UI/TaskImage/TaskText").GetComponent<Text> ();
		taskText.text = "Clear the designated room";
		SelectRooms ();
	}

	void SelectRooms () {
		foreach (GameObject room in levelGen.availRooms) {
			if (Vector2.Distance(room.transform.position, GameObject.FindGameObjectWithTag("ExitDoor").transform.position) > 40) {
				availClearRooms.Add(room);
			}
		}

		if (availClearRooms.Count == 0) {
			int num1 = Random.Range (0, levelGen.GeneratedRooms.Count);
			availClearRooms [num1].gameObject.AddComponent <EnemyCounter>();
		} else {
			int num2 = Random.Range (0, availClearRooms.Count);
			availClearRooms [num2].gameObject.AddComponent <EnemyCounter>();
		}
	}
}
