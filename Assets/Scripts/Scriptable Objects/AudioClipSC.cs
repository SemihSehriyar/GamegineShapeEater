using UnityEngine;

[CreateAssetMenu(fileName = "A", menuName = "Scriptables/AudioClips")]
public class AudioClipSC : ScriptableObject
{
	public AudioClip[] audioClips;

	public AudioClip StartGame()
	{
		return audioClips[0];
	}

	public AudioClip EatSound()
	{
		return audioClips[1];
	}

	public AudioClip FinishGame()
	{
		return audioClips[2];
	}

	public AudioClip FinishGameEffect()
	{
		return audioClips[3];
	}
}