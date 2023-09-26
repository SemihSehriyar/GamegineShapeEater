using UnityEngine;

public class Circle : Eatable
{
	public override ShapeInfo OnHit()
	{
		return _model;
	}
}
