using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    

    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }
    private void Update()
    {
        transform.position = Target.position + Offset;
    }
    
}
