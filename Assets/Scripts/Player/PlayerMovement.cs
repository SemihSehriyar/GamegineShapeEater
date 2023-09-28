using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 _clickedPos;
	private Rigidbody2D _rb;
	[SerializeField] private float _speedRb;
	[SerializeField] private float _speed;
	[SerializeField] private float _duration;
	[SerializeField] private float _strength;
	[SerializeField] private float _randomness;
	[SerializeField] private int _vibrato;
	[SerializeField] private Vector3 _rotateUp;
	[SerializeField] private Vector3 _rotateDown;
	[SerializeField] private Transform _model;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = new Vector2(_speedRb, 0);
		_clickedPos.y = transform.position.y;
		PlayerCollide.OnHit += Shake;
	}

	private void OnDestroy()
	{
		PlayerCollide.OnHit -= Shake;
	}

	private void Update()
	{
		Movement();
	}

	private void Movement() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			_clickedPos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		}
		if (Mathf.Abs(_clickedPos.y - transform.position.y) < 0.1f)
		{
			transform.position = new Vector2(transform.position.x, _clickedPos.y);
			_model.rotation = Quaternion.Euler(Vector3.zero);
		}
		else if (_clickedPos.y - transform.position.y > 0f)
		{
			_clickedPos.x = transform.position.x;
			transform.position = Vector2.MoveTowards(transform.position, _clickedPos, _speed * Time.deltaTime);
			_model.rotation = Quaternion.Euler(_rotateUp);
		}
		else
		{
			_clickedPos.x = transform.position.x;
			transform.position = Vector2.MoveTowards(transform.position, _clickedPos, _speed * Time.deltaTime);
			_model.rotation = Quaternion.Euler(_rotateDown);
		}
	}

	private void Shake()
	{ 
		_rb.velocity = Vector3.zero;
		_model.transform.DOShakePosition(_duration, _strength, _vibrato, _randomness).OnComplete(() =>
		{ 
			_rb.velocity = new Vector2(_speedRb, 0);
		});
	}
}