using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSize {
    public int x { get; private set; }
    public int y { get; private set; }
    public int z { get; private set; }
    
    public GridSize(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
