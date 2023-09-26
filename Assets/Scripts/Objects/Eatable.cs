using UnityEngine;

public abstract class Eatable : MonoBehaviour, ICollectable
{
	[SerializeField] protected ShapeInfo _model;

	public abstract ShapeInfo OnHit();

	public virtual void OpenSprite() 
	{
		//_model.enabled = true;
	}

	public virtual void CloseSprite() 
	{
		//_model.enabled = false;
	}
}