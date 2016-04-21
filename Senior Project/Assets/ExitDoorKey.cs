using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitDoorKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
			GameObject.Find("GameManager/Player UI/TaskText").GetComponent<Text>().text = "Task Complete!";
			Destroy (this.gameObject);
		}
	}
}