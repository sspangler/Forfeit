using UnityEngine;
using System.Collections;

public class AbilityCanvas : MonoBehaviour {
	GameObject mainCamera;
	GameObject characterCanvas;
	DifficultyModifier difMod;
	Vector3 characterPos = new Vector3 (0,0,-10);

	public GameObject player;

	bool toChracter;

	// Use this for initialization
	void Start () {
		difMod = GameObject.FindGameObjectWithTag("GameController").GetComponent<DifficultyModifier> ();
		characterCanvas = GameObject.Find ("CharacterCanvas");

		mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (toChracter) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, characterPos, 10 * Time.deltaTime);
			if (mainCamera.transform.position == characterPos) {
				toChracter = false;
				characterCanvas.SetActive(true);
				this.gameObject.SetActive(false);
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

	}

	public void moveToCharacter () {
		toChracter = true;
	}
}
