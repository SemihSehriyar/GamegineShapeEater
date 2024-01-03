using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	private void Start()
	{
		Missions.OnGameFinish += FinishEffect;
	}

	private void OnDestroy()
	{
		Missions.OnGameFinish -= FinishEffect;
	}

	private void FinishEffect()
	{
		GetComponent<ParticleSystem>().Play();
	}
}
