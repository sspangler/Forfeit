using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

	Vector2 playerPos;
	Vector2 direction;

	bool attack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (attack) {
			transform.position = Vector2.MoveTowards (transform.position, playerPos, 20 * Time.deltaTime);
			if ((Vector2)transform.position == playerPos)
				attack = false;
		}
	}

	public void initAtack (Transform pos) {
		playerPos = pos.position;
		playerPos.y = transform.position.y;
		direction = pos.position - transform.position;
		attack = true;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player")
			attack = false;
	}
}