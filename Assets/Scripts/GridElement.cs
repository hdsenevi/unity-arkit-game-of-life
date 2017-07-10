using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

    private Vector3 _pos;
    public Vector3 XYZ
    {
        get {
            return _pos; 
        }
    }

    public GridElement(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        
        _pos = new Vector3(X, Y, Z);
    }
}