using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject abilitiesCanvas;
	public GameObject characterCanvas;
	public GameObject statsCanvas;

	bool toCharacter;

	Vector3 characterPos = new Vector3 (0,0,-10);

	// Use this for initialization
	void Start () {
		abilitiesCanvas.SetActive (false);
		characterCanvas.SetActive(false);
		statsCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !toCharacter)
			toCharacter = true;

		if (toCharacter) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, characterPos, 15 * Time.deltaTime);
			if (mainCamera.transform.position == characterPos) {
				toCharacter = false;
				characterCanvas.SetActive(true);
				statsCanvas.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
}
