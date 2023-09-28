using System;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
	[SerializeField] private GameObject _currentObj;

	public static event Action OnHit;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent(out ICollectable collectable))
		{
			Destroy(_currentObj);
			var prefab = collectable.OnHit();
			_currentObj = Instantiate(prefab, transform.position, Quaternion.identity, transform);
		}
		else if (collider.TryGetComponent(out Obstacle obstacle))
		{
			OnHit?.Invoke();
			obstacle.OnHit();
		}
	}
}