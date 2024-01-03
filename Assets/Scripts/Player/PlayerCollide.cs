using System;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
	[SerializeField] private GameObject _currentObj;
	[SerializeField] private Transform _model;

	public static event Action OnHit;
	public static event Action<EatableShapes> OnEat;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent(out ICollectable collectable))
		{
			Destroy(_currentObj);
			var prefab = collectable.GetPlayerShape();
			_currentObj = Instantiate(prefab, transform.position, Quaternion.identity, _model);
			_currentObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
			OnEat?.Invoke(collectable.GetMyShape());
		}
		else if (collider.TryGetComponent(out Obstacle obstacle))
		{
			OnHit?.Invoke();
			obstacle.OnHit();
		}
	}
}