using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	PlayerStats stats;
	Rigidbody2D playerRigidbody;
	Collider2D playerCol;
	[HideInInspector]
	public float speed;
	public float jumpForce;
	[HideInInspector] public bool isGrounded;

	float forceDown;
	[HideInInspector] public bool leftDown, rightDown, isGroundLeft, isGroundRight;

	[HideInInspector] public bool onOneWay;
	[HideInInspector] public Collider2D oneWayCol;

	Vector3 leftFacing = new Vector3 (0,180,0);
	Vector3 rightFacing = new Vector3 (0,0,0);

	public MonoBehaviour activeWeaponScript;
	public GameObject weapon1;
	public GameObject weapon2;

	int activeWeaponNum; 
	[HideInInspector] public int amountOfJumps = 1;
	[HideInInspector] public int jumpsLeft;
	bool jumpOffGround;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		speed += stats.agility * 3;
		playerCol = GetComponent<Collider2D> ();
		activeWeaponScript = weapon1.GetComponent<MonoBehaviour> ();
		activeWeaponNum = 1;
		jumpForce = 10 + (stats.strength * .5f) * (stats.agility * .25f);
		jumpsLeft = amountOfJumps;
	}
		
	void Update () {

		if (Input.GetKeyDown (KeyCode.L)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		if (!isGrounded) {
			playerRigidbody.velocity += new Vector2 (0, forceDown);
			if (forceDown > -.1f)
				forceDown -= .5f * Time.deltaTime;
		} else 
			forceDown = 0;

		//switch active weapon
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (weapon2 != null && weapon1 != null) {
				if (activeWeaponNum == 1) {
					activeWeaponScript = weapon2.GetComponent<MonoBehaviour> ();
					activeWeaponNum = 2;
				} else {
					activeWeaponScript = weapon1.GetComponent<MonoBehaviour> ();
					activeWeaponNum = 1;
				}
			}
		}

		// MOVEMENT --------------------------------------------------------------------------------------
		// left and right movement
		if (Input.GetKey (KeyCode.A) && !isGroundLeft) {
			playerRigidbody.velocity = new Vector2 (-speed, playerRigidbody.velocity.y);
			
		} else if (Input.GetKey (KeyCode.D) && !isGroundRight) {
			playerRigidbody.velocity = new Vector2 (speed, playerRigidbody.velocity.y);
			
		} else {
			playerRigidbody.velocity = new Vector2 (0, playerRigidbody.velocity.y);
		}
			

		// up and down movement
		// W for doors/stairs S for going through certain platforms
		if (Input.GetKeyDown (KeyCode.Space) && !Input.GetKey (KeyCode.S)) {
			if (isGrounded) { 
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpForce);
				jumpsLeft--;
				jumpOffGround = true;
			} else if (jumpsLeft > 0 && (jumpsLeft > 1 || jumpOffGround)) { // for double jumps
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpForce);
				jumpsLeft--;
			}
			
			
		} else if (Input.GetKeyDown (KeyCode.Space) && isGrounded && Input.GetKey (KeyCode.S) && onOneWay) {
			Physics2D.IgnoreCollision (playerCol, oneWayCol);
		}

		//-------------------------------------------------------------------------------------------------
		//Attacking left right and down (possible up?)
		if (Input.GetKey (KeyCode.LeftArrow)) {
			activeWeaponScript.SendMessage ("StartAttack");
			transform.localEulerAngles = leftFacing;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			activeWeaponScript.SendMessage ("StartAttack");
			transform.localEulerAngles = rightFacing;
		}

	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			ContactPoint2D contact = col.contacts [0];
			if (Vector3.Dot(contact.normal, Vector2.up) > .5f) { //might need to change the .5 with character changes
				isGrounded = true;
				jumpsLeft = amountOfJumps;
				jumpOffGround = false;
			}
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}