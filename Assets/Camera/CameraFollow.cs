using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _xMax;
    [SerializeField] private float _xMin;
   
    private void LateUpdate()
    {
        float x = Mathf.Clamp(_player.transform.position.x, _xMin, _xMax);
        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}