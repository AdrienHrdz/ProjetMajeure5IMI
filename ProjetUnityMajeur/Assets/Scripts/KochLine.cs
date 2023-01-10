using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator
{
    LineRenderer _lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _position.Length;
        _lineRenderer.SetPositions(_position);
        //_lineRenderer.enabled = true;
        //_lineRenderer.useWorldSpace = false;
        //_lineRenderer.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
