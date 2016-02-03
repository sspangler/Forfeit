using UnityEngine;
using System.Collections;

public class DashAbility : MonoBehaviour {

	public PlayerController playerCont;
	public PlayerStats playerStats;
	public Rigidbody2D playerRig;

	float dashPower;
	public int dashAmount;
	public int dashCount;

	public float leftButtonCooldown = .5f;
	float rightButtonCooldown = .5f;
	public int leftButtonCount = 0;
	int rightButtonCount = 0;

	// Use this for initialization
	void Start () {
		dashAmount = 2;
		playerCont = GetComponent<PlayerController> ();
		playerStats = GetComponent<PlayerStats> ();
		dashPower = playerStats.dexterity * playerStats.agility;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (leftButtonCooldown > 0)
			leftButtonCooldown -= Time.deltaTime;
		else
			leftButtonCount = 0;

		if (rightButtonCooldown > 0)
			rightButtonCooldown -= Time.deltaTime;
		else
			rightButtonCount = 0;

		//double tap left
		if (Input.GetKeyDown (KeyCode.A) && playerCont.isGrounded) {
			if (leftButtonCooldown > 0 && leftButtonCount == 1) {
				playerRig.AddForce (Vector2.left * dashPower * 750);
			} else {
				leftButtonCooldown = .5f;
				leftButtonCount += 1;
			}
		} else if (Input.GetKeyDown (KeyCode.D) && playerCont.isGrounded) {
			if (rightButtonCooldown > 0 && rightButtonCount == 1) {
				playerRig.AddForce (Vector2.right * dashPower * 750);
			} else {
				rightButtonCooldown = .5f;
				rightButtonCount += 1;
			}
		}
	}

	void OnLevelWasLoaded () {
		playerRig = GetComponent<Rigidbody2D> ();
	}
}
