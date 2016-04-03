using UnityEngine;
using System.Collections;

public class Tasks : MonoBehaviour {
	
	public LevelGenerator levelGen;
	public GameObject taskText;

	// Use this for initialization
	void Start () {
		levelGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelGenerator> ();
		taskText = GameObject.Find ("Player UI/TaskImage/TaskText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
