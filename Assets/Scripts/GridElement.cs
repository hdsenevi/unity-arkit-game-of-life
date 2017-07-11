using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
    public enum ElementState
    {
        Live,
        Dead
    }

    public ElementState state { get; set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

    private Vector3 _pos;

    public Vector3 XYZ
    {
        get { return _pos; }
    }

    public List<GridIndexPath> neighbours { get; private set; }

    protected GameObject _gameObject;

    public GridElement(int x, int y, int z, GameObject gridVisualPrefab, Transform parentTransform, ref GridSize gridCapacity)
    {
        X = x;
        Y = y;
        Z = z;

        _pos = new Vector3(X, Y, Z);
        neighbours = new List<GridIndexPath>();
        _gameObject = GameObject.Instantiate(gridVisualPrefab, _pos, Quaternion.identity);

        if (parentTransform != null)
        {
            _gameObject.transform.parent = parentTransform;
        }

        // This will cache gridIndexSet values for neightbours so that we don't 
        // have to do that calculation over and over again.
        // OPTIMIZATION : can do this lazily
        CalculateNeighbours(_pos, ref gridCapacity);
        
        if (Random.Range(0, 100) % 2 == 0)
            this.SetState(ElementState.Dead);
        else 
            this.SetState(ElementState.Live);
    }

    public void SetState(ElementState incomingState)
    {
        state = incomingState;
        
        switch (state)
        {
            case ElementState.Live:
                _gameObject.SetActive(true);
                break;
            case ElementState.Dead:
                _gameObject.SetActive(false);
                break;
        }
    }

    private void CalculateNeighbours(Vector3 currentGridIndexSet, ref GridSize gridCapacity)
    {
        int xCapaxity = gridCapacity.x - 1;
        int yCapaxity = gridCapacity.y - 1;
        int zCapaxity = gridCapacity.z - 1;
        
        int i = (int) currentGridIndexSet.x;
        int j = (int) currentGridIndexSet.y;
        int k = (int) currentGridIndexSet.z;

        for (var x = Mathf.Max(0, i - 1); x <= Mathf.Min(i + 1, xCapaxity); x++)
        {
            for (var y = Mathf.Max(0, j - 1); y <= Mathf.Min(j + 1, yCapaxity); y++)
            {
                for (var z = Mathf.Max(0, k - 1); z <= Mathf.Min(k + 1, zCapaxity); z++)
                {
                    if (x != i || y != j || z != k)
                    {
                        neighbours.Add(new GridIndexPath(x, y, z));
                    }
                }
            }
        }
    }

    public bool IsLive()
    {
        return this.state == ElementState.Live ? true : false;
    }
}