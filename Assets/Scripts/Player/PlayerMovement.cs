using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 3f;
    private float _speedVertical = 5f;
    private float _previousDistanceToTouchPos;
    private float _currentDistanceToTouchPos;
    private Touch _touch;
    private Vector3 _touchPosition;
    private Vector3 _whereToMove;
    private bool _isMoving = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            _currentDistanceToTouchPos = (_touchPosition - transform.position).magnitude;
        }
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                Debug.Log(Camera.main.ScreenToWorldPoint(_touch.position));
                if (Camera.main.ScreenToWorldPoint(_touch.position).y < transform.position.y)
                {
                    transform.eulerAngles = new Vector3(0, 0, -45);
                    _previousDistanceToTouchPos = 0f;
                    _currentDistanceToTouchPos = 0f;
                    _isMoving = true;
                    _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                    _touchPosition.z = 0;
                    _whereToMove = (_touchPosition - transform.position).normalized;
                    _rb.velocity = new Vector2(_whereToMove.x, _whereToMove.y * _speedVertical);
                }
                if (Camera.main.ScreenToWorldPoint(_touch.position).y > transform.position.y)
                {
                    transform.eulerAngles = new Vector3(0, 0, 45);
                    _previousDistanceToTouchPos = 0f;
                    _currentDistanceToTouchPos = 0f;
                    _isMoving = true;
                    _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                    _touchPosition.z = 0;
                    _whereToMove = (_touchPosition - transform.position).normalized;
                    _rb.velocity = new Vector2(_whereToMove.x, _whereToMove.y * _speedVertical);
                }
            }
        }
        if (_currentDistanceToTouchPos > _previousDistanceToTouchPos)
        {
            _isMoving = false;
            _rb.velocity = Vector2.zero;
        }
        if (_isMoving)
        {
            _previousDistanceToTouchPos = (_touchPosition - transform.position).magnitude;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}