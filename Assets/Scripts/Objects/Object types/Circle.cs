using UnityEngine;

public class Circle : Eatable
{
	[SerializeField] private GameObject _circle;

	public override EatableShapes GetMyShape()
	{
		return EatableShapes.Circle;
	}

	public override GameObject GetPlayerShape()
	{
		Destroy(gameObject);
		return _circle;
	}
}
