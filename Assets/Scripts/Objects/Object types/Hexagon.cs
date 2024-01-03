using UnityEngine;

public class Hexagon : Eatable
{
	[SerializeField] private GameObject _hexagon;

	public override EatableShapes GetMyShape()
	{
		return EatableShapes.Hexagon;
	}

	public override GameObject GetPlayerShape()
	{
		Destroy(gameObject);
		return _hexagon;
	}
}
