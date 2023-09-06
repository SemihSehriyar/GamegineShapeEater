using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _xMax;
    [SerializeField] private float _yMax;
    [SerializeField] private float _yMin;
    [SerializeField] private float _xMin;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        float x = Mathf.Clamp(_player.transform.position.x, _xMin, _xMax);
        float y = Mathf.Clamp(_player.transform.position.y, _yMin, _yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}