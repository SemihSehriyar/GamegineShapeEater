using UnityEngine;

public class Square : Eatable
{
	[SerializeField] private GameObject _square;

	public override GameObject OnHit()
	{
		Destroy(gameObject);
		return _square;
	}
}
