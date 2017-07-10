using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private Grid _grid;

	void Start () {
		_grid = new Grid (10, 10, 10);	
	}
}
