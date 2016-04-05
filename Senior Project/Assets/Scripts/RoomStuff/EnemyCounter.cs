using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour {

	public int enemyNum;
	public ClearRoom clearRoom;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild(i).transform.tag == "Enemy") {
				enemyNum++;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (enemyNum == 0) {
			clearRoom.TaskComplete ();
			Destroy (this);
		}
	}
}