using UnityEngine;
using System.Collections;

public class SpeedDebuff : MonoBehaviour {

	public float duration;

	public float intesity;

	// Use this for initialization
	void Start () {
		GetComponent<PlayerController> ().speed = GetComponent<PlayerController> ().speed * .75f;
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;

		if (duration < 0) {
			GetComponent<PlayerController> ().speed = GetComponent<PlayerController> ().speed / .75f;
			Destroy (this);
		}
	}
}