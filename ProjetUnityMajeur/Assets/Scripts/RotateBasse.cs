using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBasse : MonoBehaviour
{   
    public AudioPeer _audioPeer;
    public Vector3 _rotateAxis;
    public Vector3 _rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).transform.LookAt(this.transform);

        this.transform.Rotate(_rotateAxis.x * _rotateSpeed.x * Time.deltaTime * AudioPeer._audioBand[0],
        _rotateAxis.y * _rotateSpeed.y * Time.deltaTime * AudioPeer._audioBand[0],
        _rotateAxis.z * _rotateSpeed.z * Time.deltaTime * AudioPeer._audioBand[0]);
    }
}
