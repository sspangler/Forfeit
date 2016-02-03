using UnityEngine;
using System.Collections;

public class SelfHeal : MonoBehaviour {
	PlayerStats stats;
	public float chargeTime;

	float timer;
	bool ready;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		chargeTime = 25f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!ready) {
			timer += Time.deltaTime;
			if (timer >= chargeTime)
				ready = true;
		}

		if (Input.GetKeyDown (KeyCode.E) && ready) {
			if (stats.maxHealth - stats.health <= 2)
				stats.health = stats.maxHealth;
			else
				stats.health += 2;
			ready = false;
			timer = 0;
		}

	}
}
