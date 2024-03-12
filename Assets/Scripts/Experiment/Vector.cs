using System;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public GameObject Source;
    
    private Vector3 _axis;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _axis = Source.transform.localScale.normalized;
        _axis += _startPosition;
        transform.position = _axis;
        _axis -= Source.transform.localScale.normalized;
    }
}