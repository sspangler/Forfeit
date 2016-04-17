using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
					GameObject.Find("GameManager/Player UI/TaskImage/TaskText").GetComponent<Text>().text = "Task Complete!";
				}
			}
			Destroy (this.gameObject);
		}
	}

	void DropStuff () {

	}

	public void TakeDamage (float damage) {
		health -= damage;
	}
}