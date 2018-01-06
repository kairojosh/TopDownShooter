using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class doe not inherit from monobehaviour
public class Node {

	public bool inBounds;
	public Vector3 position;
	public Vector3 parentPosition;
	public int gCost, hCost, fCost;

	//Instantiater Method, underscore before the identifier is convention, example of encapsulation
	public Node(bool _inBounds, Vector3 _position) {
		inBounds = _inBounds;
		position = _position;

	}


}
