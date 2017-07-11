using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public enum NeighboutAccessType
    {
        OnlyLive,
        OnlyDead,
        LiveAndDeadBoth
    }
    
    private GridElement[ , , ] _gridElements;
    private readonly GridSize _gridSize;

    public Grid(int xSize, int ySize, int zSize, GameObject gridVisualPrefab, Transform parentTransform)
    {
        _gridSize = new GridSize(xSize, ySize, zSize);
        _gridElements = new GridElement[_gridSize.x, _gridSize.y, _gridSize.z];

        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                for (int z = 0; z < _gridSize.z; z++)
                {
                    _gridElements[x, y, z] = new GridElement(x, y, z, gridVisualPrefab, parentTransform, ref _gridSize);
                }
            }
        }
    }

    public GridElement GetGridElementAtIndex(int xIndex, int yIndex, int zIndex)
    {
        return _gridElements[xIndex, yIndex, zIndex];
    }
    
    public GridElement GetGridElementAtIndex(GridIndexPath indexPath)
    {
        return _gridElements[indexPath.xIndex, indexPath.yIndex, indexPath.zIndex];
    }

    public GridElement[] GetNeighboursOfElement(GridElement findNeighboursOf, NeighboutAccessType neighboutAccess = NeighboutAccessType.LiveAndDeadBoth)
    {
        List<GridElement> neigbours = new List<GridElement>();
        foreach (GridIndexPath neighbourIndexPath in findNeighboursOf.neighbours)
        {
            GridElement element = GetGridElementAtIndex(neighbourIndexPath);

            switch (neighboutAccess)
            {
                case NeighboutAccessType.OnlyDead:
                    if (!element.IsLive())
                    {
                        neigbours.Add(element);
                    }
                    break;
                case NeighboutAccessType.OnlyLive:
                    if (element.IsLive())
                    {
                        neigbours.Add(element);
                    }
                    break;
                case NeighboutAccessType.LiveAndDeadBoth:
                    neigbours.Add(element);
                    break;
            }
        }

        return neigbours.ToArray();
    }

    public GridElement[] GetAllElements()
    {
        List<GridElement> liveElements = new List<GridElement>();
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                for (int z = 0; z < _gridSize.z; z++)
                {
                    GridElement ge = GetGridElementAtIndex(x, y, z);
//                    if (ge.IsLive())
//                    {
                        liveElements.Add(ge);
//                    }
                }
            }
        }

        return liveElements.ToArray();
    }
}