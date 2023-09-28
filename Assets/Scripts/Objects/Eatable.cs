using UnityEngine;

public abstract class Eatable : MonoBehaviour, ICollectable
{
	public abstract GameObject OnHit();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<ShapeDestroyer>())
		{
			Destroy(gameObject);
		}
	}
}