using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicAttraction : MonoBehaviour
{
    public GameObject _atom, _attractor;
    public Gradient _gradient; 
    public int[] _attractPoints;
    public Vector3 _spacingDirection;
    [Range(0, 20)]
    public float _spacingBetweenAttractPoints;
    [Range(0, 20)]
    public float _scaleAttractPoints;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _attractPoints.Length; i++)
        {
            float evaluateStep = 1.0f / _attractPoints.Length;
            Color color = _gradient.Evaluate(evaluateStep * i);
            Gizmos.color = color;

            Vector3 pos = new Vector3(transform.position.x + _spacingDirection.x * i * _spacingBetweenAttractPoints,
                                      transform.position.y + _spacingDirection.y * i * _spacingBetweenAttractPoints,
                                    transform.position.z + _spacingDirection.z * i * _spacingBetweenAttractPoints);
            Gizmos.DrawSphere(pos, _scaleAttractPoints);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
