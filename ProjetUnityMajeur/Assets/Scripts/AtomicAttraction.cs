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
    GameObject[] _attractorArray, _atomArray;
    [Range(1,64)]
    public int _amoutOfAtomsPerPoint;
    public Vector2 _atomScaleMinMax;
    float[] _atomScaleSet;
    public float _strenghtOfAttraction, _maxMagnitude, _randomPosDistance; 
    public bool _useGravity;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _attractPoints.Length; i++)
        {
            float evaluateStep = 0.125f;
            Color color = _gradient.Evaluate(Mathf.Clamp(evaluateStep * _attractPoints[i], 0, 7));
            Gizmos.color = color;

            Vector3 pos = new Vector3(
                transform.position.x + _spacingDirection.x * i * _spacingBetweenAttractPoints,
                transform.position.y + _spacingDirection.y * i * _spacingBetweenAttractPoints,
                transform.position.z + _spacingDirection.z * i * _spacingBetweenAttractPoints);
            Gizmos.DrawSphere(pos, _scaleAttractPoints);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _attractorArray = new GameObject[_attractPoints.Length];
        _atomArray = new GameObject[_attractPoints.Length * _amoutOfAtomsPerPoint];
        _atomScaleSet = new float[_attractPoints.Length * _amoutOfAtomsPerPoint];

        int _countAtom = 0;
        // instantiate points
        for (int i = 0; i < _attractPoints.Length; i++)
        {
            GameObject _attractorInstance = (GameObject)Instantiate(_attractor);
            _attractorArray[i] = _attractorInstance;

            _attractorInstance.transform.position = new Vector3(
                transform.position.x + _spacingDirection.x * i * _spacingBetweenAttractPoints,
                transform.position.y + _spacingDirection.y * i * _spacingBetweenAttractPoints,
                transform.position.z + _spacingDirection.z * i * _spacingBetweenAttractPoints);
            _attractorInstance.transform.parent = this.transform;
            _attractorInstance.transform.localScale = new Vector3(_scaleAttractPoints, _scaleAttractPoints, _scaleAttractPoints);

            // instantiate atoms
            for (int j = 0; j < _amoutOfAtomsPerPoint; j++)
            {
                GameObject _atomInstance = (GameObject)Instantiate(_atom);
                _atomArray[_countAtom] = _atomInstance;
                _atomInstance.GetComponent<AttractTo>()._attractedTo = _attractorArray[i].transform;
                _atomInstance.GetComponent<AttractTo>()._strenghtOfAttraction = _strenghtOfAttraction;
                _atomInstance.GetComponent<AttractTo>()._maxMagnitude = _maxMagnitude;
                _atomInstance.GetComponent<Rigidbody>().useGravity = _useGravity;
                _atomInstance.transform.position = new Vector3(
                    _attractorArray[i].transform.position.x + Random.Range(-_randomPosDistance, _randomPosDistance),
                    _attractorArray[i].transform.position.y + Random.Range(-_randomPosDistance, _randomPosDistance),
                    _attractorArray[i].transform.position.z + Random.Range(-_randomPosDistance, _randomPosDistance));
                
                float _randomScale = Random.Range(_atomScaleMinMax.x, _atomScaleMinMax.y);
                _atomScaleSet[_countAtom] = _randomScale;
                _atomInstance.transform.localScale = new Vector3(_atomScaleSet[_countAtom], _atomScaleSet[_countAtom], _atomScaleSet[_countAtom]);

                // _atomInstance.transform.parent = transform.parent.transform; 
                _countAtom++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
