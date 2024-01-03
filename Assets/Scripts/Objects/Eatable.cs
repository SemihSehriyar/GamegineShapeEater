using UnityEngine;

public abstract class Eatable : MonoBehaviour, ICollectable
{
	protected EatableShapes shapes;

	public abstract EatableShapes GetMyShape();
	public abstract GameObject GetPlayerShape();

	protected virtual void Start()
	{
		Missions.OnGameFinish += DestroyShapes;
	}

	protected virtual void OnDestroy()
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

public enum EatableShapes 
{
	Square,
	Circle,
	Hexagon
}