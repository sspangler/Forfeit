using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warden : MonoBehaviour {

	GameObject player;

	public bool bottomSides;
	public bool topSides;
	public bool middleSides;
	public bool middleMiddle;
	public bool botMiddle;

	public Charge chargeAttack;
	public Cyclone cycloneAttack;
	public Shoot shootAttack;
	public Spawn spawnAttack;
	public VertSwipe swipeAttack;

	public float timer;
	public float cooldown;


	bool moveToCenter;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!moveToCenter)
			timer -= Time.deltaTime;
		
		if (timer < 0) {
			ChooseAttack ();
		}
		if (moveToCenter) {
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, -2.65f), 5 * Time.deltaTime);
			if (transform.position.x == 0)
				moveToCenter = false;
		}
	}
		
	void ChooseAttack () {
		if (bottomSides) {
			chargeAttack.initAtack (player.transform);
			timer = 5f;
		} else if (topSides) {
			spawnAttack.initAtack (player.transform);
			timer = 5f;
		} else if (middleSides) {
			shootAttack.initAtack (player.transform);
			timer = 5f;
		} else if (middleMiddle) {
			swipeAttack.initAtack (player.transform);
			timer = 5f;
		} else if (botMiddle) {
			cycloneAttack.initAtack (player.transform);
			timer = 5f;
		} else {
			moveToCenter = true;
			timer = 5f;
		}
	}
}