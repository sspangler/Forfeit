using UnityEngine;
using System.Collections;

public class ForfeitMechanic : MonoBehaviour {

	public AbilityTracker abilTrack;

	// Use this for initialization
	void Start () {

		GetComponent<Canvas> ().worldCamera = Camera.main;

		abilTrack = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AbilityTracker> ();
		foreach (string ability in abilTrack.abilities) {
			GameObject button = (GameObject) Instantiate (Resources.Load("AbilityButtons/" + ability ), transform.position, Quaternion.identity);
			button.transform.parent = this.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
