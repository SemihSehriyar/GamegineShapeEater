using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
	[SerializeField] public List<GameObject> _deletedObj;
	private Rigidbody2D _rb;
	private GameObject _shapeToSpawn;
	[SerializeField] private GameObject[] _shapePrefabs;
	[SerializeField] private float _secondSpawn;
	[SerializeField] private float _speed;
	[SerializeField] private float _yPos;

	private void Start()
	{
		_secondSpawn = 0.5f;
		StartCoroutine(ShapeSpawn());
		_rb = GetComponent<Rigidbody2D>();
		_deletedObj = new List<GameObject>();
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_speed, _rb.velocity.y);
	}

	public IEnumerator ShapeSpawn()
	{
		while (true)
		{
			WaitForSeconds wait = new WaitForSeconds(_secondSpawn);
			_yPos = Random.Range(-1.5f, 1.5f) * 5;
			yield return wait;
			int rand = Random.Range(0, _shapePrefabs.Length);
			_shapeToSpawn = _shapePrefabs[rand];
			_deletedObj.Add(Instantiate(_shapeToSpawn, new Vector3(transform.position.x, _yPos, transform.position.z), Quaternion.identity));
		}
	}
}