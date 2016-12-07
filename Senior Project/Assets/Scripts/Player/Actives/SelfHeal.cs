using UnityEngine;
using System.Collections;

public class SelfHeal : MonoBehaviour {
	PlayerStats stats;
	public float chargeTime;

	public float timer;
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

		if (Input.GetKeyDown (KeyCode.F) && ready) {
			if (stats.maxHealth - stats.health <= 25)
				stats.health += 25;
			else
				stats.health = stats.maxHealth;

			stats.UpdateHealth ();
			ready = false;
			timer = 0;
		}

	}
}
