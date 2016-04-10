using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyModifier : MonoBehaviour {

	public int difModifier;
	float timeElapsed;
	public float secondsPerDif;

	public Text runTime;
	public Slider difBar;

	public bool timeRunning;

	void Start () {
		difBar.GetComponent<Slider> ().maxValue = secondsPerDif;
	}

	void UpDifficulty () {
		difModifier += 1;
		runTime.text = "Difficulty Level " + difModifier;
		difBar.value = 0;
		timeElapsed = 0;
	}
		
	void Update () {
		if (timeRunning) {
			difBar.value = timeElapsed;
			timeElapsed += Time.deltaTime;
		}
	}
}
