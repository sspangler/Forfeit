using UnityEngine;
using System.Collections;

public class DashAbility : MonoBehaviour {

	public PlayerController charCont;
	public PlayerStats playerStats;
	Rigidbody2D playerRig;

	float dashPower;
	public int dashAmount;
	public int dashCount;

	// Use this for initialization
	void Start () {
		charCont = GetComponent<PlayerController> ();
		playerStats = GetComponent<PlayerStats> ();
		dashPower = playerStats.dexterity * playerStats.agility;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.LeftShift) && dashCount < dashAmount) {
			if (playerRig == null)
				playerRig = GetComponent<Rigidbody2D> ();
			else {
				if (Input.GetKey (KeyCode.A)) {
					playerRig.velocity += Vector2.left * dashPower * Time.deltaTime;
				}
			}
		}
	}
}
