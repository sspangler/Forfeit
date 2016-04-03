using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DestroyObjects : MonoBehaviour {
	
	public LevelGenerator levelGen;

	public GameObject desObj;

	public List<GameObject> availSpawnRooms = new List<GameObject> ();

	public int objsLeft;

	public Text taskText;

	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		SpawnDesObj ();
		taskText = GameObject.Find ("Player UI/TaskImage/TaskText").GetComponent<Text> ();
		taskText.text = "Destroy the " + objsLeft + " " + desObj.name;
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
				GameObject obj = (GameObject) Instantiate (desObj, levelGen.GeneratedRooms [num1].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
				levelGen.GeneratedRooms.RemoveAt (num1);
				obj.tag = "DestroyTaskObj";
				obj.GetComponent<DestructableObj> ().desObj = this;
				obj.GetComponent<DestructableObj> ().taskRelated = true;
			} else {
				int num2 = Random.Range (0, availSpawnRooms.Count);
				GameObject obj = (GameObject) Instantiate (desObj, availSpawnRooms [num2].transform.position + new Vector3 (3, -10, 0), Quaternion.identity);
				availSpawnRooms.RemoveAt (num2);
				obj.tag = "DestroyTaskObj";
				obj.GetComponent<DestructableObj> ().desObj = this;
				obj.GetComponent<DestructableObj> ().taskRelated = true;
			}
		}
	}
}