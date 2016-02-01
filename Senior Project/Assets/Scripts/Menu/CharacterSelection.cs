using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject abilitiesCanvas;
	public StatsCanvas statsCanvas;
	public GameObject titleCanvas;
	public GameObject[] characters = new GameObject[4];
	public GameObject selectedCharacter;
	public Text charNameText;


	Vector3 characterPos;
	Vector3 meleePos;
	Vector3 rangedPos;

	public int curChar = 0;
	int availablePoints;

	//----------------------------------------------------
	bool toAbilities;
	bool toStart;

	Vector3 abilitiesPos = new Vector3 (11,0,-10);
	Vector3 startPos = new Vector3 (-18, 0, -10);
	//----------------------------------------------------
	
	// Use this for initialization
	void Start () {
		abilitiesCanvas.SetActive (false);
		characterPos = GameObject.FindGameObjectWithTag ("Player").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (toAbilities) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, abilitiesPos, 10 * Time.deltaTime);
			if (mainCamera.transform.position == abilitiesPos) {
				toAbilities = false;
				abilitiesCanvas.SetActive(true);
				selectedCharacter = GameObject.FindGameObjectWithTag("Player");
				abilitiesCanvas.GetComponent<AbilitySelection>().player = selectedCharacter;
				abilitiesCanvas.GetComponent<AbilitySelection>().playerStats = selectedCharacter.GetComponent<PlayerStats>();
				abilitiesCanvas.GetComponent<AbilitySelection> ().playerCont = selectedCharacter.GetComponent<PlayerController> ();
				abilitiesCanvas.GetComponent<AbilitySelection>().availPoints = selectedCharacter.GetComponent<PlayerStats>().avalPoints;
				this.gameObject.SetActive(false);
			}
		}

		if (toStart) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, startPos, 15 * Time.deltaTime);
			if (mainCamera.transform.position == startPos) {
				toStart = false;
				titleCanvas.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}


	public void PrvCharacter () {
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		if (curChar == 0) { // loops to last
			Instantiate (characters [characters.Length-1], characterPos, Quaternion.identity);
			curChar = characters.Length-1;
		} else {
			Instantiate (characters[curChar-1], characterPos, Quaternion.identity);
			curChar -= 1;
		}

		statsCanvas.Invoke("UpdateStats", .1f);
		selectedCharacter = characters[curChar];
		abilitiesCanvas.GetComponent<AbilitySelection>().ResetBools();
		charNameText.text = selectedCharacter.name;

	}

	public void NextCharacter () {
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		if (curChar+1 == characters.Length) { // loops to first
			Instantiate (characters[0], characterPos, Quaternion.identity);
			curChar = 0;
		} else {
			Instantiate (characters[curChar+1], characterPos, Quaternion.identity);
			curChar += 1;
		}

		statsCanvas.Invoke("UpdateStats", .1f);
		selectedCharacter = characters[curChar];
		abilitiesCanvas.GetComponent<AbilitySelection>().ResetBools();
		charNameText.text = selectedCharacter.name;

	}

//	public void SelectCharacter (int character) {
//		if (character != prevChar) {
//			Destroy (GameObject.FindGameObjectWithTag ("Player"));
//			Instantiate (characters [character], characterPos, Quaternion.identity);
//			prevChar = character;
//			abilitiesCanvas.GetComponent<AbilitySelection>().ResetBools();
//			selectedCharacter = characters[character];
//			statsCanvas.Invoke("UpdateStats", .1f);
//		}
//	}
	

	public void MoveToAbilities () {
		toAbilities = true;
	}

	public void MoveToTitle () {
		toStart = true;
	}
}
