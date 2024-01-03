using System;
using UnityEngine;

public class Missions : MonoBehaviour
{
	[SerializeField] private EatableShapes[] _allMissions;
	[SerializeField] private int _missionEatNumber;
	[SerializeField] private int _currentMissionIndex;
	[SerializeField] private int _currentEated;

	public static event Action OnGameFinish;
	public static event Action<int> OnChangeMission;
	public static event Action<int, int> OnShapeCount;

	private void Start()
	{
		_currentMissionIndex = 0;
		_currentEated = 0;
		PlayerCollide.OnEat += ShapeControl;
	}

	private void OnDestroy()
	{
		PlayerCollide.OnEat -= ShapeControl;
	}

	private void ShapeControl(EatableShapes eatedShape)
	{
		if (_allMissions[_currentMissionIndex] == eatedShape)
		{
			_currentEated++;
			if (_currentEated == _missionEatNumber)
			{
				_currentEated = 0;
				_currentMissionIndex++;
				if (_allMissions.Length > _currentMissionIndex)
				{
					OnChangeMission?.Invoke(_currentMissionIndex);
				}
				else
				{
					OnGameFinish?.Invoke();
				}
			}
			OnShapeCount?.Invoke(_currentEated, _missionEatNumber);
		}
	}
}