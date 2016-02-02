using UnityEngine;
using System.Collections;

public class SmallRoomLockedDoors : MonoBehaviour {

	public GameObject HorzLockedDoor;
	public GameObject VertLockedDoor;

	float scale;

	Vector3 topPos;
	Vector3 botPos;
	Vector3 leftPos;
	Vector3 rightPos;

	// Use this for initialization
	void Start () {
		scale = transform.localScale.x;
		topPos = new Vector3 (scale / 2, 0, 0) + transform.position;
		botPos = new Vector3 (scale / 2, -scale, 0) + transform.position;
		leftPos = new Vector3 (0, -(scale / 2), 0) + transform.position;
		rightPos = new Vector3 (scale, -(scale / 2), 0) + transform.position;

		CheckForDoors ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CheckForDoors () {
		RaycastHit2D hitTop = Physics2D.Raycast(topPos + Vector3.up, Vector2.up, 1f);	
		RaycastHit2D hitBot = Physics2D.Raycast (botPos + Vector3.down, Vector2.down, 1f);
		RaycastHit2D hitLeft = Physics2D.Raycast (leftPos + Vector3.left, Vector2.down, 1f);
		RaycastHit2D hitRight = Physics2D.Raycast (rightPos + Vector3.right, Vector2.down, 1f);

		if (hitTop.collider == null)
			SpawnVertDoor (topPos);
		if (hitBot.collider == null)
			SpawnVertDoor (botPos);
		if (hitLeft.collider == null)
			SpawnHorzDoor (leftPos);
		if (hitRight.collider == null)
			SpawnHorzDoor (rightPos);
	}

	void SpawnVertDoor (Vector3 pos) {
		GameObject door = (GameObject) Instantiate (VertLockedDoor, pos, Quaternion.identity);
		door.transform.parent = transform;
	}

	void SpawnHorzDoor (Vector3 pos) {
		GameObject door = (GameObject) Instantiate (HorzLockedDoor, pos, Quaternion.identity);
		door.transform.parent = transform;

	}
}