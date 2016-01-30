using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + Vector3.back;
	}
}
