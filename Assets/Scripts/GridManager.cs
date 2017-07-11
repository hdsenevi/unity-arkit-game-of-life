using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
		
		_grid.GetGridElementAtIndex(5, 0, 5).SetState(GridElement.ElementState.Live);
		_grid.GetGridElementAtIndex(5, 0, 6).SetState(GridElement.ElementState.Live);
		_grid.GetGridElementAtIndex(5, 0, 7).SetState(GridElement.ElementState.Live);
	}

	void FixedUpdate()
	{
		ExecuteRound();
	}

	void ExecuteRound()
	{
		foreach (GridElement currentElement in _grid.GetLiveElements())
		{
			int neighbourCount = _grid.GetNeighboursOfElement(currentElement, Grid.NeighboutAccessType.OnlyLive).Length;
			if (neighbourCount < 2 || neighbourCount > 3)
			{
				// die
				currentElement.SetState(GridElement.ElementState.Dead);
			}
			else if (neighbourCount == 3)
			{
				// give life
				currentElement.SetState(GridElement.ElementState.Live);
			}
		}
	}
}
