using UnityEngine;

public class Hexagon : Eatable
{
	[SerializeField] private GameObject _hexagon;

	public override GameObject OnHit()
	{
		Destroy(gameObject);
		return _hexagon;
	}
}
