using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _vertical;
    private Rigidbody2D _rb;
    //public Rigidbody2D _rb;
    private float _speed = 5f;
    private float _speedVertical = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(_rb);
    }

    private void Update()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, Input.GetAxisRaw("Vertical") * _speedVertical);
    }

    private void FixedUpdate() 
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}