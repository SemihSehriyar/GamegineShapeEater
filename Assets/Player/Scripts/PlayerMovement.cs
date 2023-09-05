using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    //public Rigidbody2D _rb;
    private float _speed = 0.1f;
    private float _speedVertical = 0.01f;
    private Touch _touch;
    private Vector2 _lastPosition;
    private bool _isMoving;

    private void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(_rb);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {

            }
        }
    }

    private void FixedUpdate() 
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}