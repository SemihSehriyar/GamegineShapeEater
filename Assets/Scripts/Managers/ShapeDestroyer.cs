using UnityEngine;

public class ShapeDestroyer : MonoBehaviour
{
	private Rigidbody2D _rb;
	private float _speedRb;

	private void Start()
	{
		_speedRb = 3f;
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = new Vector2(_speedRb, 0); 
	}
}
