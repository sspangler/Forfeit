using UnityEngine;
using System.Collections;

public class VertRoomLockedDoors : MonoBehaviour {

	public GameObject HorzLockedDoor;
	public GameObject VertLockedDoor;

	float xScale;
	float yScale;

	Vector3 topPos;
	Vector3 botPos;
	Vector3 topLeftPos;
	Vector3 topRightPos;
	Vector3 botLeftPos;
	Vector3 botRightPos;

	// Use this for initialization
	void Start () {
		xScale = transform.localScale.x;
		yScale = transform.localScale.y;
		topLeftPos = new Vector3 (0, -(yScale / 4), 0) + transform.position;
		botLeftPos = new Vector3 (0, -(yScale / 1.33f), 0) + transform.position;
		topRightPos = new Vector3 (xScale, -(yScale / 4), 0) + transform.position;
		botRightPos = new Vector3 (xScale , -(yScale / 1.33f), 0) + transform.position;
		topPos = new Vector3 (xScale / 2, 0, 0) + transform.position;
		botPos = new Vector3 (xScale / 2, -yScale, 0) + transform.position;

		CheckForDoors ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CheckForDoors () {
		RaycastHit2D hitTopLeft = Physics2D.Raycast(topLeftPos + Vector3.left, Vector2.left, 1f);	
		RaycastHit2D hitBotLeft = Physics2D.Raycast (botLeftPos + Vector3.left, Vector2.left, 1f);

		RaycastHit2D hitTopRight = Physics2D.Raycast(topRightPos + Vector3.right, Vector2.right, 1f);	
		RaycastHit2D hitBotRight = Physics2D.Raycast (botRightPos + Vector3.right, Vector2.right, 1f);

		RaycastHit2D hitTop = Physics2D.Raycast (topPos + Vector3.up, Vector2.up, 1f);
		RaycastHit2D hitBot = Physics2D.Raycast (botPos + Vector3.down, Vector2.down, 1f);

		if (hitTopLeft.collider == null)
			SpawnHorzDoor (topLeftPos);
		if (hitBotLeft.collider == null)
			SpawnHorzDoor (botLeftPos);
		if (hitTopRight.collider == null)
			SpawnHorzDoor (topRightPos);
		if (hitBotRight.collider == null)
			SpawnHorzDoor (botRightPos);
		if (hitTop.collider == null)
			SpawnVertDoor (topPos);
		if (hitBot.collider == null)
			SpawnVertDoor (botPos);
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
