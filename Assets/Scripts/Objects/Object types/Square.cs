using UnityEngine;

public class Square : Eatable
{
	public override ShapeInfo OnHit()
	{
		return _model;
	}
}
