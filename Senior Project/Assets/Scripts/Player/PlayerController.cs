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
	[HideInInspector] 
	public bool leftDown, rightDown, isGroundLeft, isGroundRight;

	[HideInInspector] public bool onOneWay;
	[HideInInspector] public Collider2D oneWayCol;

	Vector3 leftFacing = new Vector3 (0,180,0);
	Vector3 rightFacing = new Vector3 (0,0,0);

	public MonoBehaviour activeWeaponScript;
	public GameObject weapon1;
	public GameObject weapon2;

	int activeWeaponNum; 
	[HideInInspector] public int amountOfJumps = 1;
	[HideInInspector] 
	public int jumpsLeft;
	bool jumpOffGround;

	public SlopeDetector groundCheckR;
	public SlopeDetector groundCheckL;

	bool leftMove, rightMove, downMove, interactDown, leftAttack, rightAttack, jumpDown;

	bool facingLeft, facingRight = true;

	public GameObject selectedInteractable;
	Vector2 handPos = new Vector2 (1.4f, 1.15f);

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		speed += stats.agility * 3;
		playerCol = GetComponent<Collider2D> ();
		activeWeaponScript = weapon1.GetComponent<MonoBehaviour> ();
		activeWeaponNum = 1;
		jumpForce = 500;
		jumpsLeft = amountOfJumps;

	}
		
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q)) {
			if (weapon2 != null && weapon1 != null) {
				if (activeWeaponNum == 1) {
					weapon1.SetActive (false);
					weapon2.SetActive (true);
					activeWeaponScript = weapon2.GetComponent<MonoBehaviour> ();
					activeWeaponNum = 2;
				} else {
					weapon1.SetActive (true);
					weapon2.SetActive (false);
					activeWeaponScript = weapon1.GetComponent<MonoBehaviour> ();
					activeWeaponNum = 1;
				}
			}
		}

		//picking up weapons
		if (Input.GetKeyDown (KeyCode.E) && selectedInteractable != null) {
			PickUpWeapon ();
		} 

		if (Input.GetKey (KeyCode.A)) {
			leftMove = true;
			rightMove = false;
		} else if (Input.GetKey (KeyCode.D)) {
			rightMove = true;
			leftMove = false;
		} else {
			rightMove = false;
			leftMove = false;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rightAttack = true;
			leftAttack = false;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			leftAttack = true;
			rightAttack = false;
		} else {
			leftAttack = false;
			rightAttack = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			jumpDown = true;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			jumpDown = false;
		}

		if (Input.GetKey (KeyCode.S)) {
			downMove = true;
		} else
			downMove = false;
	}

	void FixedUpdate () {
		
		if (!isGrounded) {
			playerRigidbody.velocity += new Vector2 (0, forceDown);
			if (forceDown > -.1f)
				forceDown -= 2f * Time.deltaTime;
		} else 
			forceDown = 0;

		//switch active weapon

		// MOVEMENT --------------------------------------------------------------------------------------
		// left and right movement
		if (leftMove && !isGroundLeft) {
			transform.Translate (Vector2.left * speed * Time.fixedDeltaTime, Space.World);
		} else if (rightMove && !isGroundRight) {
			transform.Translate (Vector2.right * speed * Time.fixedDeltaTime, Space.World);
		}
			
		// up and down movement
		// W for doors/stairs S for going through certain platforms
		if (jumpDown && !downMove) {
			if (isGrounded) { 
				playerRigidbody.AddForce (Vector2.up * jumpForce);
				jumpsLeft--;
				jumpOffGround = true;
				jumpDown = false;
			} else if (jumpsLeft > 0 && (jumpsLeft > 1 || jumpOffGround)) { // for double jumps
				playerRigidbody.AddForce (Vector2.up * jumpForce);
				jumpsLeft--;
				jumpDown = false;
			}
		} else if (jumpDown && isGrounded && downMove && onOneWay) {
			Physics2D.IgnoreCollision (playerCol, oneWayCol);
			jumpDown = false;
		}

		//-------------------------------------------------------------------------------------------------
		//Attacking left right and down (possible up?)
		if (leftAttack) {
			transform.localEulerAngles = leftFacing;
			if (!facingLeft) {
				groundCheckL.SwapLeftRight (); groundCheckR.SwapLeftRight ();
				facingLeft = true;
				facingRight = false;
			}
			activeWeaponScript.SendMessage ("StartAttackLeft");
		} else if (rightAttack) {
			transform.localEulerAngles = rightFacing;
			if (!facingRight) {
				groundCheckL.SwapLeftRight ();
				groundCheckR.SwapLeftRight ();
				facingRight = true;
				facingLeft = false;
			}
			activeWeaponScript.SendMessage ("StartAttackRight");

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

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Melee Weapon") {
			selectedInteractable = col.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Melee Weapon" && col.gameObject == selectedInteractable) {
			selectedInteractable = null;
		}
	}

	void PickUpWeapon () {
		if (weapon1 == null) {
			weapon1 = selectedInteractable;
			selectedInteractable.transform.SetParent (this.gameObject.transform);
			weapon1.transform.localPosition = new Vector2 (handPos.x, handPos.y);
			if (facingLeft)
				weapon1.transform.localEulerAngles = new Vector3 (0, 0, 0);
			if (activeWeaponNum == 2) {
				weapon1.SetActive (false);
			}
			weapon1.GetComponent<MeleeWeapons> ().setPos ();
		} else if (weapon2 == null) {
			weapon2 = selectedInteractable;
			selectedInteractable.transform.SetParent (this.gameObject.transform);
			weapon2.transform.localPosition = new Vector2 (handPos.x, handPos.y);
			if (facingLeft)
				weapon2.transform.localEulerAngles = new Vector3 (0, 0, 0);
			if (activeWeaponNum == 1) {
				weapon2.SetActive (false);
			}
			weapon2.GetComponent<MeleeWeapons> ().setPos ();
		} else if (weapon1 != null && weapon2 != null) { //swap weapons with active
			if (activeWeaponNum == 1) {
				weapon1.transform.SetParent (null);
				weapon1.GetComponent<BoxCollider2D> ().enabled = false;
				weapon1 = selectedInteractable;
				selectedInteractable.transform.SetParent (this.gameObject.transform);
				weapon1.transform.localPosition = new Vector2 (handPos.x, handPos.y);
				activeWeaponScript = weapon1.GetComponent<MonoBehaviour> ();
				if (facingLeft)
					weapon1.transform.localEulerAngles = new Vector3 (0, 0, 0);
				if (activeWeaponNum == 2) {
					weapon1.SetActive (false);
				}
				weapon1.GetComponent<MeleeWeapons> ().setPos ();
			}
			if (activeWeaponNum == 2) {
				weapon2.transform.SetParent (null);
				weapon2.GetComponent<BoxCollider2D> ().enabled = false;
				weapon2 = selectedInteractable;
				selectedInteractable.transform.SetParent (this.gameObject.transform);
				weapon2.transform.localPosition = new Vector2 (handPos.x, handPos.y);
				activeWeaponScript = weapon2.GetComponent<MonoBehaviour> ();
				if (facingLeft)
					weapon2.transform.localEulerAngles = new Vector3 (0, 0, 0);
				if (activeWeaponNum == 1) {
					weapon1.SetActive (false);
				}
				weapon2.GetComponent<MeleeWeapons> ().setPos ();
			}
		}
	}

}