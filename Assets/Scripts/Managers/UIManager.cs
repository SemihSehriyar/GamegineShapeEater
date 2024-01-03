using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
	private GameObject _currentUIObj;
	private int _index;
	[SerializeField] private TextMeshProUGUI _eatedAmountUGUI;
	[SerializeField] private GameObject[] _missionsUIObj;
	[SerializeField] private GameObject _finishPanel;
	[SerializeField] private Image[] _filledImage;

	public static event Action OnGameStart;

	private void Start()
	{
		_currentUIObj = _missionsUIObj[0];
		Missions.OnChangeMission += ChangeUI;
		Missions.OnShapeCount += Count;
		Missions.OnShapeCount += ChangeFillAmount;
		Missions.OnGameFinish += FinishPanel;
	}

	private void OnDestroy()
	{
		Missions.OnChangeMission -= ChangeUI;
		Missions.OnShapeCount -= Count;
		Missions.OnShapeCount -= ChangeFillAmount;
		Missions.OnGameFinish -= FinishPanel;
	}

	private void ChangeUI(int currentMissionIndex)
	{
		_index = currentMissionIndex;
		_currentUIObj.gameObject.SetActive(false);
		_currentUIObj = _missionsUIObj[currentMissionIndex];
		_currentUIObj.gameObject.SetActive(true);
	}

	private void Count(int eatedShape, int missionEatNumber)
	{
		_eatedAmountUGUI.text = eatedShape.ToString() + "/" + missionEatNumber.ToString();
	}

	private void ChangeFillAmount(int eatedShape, int missionEatNumber)
	{
		_filledImage[_index].fillAmount = (float)eatedShape / missionEatNumber;
	}

	private void FinishPanel()
	{
		_finishPanel.SetActive(true);
	}

	public void StartGame()
	{
		OnGameStart?.Invoke();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}