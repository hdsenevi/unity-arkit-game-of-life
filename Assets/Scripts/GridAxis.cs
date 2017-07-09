using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAxis {
	public ArrayList elemensList {
		get;
		private set;
	}

	public enum AxisType {
		XAxis,
		YAxis,
		ZAxis,
	}

	public AxisType axisType {
		get;
		private set;
	}

	public GridAxis(AxisType axisType, int elementCapacity) {
		this.axisType = axisType;

		elemensList = new ArrayList (elementCapacity);
	}

	public void AddDependentAxis(GridAxis dependentGridAxis) {
		elemensList.Add (dependentGridAxis);
	}

	public void AddGridElement(GridElement element) {
		elemensList.Add (element);
	}

	public GridElement GetElementAtIndex(int index) {
		if (elemensList [index].GetType () == typeof(GridAxis)) {
			GridAxis axis = elemensList [index] as GridAxis;
			return axis.GetElementAtIndex (index);
		}

		if (elemensList [index].GetType () == typeof(GridElement)) {
			return (GridElement)elemensList [index];
		}

		return null;
	}
}
