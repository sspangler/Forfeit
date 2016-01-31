using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

	public List<GameObject> enemies = new List<GameObject>();

	[HideInInspector]
	public List<GameObject> EnemyRooms = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	int numToSpawn;
	public void Spawn () {
		foreach (GameObject room in EnemyRooms) {
			float xScale = room.transform.localScale.x;
			float yScale = room.transform.localScale.y;
			if (room.tag == "BigRoom")
				numToSpawn = 8;
			else if (room.tag == "HorzRoom" || room.tag == "VertRoom")
				numToSpawn = 5;
			else if (room.tag == "SmallRoom")
				numToSpawn = 3;

			for (int i = 0; i < numToSpawn; i++) {
				Vector3 rndPosWithin;
				rndPosWithin = new Vector3 (Random.Range (0, xScale), Random.Range (-yScale, 0), 0);
				rndPosWithin += room.transform.position;
				Instantiate (enemies [Random.Range (0, enemies.Count)], rndPosWithin, Quaternion.identity);
			}
		}
	}
}
