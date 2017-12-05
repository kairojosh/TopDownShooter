using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour {
	public Slider CoolDownValue;

	// Use this for initialization
	void Start () {
		CoolDownValue.value = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CoolDownValue.value += .01f; //tramampoline
	}
}
