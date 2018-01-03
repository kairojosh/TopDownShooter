using System.Collections;
using UnityEngine;

public class GridScript : MonoBehaviour {

	public LayerMask outOfBoundsMask;
	public Vector2 gridWorldSize;
	public float nodeSize;
	Node[,] grid;

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3 (gridWorldSize.x, 1, gridWorldSize.y));
			


	}

}
