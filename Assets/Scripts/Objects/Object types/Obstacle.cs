using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public void OnHit()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<ShapeDestroyer>())
		{
			Destroy(gameObject);
		}
	}
}