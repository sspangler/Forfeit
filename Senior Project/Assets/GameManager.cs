using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int diffStage;
	public GameObject player;
	int sceneNum = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			print ("asdfsd");
			Application.LoadLevelAdditive (sceneNum + 1);
		}
	}

	public void OnLevelWasLoaded (int level) {
		sceneNum += 1;
		if (level == 1) {
			player = GameObject.FindGameObjectWithTag ("Player");
			foreach (MonoBehaviour script in player.GetComponents<MonoBehaviour>()) {
				script.enabled = true;
			}
			foreach (Transform child in player.transform) {
				foreach (MonoBehaviour script in child.GetComponents<MonoBehaviour>()) {
					script.enabled = true;
				}
			}
		}
	}
}