using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
	private Rigidbody2D _rb;
	private float _currentRate;
	[SerializeField] private int _speedRb;
	[SerializeField] float _minRate;
	[SerializeField] float _maxRate;
	[SerializeField] float _maxSpawnRate;
	[SerializeField] Vector2 _min;
	[SerializeField] Vector2 _max;
	[SerializeField] GameObject[] _shapes;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = new Vector2(_speedRb, 0);
		Missions.OnGameFinish += StopSpawn;
	}

	private void OnDestroy()
	{
		Missions.OnGameFinish -= StopSpawn;
	}

	private void Update()
	{
		_currentRate += Time.deltaTime;

		if (_currentRate > _maxSpawnRate)
		{
			RandomRate();
			Spawn();
		}
	}

	private void Spawn()
	{
		float randomY = Random.Range(_min.y, _max.y);
		Vector3 randomPosition = new Vector3(transform.position.x, randomY, 0f);
		Instantiate(_shapes[Random.Range(0, _shapes.Length)], randomPosition, Quaternion.identity);
	}

	private void RandomRate() 
	{
		_currentRate = 0f;
		_maxSpawnRate = Random.Range(_minRate, _maxRate);
	}

	private void StopSpawn()
	{
		enabled = false;
	}
}