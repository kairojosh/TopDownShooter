using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
	GridScript grid;


	void Awake(){
		grid = GetComponent<GridScript> ();

	}

	void FindPath(Vector3 startPosition, Vector3 targetPosition) {
		Node startNode = grid.PositionConvertNode (startPosition);
		Node targetNode = grid.PositionConvertNode (targetPosition);

		List<Node> openNodes = new List<Node> ();
		List<Node> closedNodes = new List<Node> ();

		openNodes.Add (startNode);
		while (closedNodes > 0) {
			Node activeNode


		}
}
