using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClipSC audioClips;

	private void Start()
	{
		Missions.OnGameFinish += FinishAudio;
		UIManager.OnGameStart += StartAudio;
		PlayerCollide.OnEat += EatAudio;
	}

	private void OnDestroy()
	{
		Missions.OnGameFinish -= FinishAudio;
		UIManager.OnGameStart -= StartAudio;
		PlayerCollide.OnEat -= EatAudio;
	}

	private void EatAudio(EatableShapes obj)
	{
		var audio = gameObject.AddComponent<AudioSource>();
		audio.clip = audioClips.EatSound();
		audio.Play();
		StartCoroutine(KillAudio(audio));
	}

	private void StartAudio()
	{
		var audio = gameObject.AddComponent<AudioSource>();
		audio.clip = audioClips.StartGame();
		audio.Play();
		StartCoroutine(KillAudio(audio));
	}

	private void FinishAudio()
	{
		var audio = gameObject.AddComponent<AudioSource>();
		audio.clip = audioClips.FinishGame();
		audio.Play();
		StartCoroutine(KillAudio(audio));

		var audio1 = gameObject.AddComponent<AudioSource>();
		audio1.clip = audioClips.FinishGameEffect();
		audio1.Play();
		StartCoroutine(KillAudio(audio1));
	}

	private IEnumerator KillAudio(AudioSource audio)
	{
		yield return new WaitUntil(() => audio.isPlaying == false);
		Destroy(audio);
	}
}
