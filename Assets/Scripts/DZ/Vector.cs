using System;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public Vector3 Axis;

    private void Start()
    {
        transform.position = Axis.normalized;
    }

    void Update()
    {
        
    }
}