using UnityEngine;

public class Square : Eatable
{
	[SerializeField] private GameObject _square;

	public override EatableShapes GetMyShape()
	{
		return EatableShapes.Square;
	}

	public override GameObject GetPlayerShape()
	{
		Destroy(gameObject);
		return _square;
	}
}
