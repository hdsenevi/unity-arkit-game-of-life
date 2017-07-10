using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private GridElement[ , , ] _gridElements;

    public Grid(int xSize, int ySize, int zSize)
    {
        _gridElements = new GridElement[xSize, ySize, zSize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    _gridElements[x, y, z] = new GridElement(x, y, z);
                }
            }
        }

        GridElement ge = _gridElements[0, 5, 9] as GridElement;
        Debug.Log(ge.XYZ);
    }
}