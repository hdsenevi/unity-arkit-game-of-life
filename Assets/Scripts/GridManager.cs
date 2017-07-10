using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public GameObject gridVisualPrefab;
	
	private Grid _grid;

	void Start () {
		if (gridVisualPrefab == null)
		{
			return;
		}
		
		_grid = new Grid (10, 1, 10, gridVisualPrefab, this.transform);
		
		ExecuteRound();
	}

	void ExecuteRound()
	{
		Debug.Log(_grid.GetLiveElements().Length);
	}
}
