using UnityEngine;
using System.Collections;

public class DifficultyModifier : MonoBehaviour {

	public bool runStarted;
	public int difModifier;
	public float timeElapsed;
	public float secondsPerDif;

	void UpDifficulty () {
		difModifier += 1;
	}
}
