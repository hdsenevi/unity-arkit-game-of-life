using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject gridVisualPrefab;

    private Grid _grid;
    private List<GridElement> _giveLifeList = new List<GridElement>();
    private List<GridElement> _killList = new List<GridElement>();

    private float _dt;

    void Start()
    {
        if (gridVisualPrefab == null)
        {
            return;
        }

//        _grid = new Grid(5, 1, 5, gridVisualPrefab, this.transform);
//        
//        _grid.GetGridElementAtIndex(2, 0, 1).SetState(GridElement.ElementState.Live);
//        _grid.GetGridElementAtIndex(2, 0, 2).SetState(GridElement.ElementState.Live);
//        _grid.GetGridElementAtIndex(2, 0, 3).SetState(GridElement.ElementState.Live);
        
        _grid = new Grid(25, 1, 25, gridVisualPrefab, this.transform);
    }

    void FixedUpdate()
    {
        _dt += Time.fixedDeltaTime;

        if (_dt > 1f)
        {
            ExecuteRound();
            _dt = 0f;
        }
    }

    void ExecuteRound()
    {
        _killList.Clear();
        _giveLifeList.Clear();
        
        // This gets the live elements
        foreach (GridElement currentElement in _grid.GetAllElements())
        {
            GridElement[] neighbours = _grid.GetNeighboursOfElement(currentElement);
            int aliveNeighbourCount = _grid.GetNeighboursOfElement(currentElement, Grid.NeighboutAccessType.OnlyLive).Length;
            foreach (GridElement neighbour in neighbours)
            {
                if (neighbour.IsLive())
                {
                    // kill
                    if (aliveNeighbourCount < 2)
                    {
                        _killList.Add(currentElement);
                    }

                    if (aliveNeighbourCount > 3)
                    {
                        _killList.Add(currentElement);
                    }
                }
                else if (aliveNeighbourCount == 3)
                {
                    // give life
                    _giveLifeList.Add(currentElement);
                }
            }
        }

        foreach (GridElement element in _killList)
        {
            _grid.GetGridElementAtIndex(element.X, element.Y, element.Z).SetState(GridElement.ElementState.Dead);
        }

        foreach (GridElement element in _giveLifeList)
        {
            _grid.GetGridElementAtIndex(element.X, element.Y, element.Z).SetState(GridElement.ElementState.Live);
        }
    }
}