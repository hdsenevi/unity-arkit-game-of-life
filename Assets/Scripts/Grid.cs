using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private GridElement[ , , ] _gridElements;

    public Grid(int xSize, int ySize, int zSize, GameObject gridVisualPrefab, Transform parentTransform)
    {
        _gridElements = new GridElement[xSize, ySize, zSize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    _gridElements[x, y, z] = new GridElement(x, y, z, gridVisualPrefab, parentTransform);
                }
            }
        }

        GridElement ge = GetGridElementAtIndex(5, 0, 5);
        foreach (Vector3 neighbour in ge.neighbours)
        {
            GridElement element = GetGridElementAtIndex((int)neighbour.x, (int)neighbour.y, (int)neighbour.z);
            element.SetState(GridElement.ElementState.Alive);
        }
    }

    public GridElement GetGridElementAtIndex(int xIndex, int yIndex, int zIndex)
    {
        return _gridElements[xIndex, yIndex, zIndex];
    }

//    public GridElement[] GetNeighboursOf(int xIndex, int yIndex, int zIndex)
//    {
//        
//    }
}