using System.Collections;
using UnityEngine;

public class GridScript : MonoBehaviour {

	public Transform player;
	public LayerMask outOfBoundsMask;
	public Vector2 gridWorldSize;
	public float nodeDiameter;
	Node[,] grid;
	int gridAmountX, gridAmountY;


	void Start() {
		
		gridAmountX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		gridAmountY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
		Debug.Log (gridAmountX);
		Debug.Log(gridAmountY);
		GridInstantiate ();

	}

	public Node PositionConvertNode(Vector3 position) {

		//Calculates how far along each co-ordinate the postion is so it can be converted into the respective grid
		//Finds how far along with a scale of 0 to 1
		float calcX = (position.x - transform.position.x + gridWorldSize.x / 2) / gridWorldSize.x;
		float calcY = (position.z - transform.position.z + gridWorldSize.y / 2) / gridWorldSize.y;
		calcX = Mathf.Clamp01 (calcX);
		calcY = Mathf.Clamp01 (calcY);


		int valueX = Mathf.RoundToInt((gridAmountX - 1) * calcX);
		int valueY = Mathf.RoundToInt((gridAmountY - 1) * calcY);
		return grid [valueX, valueY];



	}


	void GridInstantiate() {
		//Creates the grid based upon calculations done previously in the start method
		grid = new Node[gridAmountX, gridAmountY];

	 	//Scans through current world and determines closed nodes, starts at the bottom left and works way through
		Vector3 startPosition  = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		//Vector3.right is shorthand for Vector3 0,0,1 etc.

		for (int x = 0; x < gridAmountX; x++) {
			for (int y = 0; y < gridAmountY; y++) {
				//Node radius is added as you start in the very bottom right, node in the center of the first node
				Vector3 scanPoint = startPosition + Vector3.right * ((x * nodeDiameter) + nodeDiameter / 2) + Vector3.forward * ((y * nodeDiameter) + nodeDiameter / 2);
				bool inBounds = !(Physics.CheckSphere (scanPoint, (nodeDiameter / 2),outOfBoundsMask));
				grid[x,y] = new Node(inBounds, scanPoint);

			}
		}

	}




	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (gridWorldSize.x, 1, gridWorldSize.y));
		if (grid != null) {
			Node playerNode = PositionConvertNode (player.position);

			foreach (Node i in grid) {

				// ? if is true : if is not true
				Gizmos.color = (i.inBounds) ? Color.black : Color.red;
				if (playerNode == i) {
					Gizmos.color = Color.white;
				}


				Gizmos.DrawWireCube (i.position, Vector3.one * (nodeDiameter -.01f) );

			}
		}
	}


	}


