using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForfeitMechanic : MonoBehaviour {

	public AbilitySelection abilSelect;
	public AbilityTracker abilTrack;

	public Vector2 startPos;
	int i = 0;
	// Use this for initialization
	void Start () {

		GetComponent<Canvas> ().worldCamera = Camera.main;
		GetComponent<Canvas> ().planeDistance = .5f;

		abilSelect = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AbilitySelection> ();
		abilTrack = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AbilityTracker> ();

		foreach (string ability in abilTrack.abilities) {
			GameObject button = (GameObject) Instantiate (Resources.Load("AbilityButtons/" + ability ), transform.position, Quaternion.identity);
			button.transform.parent = this.gameObject.transform;
			button.transform.localPosition = startPos + Vector2.right * 300 * i;
			button.name = ability;
			button.GetComponent<Button> ().onClick.AddListener (() => {
				abilSelect.SetAbilities(button);
				RemoveAbility(button.name);
				Application.LoadLevel(Application.loadedLevel + 1);
			});
			i++;
		}
	}

	void RemoveAbility (string ability) {
		abilTrack.abilities.Remove (ability);
		Destroy (this.gameObject);
	}
}
