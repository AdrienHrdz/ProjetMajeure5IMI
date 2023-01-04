using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    public float _degree;
    public float _scale;
    public int _numberStart;
    public int _stepSize;
    public int _maxIterations;

    // Lerping
    public bool _useLerping;
    public float _intervalLerp;
    private bool _isLerping;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _timeStartedLerping;


    private int _number;
    private int _currentIteration;
    private TrailRenderer _trailRenderer;
    private Vector2 _phyllotaxisPosition;

    private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(number);

        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);

        return new Vector2(x, y);
    }


    void StartLerping()
    {
        _isLerping = true;
        _timeStartedLerping = Time.time;
        _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
        _startPosition = this.transform.localPosition;
        _endPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
    }


    void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _number = _numberStart;
        transform.localPosition = CalculatePhyllotaxis(_degree, _scale, _number);
        if(_useLerping)
        {
            StartLerping();
        }
    }

    private void FixedUpdate()
    {
        if(_useLerping)
        {
            if (_isLerping)
            {
                float timeSinceStarted = Time.time - _timeStartedLerping;
                float percentageComplete = timeSinceStarted / _intervalLerp;

                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);

                if (percentageComplete >= 0.97f)
                {
                    transform.localPosition = _endPosition;
                    _number += _stepSize;
                    _currentIteration++;
                    if (_currentIteration <= _maxIterations)
                    {
                        StartLerping();
                    }
                    else
                    {
                        _isLerping = false;
                    }
                    
                }
            }
        }
        else
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
            transform.localPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }
    }

}
