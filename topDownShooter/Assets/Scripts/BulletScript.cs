using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((gameObject.GetComponent<Rigidbody> ().velocity).magnitude < 25f) {

			Destroy (gameObject);
		}
	}
}
