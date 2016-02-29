using UnityEngine;
using System.Collections;

public class DestructableObj : MonoBehaviour {

	public float health;
	public bool taskRelated;

	public DestroyObjects desObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			DropStuff ();
			if (taskRelated) {
				desObj.objsLeft--;
				if (desObj.objsLeft == 0) {
					GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
				}
			}
			Destroy (this.gameObject);
		}
	}

	void DropStuff () {

	}
}