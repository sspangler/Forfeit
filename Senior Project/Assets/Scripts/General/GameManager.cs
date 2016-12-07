using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject playerUI;
	int sceneNum = 0;
	public int coins;
	public Text coinsText;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			Application.LoadLevel (sceneNum + 1);
		}
	}

	public void OnLevelWasLoaded (int level) {
		sceneNum += 1;
		if (level == 1) {
			player = GameObject.FindGameObjectWithTag ("Player");
			//playerUI.transform.GetChild (0).GetComponent<Slider> ().maxValue = player.GetComponent<PlayerStats> ().maxHealth;
			playerUI.GetComponent<Canvas> ().enabled = true;
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

	public void UpdateUI (int coinNum) {
		coins += coinNum;
		coinsText.text = coins.ToString ();
	}
}