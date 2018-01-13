using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap<T> {

	T[] values;
	int valueCount;
	int currentIndex;


	public Heap(int x, int y){
		int maxHeapSize = x * y;
		values = new T[maxHeapSize];

	}

	public void AddToHeap(T value){
		if (values [0] == null) {
			T [0] = value;
			currentIndex = 0;

		} 
		else {
			currentIndex++;
			T [currentIndex] = value;
			

		}



	}

	int GetParentIndex;

}
