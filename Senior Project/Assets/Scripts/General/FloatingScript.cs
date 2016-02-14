using UnityEngine;
using System.Collections;

public class FloatingScript : MonoBehaviour {

	float maxUpAndDown = 1;
	float speed = 200;
	float angle = 0;
	float toDegrees = Mathf.PI / 180;

	Vector3 startPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle += speed * Time.deltaTime;
		if (angle > 360) angle -= 360;
		//transform.position.y = maxUpAndDown * Mathf.Sin(angle * toDegrees);
	}
}
