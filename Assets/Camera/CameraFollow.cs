using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _followSpeed = 2f;
    private float _yOffSet = 1f;
    private Transform _target;
    void Update()
    {
        Vector3 newPos = new Vector3(_target.position.x , _target.position.y + _yOffSet , -10f);
        transform.position = Vector3.Slerp(transform.position,newPos, _followSpeed * Time.deltaTime);
    }
}
