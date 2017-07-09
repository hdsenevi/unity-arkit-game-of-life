using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
	
	private GridAxis _xAxis;
	private GridAxis _yAxis;
	private GridAxis _zAxis;

	public Grid(int xSize, int ySize, int zSize) {
		_xAxis = new GridAxis (GridAxis.AxisType.XAxis, xSize);
		_yAxis = new GridAxis (GridAxis.AxisType.YAxis, ySize);
		_zAxis = new GridAxis (GridAxis.AxisType.ZAxis, zSize);

		_xAxis.AddDependentAxis (_yAxis);
		_yAxis.AddDependentAxis (_zAxis);

		_zAxis.AddGridElement (new GridElement ("blah blah"));
	}

	public GridElement GetElement() {
		return _xAxis.GetElementAtIndex (0);
	}
}
