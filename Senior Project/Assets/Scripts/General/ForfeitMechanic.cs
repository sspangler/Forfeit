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
			if (ability == "")
				continue;
			
			GameObject button = (GameObject) Instantiate (Resources.Load("AbilityButtons/" + ability ), transform.position, Quaternion.identity);
			button.transform.parent = this.gameObject.transform;
			button.transform.localPosition = startPos + Vector2.right * 300 * i;
			button.transform.localScale = new Vector3 (2, 2, 1);
			button.name = ability;

			button.GetComponent<Button> ().onClick.AddListener (() => {
				if (button.tag == "HeadItem")
					abilSelect.HeadAbilites(button);
				else if (button.tag == "ChestItem")
					abilSelect.ChestAbilites(button);
				else if (button.tag == "ArmItem")
					abilSelect.ArmAbilites(button);
				else if (button.tag == "LegItem")
					abilSelect.LegAbilites(button);
				else if (button.tag == "MiscItem")
					abilSelect.MiscAbilites(button);
				
				RemoveAbility(button.name);
				Application.LoadLevel(Application.loadedLevel + 1);
			});
			i++;
		}
	}

	void RemoveAbility (string ability) {
		//int num1 = abilTrack.abilities.IndexOf(ability);
		//print (num1);
		abilTrack.abilities.Remove (ability);
		//abilTrack.abilities.RemoveAt (num1);
		Destroy (this.gameObject);
	}
}
