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

    public ElementState state { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

    private Vector3 _pos;

    public Vector3 XYZ
    {
        get { return _pos; }
    }

    public List<Vector3> neighbours { get; private set; }

    protected GameObject _gameObject;

    public GridElement(int x, int y, int z, GameObject gridVisualPrefab, Transform parentTransform)
    {
        X = x;
        Y = y;
        Z = z;

        _pos = new Vector3(X, Y, Z);
        neighbours = new List<Vector3>();
        _gameObject = GameObject.Instantiate(gridVisualPrefab, _pos, Quaternion.identity);

        if (parentTransform != null)
        {
            _gameObject.transform.parent = parentTransform;
        }

        // This will cache gridIndexSet values for neightbours so that we don't 
        // have to do that calculation over and over again.
        // OPTIMIZATION : can do this lazily
        CalculateNeighbours(_pos);
        
        this.SetState(ElementState.Dead);
    }

    public void SetState(ElementState state)
    {
        this.state = state;
        
        switch (this.state)
        {
            case ElementState.Live:
                _gameObject.SetActive(true);
                break;
            case ElementState.Dead:
                _gameObject.SetActive(false);
                break;
        }
    }

    private void CalculateNeighbours(Vector3 currentGridIndexSet)
    {
        int rowLimit = 10 - 1;
        int columnLimit = 10 - 1;
        int i = (int) currentGridIndexSet.x;
        int j = (int) currentGridIndexSet.z;

        for (var x = Mathf.Max(0, i - 1); x <= Mathf.Min(i + 1, rowLimit); x++)
        {
            for (var z = Mathf.Max(0, j - 1); z <= Mathf.Min(j + 1, columnLimit); z++)
            {
                if (x != i || z != j)
                {
                    neighbours.Add(new Vector3(x, 0, z));
                }
            }
        }
    }

    public bool IsLive()
    {
        return state == ElementState.Live ? true : false;
    }
}