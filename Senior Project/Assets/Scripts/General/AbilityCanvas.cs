using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class AbilityCanvas : MonoBehaviour {
	GameObject mainCamera;
	public GameObject characterCanvas;
	DifficultyModifier difMod;
	Vector3 characterPos = new Vector3 (0,0,-10);

	public GameObject[] bodyParts = new GameObject[5];
	int bodyPartNum;
	public Text bodyPartText;

	public GameObject player;

	bool toChracter;

	public List<GameObject> skills = new List<GameObject>();

	// Use this for initialization
	void Start () {
		difMod = GameObject.FindGameObjectWithTag("GameController").GetComponent<DifficultyModifier> ();
		characterCanvas = GameObject.Find ("CharacterCanvas");
		foreach (GameObject skill in GameObject.FindGameObjectsWithTag ("HeadItem"))
			skills.Add (skill);
		foreach (GameObject skill in GameObject.FindGameObjectsWithTag ("ChestItem"))
			skills.Add (skill);
		foreach (GameObject skill in GameObject.FindGameObjectsWithTag ("ArmItem"))
			skills.Add (skill);
		foreach (GameObject skill in GameObject.FindGameObjectsWithTag ("LegItem"))
			skills.Add (skill);
		foreach (GameObject skill in GameObject.FindGameObjectsWithTag ("MiscItem"))
			skills.Add (skill);

		for (int i = 1; i <= 4; i++)
			bodyParts [i].SetActive (false);
		
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

	public void PrevAbilities () {
		bodyParts [bodyPartNum].SetActive (false);
		bodyPartNum--;
		if (bodyPartNum < 0) {
			bodyParts [bodyParts.Length-1].SetActive (true); 
			bodyPartNum = bodyParts.Length-1;
		}
		else
			bodyParts [bodyPartNum].SetActive (true);
		
		bodyPartText.text = bodyParts [bodyPartNum].name;
	}

	public void NextAbilities () {
		bodyParts [bodyPartNum].SetActive (false);
		bodyPartNum++;
		if (bodyPartNum >= bodyParts.Length) {
			bodyParts [0].SetActive (true);
			bodyPartNum = 0;
		}
		else 
			bodyParts [bodyPartNum].SetActive (true);

		bodyPartText.text = bodyParts [bodyPartNum].name;
	}
}