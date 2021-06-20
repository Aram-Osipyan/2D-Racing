using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform followTransform;
    Vector3 currentCameraPos = new Vector3();
    Vector3 CurrentCameraPos
    {
        get
        {
            currentCameraPos.x = followTransform.position.x;
            currentCameraPos.y = followTransform.position.y;
            currentCameraPos.z = this.transform.position.z;
            return currentCameraPos;
        }
    }

    void FixedUpdate()
    {
        this.transform.position = CurrentCameraPos;


    }
}
