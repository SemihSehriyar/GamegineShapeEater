using UnityEngine;

public class Hexagon : Eatable
{
	public override ShapeInfo OnHit()
	{
		return _model;
	}
}
