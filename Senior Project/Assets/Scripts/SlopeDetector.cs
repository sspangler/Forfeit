using UnityEngine;
using System.Collections;

public class SlopeDetector : MonoBehaviour {
	
	public PlayerController Parent;
	public bool isRight, isLeft;
	
	// Use this for initialization
	void Start () {
		Parent = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				Parent.isGroundLeft = true;
			} else if (isRight){
				Parent.isGroundRight = true;
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Ground") {
			if (isLeft) {
				Parent.isGroundLeft = false;
			} else {
				Parent.isGroundRight = false;
			}
		}
	}

	public void SwapLeftRight () {
		isRight = !isRight;
		isLeft = !isLeft;

	}
}