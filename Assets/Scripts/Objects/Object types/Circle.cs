using UnityEngine;

public class Circle : Eatable
{
	[SerializeField] private GameObject _circle;

	public override GameObject OnHit()
	{
		Destroy(gameObject);
		return _circle;
	}
}
