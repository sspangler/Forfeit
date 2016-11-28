using UnityEngine;
using System.Collections;

public class VertSwipe : MonoBehaviour {

	public BoxCollider2D vertSwipeCol;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initAtack (Transform pos) {
		vertSwipeCol.enabled = true;
		Invoke ("stopAttack", .5f);
	}

	void stopAttack () {
		vertSwipeCol.enabled = false;
	}
}
