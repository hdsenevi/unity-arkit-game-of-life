using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridIndexPath {
    
    public int xIndex { get; private set; }
    public int yIndex { get; private set; }
    public int zIndex { get; private set; }
    
    public GridIndexPath(int x, int y, int z)
    {
        this.xIndex = x;
        this.yIndex = y;
        this.zIndex = z;
    }
}
