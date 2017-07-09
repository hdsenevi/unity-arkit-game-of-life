using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement {
	public int gridX {
		get;
		private set;
	}

	public int gridY {
		get;
		private set;
	}

	public int gridZ {
		get;
		private set;
	}

	public string _testVal;

	public GridElement(string value) {
		_testVal = value;
	}
}
