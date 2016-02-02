using UnityEngine;
using System.Collections;

public class HorzRoomLockedDoors : MonoBehaviour {

	public GameObject HorzLockedDoor;
	public GameObject VertLockedDoor;

	float xScale;
	float yScale;

	Vector3 topLeftPos;
	Vector3 botLeftPos;
	Vector3 topRightPos;
	Vector3 botRightPos;
	Vector3 leftPos;
	Vector3 rightPos;

	// Use this for initialization
	void Start () {
		xScale = transform.localScale.x;
		yScale = transform.localScale.y;
		topLeftPos = new Vector3 (xScale / 4, 0, 0) + transform.position;
		botLeftPos = new Vector3 (xScale / 4, -yScale, 0) + transform.position;
		topRightPos = new Vector3 (xScale / 1.33f, 0, 0) + transform.position;
		botRightPos = new Vector3 (xScale / 1.33f , -yScale, 0) + transform.position;
		leftPos = new Vector3 (0, -(yScale / 2), 0) + transform.position;
		rightPos = new Vector3 (xScale, -(yScale / 2), 0) + transform.position;

		CheckForDoors ();
	}

	void CheckForDoors () {
		RaycastHit2D hitTopLeft = Physics2D.Raycast(topLeftPos + Vector3.up, Vector2.up, 1f);	
		RaycastHit2D hitBotLeft = Physics2D.Raycast (botLeftPos + Vector3.down, Vector2.down, 1f);

		RaycastHit2D hitTopRight = Physics2D.Raycast(topRightPos + Vector3.up, Vector2.up, 1f);	
		RaycastHit2D hitBotRight = Physics2D.Raycast (botRightPos + Vector3.down, Vector2.down, 1f);

		RaycastHit2D hitLeft = Physics2D.Raycast (leftPos + Vector3.left, Vector2.down, 1f);
		RaycastHit2D hitRight = Physics2D.Raycast (rightPos + Vector3.right, Vector2.down, 1f);

		if (hitTopLeft.collider == null)
			SpawnVertDoor (topLeftPos);
		if (hitBotLeft.collider == null)
			SpawnVertDoor (botLeftPos);
		if (hitTopRight.collider == null)
			SpawnVertDoor (topRightPos);
		if (hitBotRight.collider == null)
			SpawnVertDoor (botRightPos);
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
