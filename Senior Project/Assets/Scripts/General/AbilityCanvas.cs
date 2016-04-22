using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCanvas : MonoBehaviour {
	GameObject mainCamera;
	public GameObject characterCanvas;
	DifficultyModifier difMod;
	Vector3 characterPos = new Vector3 (0,0,-10);

	public GameObject player;

	bool toChracter;

	public GameObject[] skills;

	// Use this for initialization
	void Start () {
		difMod = GameObject.FindGameObjectWithTag("GameController").GetComponent<DifficultyModifier> ();
		characterCanvas = GameObject.Find ("CharacterCanvas");
		skills = GameObject.FindGameObjectsWithTag ("SkillButton");
		mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (toChracter) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, characterPos, 10 * Time.deltaTime);
			if (mainCamera.transform.position == characterPos) {
				toChracter = false;
				characterCanvas.GetComponent<Canvas> ().enabled = true;
				this.gameObject.GetComponent<Canvas> ().enabled = false;
			}
		}
	}

	public void LoadLevel () {
		Application.LoadLevel (1);
		player.transform.position = new Vector3 (0f, 0f, -.1f);
		player.transform.localScale = new Vector3 (5f, 5f, 1f);
		player.AddComponent<Rigidbody2D> ();
		player.GetComponent<Rigidbody2D>().freezeRotation = true;
		difMod.InvokeRepeating ("UpDifficulty", difMod.secondsPerDif, difMod.secondsPerDif);
		difMod.timeRunning = true;
	}

	public void moveToCharacter () {
		toChracter = true;
	}

	public void resetSkills () {
		foreach (GameObject skill in skills) {
			skill.GetComponent<Button> ().image.color = Color.white;
		}
	}
}
