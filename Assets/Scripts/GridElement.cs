using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
    public enum ElementState
    {
        Alive,
        Dead,
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

    protected GameObject _gameObject;

    public GridElement(int x, int y, int z, GameObject gridVisualPrefab, Transform parentTransform)
    {
        X = x;
        Y = y;
        Z = z;

        _pos = new Vector3(X, Y, Z);
        _gameObject = GameObject.Instantiate(gridVisualPrefab, _pos, Quaternion.identity);

        if (parentTransform != null)
        {
            _gameObject.transform.parent = parentTransform;
        }
        
        this.SetState(ElementState.Alive);
    }

    public void SetState(ElementState state)
    {
        switch (state)
        {
            case ElementState.Alive:
                _gameObject.SetActive(true);
                break;
            case ElementState.Dead:
            default:
                _gameObject.SetActive(false);
                break;
        }
    }
}