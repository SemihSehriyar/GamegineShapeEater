/*using System;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	[SerializeField] private GameObject _spawner;
	[SerializeField] private GameObject _missionBG;
	[SerializeField] private GameObject _confetti;
	[SerializeField] private PlayerMovement _player;

    public static event Action OnGameStart;

    private void Start()
	{
		*//*		_player.enabled = false;
				_spawner.SetActive(false);
				_missionBG.SetActive(false);
				_confetti.SetActive(false);*//*
		StartGame.OnGameStart += PlayGame;
    }

	public void PlayGame()
	{
        OnGameStart?.Invoke();
        _player.enabled = true;
		_spawner.SetActive(true);
		_missionBG.SetActive(true);
		_confetti.SetActive(false);
	}

    private void OnDestroy()
    {
        StartGame.OnGameStart -= PlayGame;
    }
}*/