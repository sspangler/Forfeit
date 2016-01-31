using UnityEngine;
using System.Collections;

public class LargeRoomLockedDoors : MonoBehaviour {

	public GameObject HorzLockedDoor;
	public GameObject VertLockedDoor;

	float xScale;
	float yScale;

	Vector3 topLeftPos;
	Vector3 botLeftPos;
	Vector3 topRightPos;
	Vector3 botRightPos;
	Vector3 leftTopPos;
	Vector3 rightTopPos;
	Vector3 leftBotPos;
	Vector3 rightBotPos;

	// Use this for initialization
	void Start () {
		xScale = transform.localScale.x;
		yScale = transform.localScale.y;
		topLeftPos = new Vector3 (xScale / 4, 0, 0) + transform.position;
		botLeftPos = new Vector3 (xScale / 4, -yScale, 0) + transform.position;
		topRightPos = new Vector3 (xScale / 1.33f, 0, 0) + transform.position;
		botRightPos = new Vector3 (xScale / 1.33f , -yScale, 0) + transform.position;

		leftTopPos = new Vector3 (0, -(yScale / 4), 0) + transform.position;
		rightTopPos = new Vector3 (xScale, -(yScale / 4), 0) + transform.position;
		leftBotPos = new Vector3 (0, -(yScale / 1.33f), 0) + transform.position;
		rightBotPos = new Vector3 (xScale, -(yScale / 1.33f), 0) + transform.position;

		CheckForDoors ();
	}

	void CheckForDoors () {
		RaycastHit2D hitTopLeft = Physics2D.Raycast(topLeftPos + Vector3.up, Vector2.up, 1f);	
		RaycastHit2D hitBotLeft = Physics2D.Raycast (botLeftPos + Vector3.down, Vector2.down, 1f);

		RaycastHit2D hitTopRight = Physics2D.Raycast(topRightPos + Vector3.up, Vector2.up, 1f);	
		RaycastHit2D hitBotRight = Physics2D.Raycast (botRightPos + Vector3.down, Vector2.down, 1f);

		RaycastHit2D hitLeftTop = Physics2D.Raycast (leftTopPos + Vector3.left, Vector2.left, 1f);
		RaycastHit2D hitRightTop = Physics2D.Raycast (rightTopPos + Vector3.right, Vector2.right, 1f);

		RaycastHit2D hitLeftBot = Physics2D.Raycast (leftBotPos + Vector3.left, Vector2.left, 1f);
		RaycastHit2D hitRightBot = Physics2D.Raycast (rightBotPos + Vector3.right, Vector2.right, 1f);

		if (hitTopLeft.collider == null)
			SpawnVertDoor (topLeftPos);
		if (hitBotLeft.collider == null)
			SpawnVertDoor (botLeftPos);
		if (hitTopRight.collider == null)
			SpawnVertDoor (topRightPos);
		if (hitBotRight.collider == null)
			SpawnVertDoor (botRightPos);
		
		if (hitLeftTop.collider == null)
			SpawnHorzDoor (leftTopPos);
		if (hitRightTop.collider == null)
			SpawnHorzDoor (rightTopPos);
		if (hitLeftBot.collider == null)
			SpawnHorzDoor (leftBotPos);
		if (hitRightBot.collider == null)
			SpawnHorzDoor (rightBotPos);

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
