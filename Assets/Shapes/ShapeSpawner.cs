using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _shapePrefabs;
    [SerializeField] private float _secondSpawn;
    [SerializeField] private float _minTras;
    [SerializeField] private float _maxTras;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;

    private void Start()
    {
        StartCoroutine(ShapeSpawn());
        _rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator ShapeSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(_minTras, _maxTras);
            var position = new Vector3(transform.position.x, wanted);
            GameObject gameObject = Instantiate(_shapePrefabs[Random.Range(0, _shapePrefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(_secondSpawn);
            Destroy(gameObject, 10f);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}