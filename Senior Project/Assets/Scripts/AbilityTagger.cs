using UnityEngine;
using System.Collections;

public class AbilityTagger : MonoBehaviour {

	public bool headItem, chestItem, armItem, legItem, miscItem;

	// Use this for initialization
	void Start () {
		if (headItem)
			transform.tag = "HeadItem";
		else if (chestItem)
			transform.tag = "ChestItem";
		else if (armItem)
			transform.tag = "ArmItem";
		else if (legItem)
			transform.tag = "LegItem";
		else if (miscItem)
			transform.tag = "MiscItem";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
