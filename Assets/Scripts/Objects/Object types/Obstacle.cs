using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public void OnHit()
	{
		
	}

	private void Start()
	{
		Missions.OnGameFinish += DestroyShapes;
	}

	private void OnDestroy()
	{
		Missions.OnGameFinish -= DestroyShapes;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<ShapeDestroyer>())
		{
			Destroy(gameObject);
		}
	}

	private void DestroyShapes()
	{
		gameObject.SetActive(false);
	}
}