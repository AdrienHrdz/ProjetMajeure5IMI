using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPhyllo : MonoBehaviour
{
    private GameObject parent;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        /*offset = transform.postion - parent.transform.position;*/
        offset = new Vector3(0, 0, 100);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += offset;
    }
}
