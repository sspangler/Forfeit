using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initAtack (Transform pos) {
		print ("Spawn");
		Instantiate (enemy, new Vector3 (-14, 7, 0), Quaternion.identity);
		Instantiate (enemy, new Vector3 (14, 7, 0), Quaternion.identity);
	}
}