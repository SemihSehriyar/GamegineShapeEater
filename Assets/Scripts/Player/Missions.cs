using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
	[SerializeField] private Image[] _fillImage;
	[SerializeField] private EatableShapes[] _missionOrder;
	[SerializeField] private TextMeshProUGUI _numText;
	[SerializeField] private GameObject[] _missionImages;
	[SerializeField] private GameObject _spawner;
	[SerializeField] private GameObject _missionBG;
	[SerializeField] private GameObject _finish;
	[SerializeField] private GameObject _start;
	[SerializeField] private GameObject _confetti;
	[SerializeField] private PlayerMovement _player;
	[SerializeField] private AudioSource _endSrc;
	[SerializeField] private AudioSource _confettiSrc;
	[SerializeField] private int _eatCount;

	private EatableShapes _missionShape;
	private int _count;
	private int _missionNum;
	private int _imageNum;
	private int _filledNum;
	private float _max;
	private float _fillAmount;

	private void Start()
	{
		_max = 5f;
		_imageNum = 0;
		_missionNum = 0;
		_count = 0;
		_missionShape = _missionOrder[_missionNum];
	}

	internal void EatedShape(EatableShapes eatedShapes)
	{
		if (_missionShape == eatedShapes)
		{
			_eatCount++;
			GetCurrentFill();
			_count++;
			Count();
			if (_eatCount == 5)
			{
				if (_missionNum < 2)
				{
					_count = 0;
					Count();
					MissionChange();
					_eatCount = 0;
					_filledNum++;
					_missionNum++;
					_missionShape = _missionOrder[_missionNum];
				}
				else
				{
					_endSrc.Play();
					_confettiSrc.Play();
					Debug.Log("QUIT");
					_spawner.SetActive(false);
					_player.GetComponent<PlayerMovement>()._rb.constraints = RigidbodyConstraints2D.FreezeAll;
					foreach (GameObject game in _spawner.GetComponent<ShapeSpawner>()._deletedObj)
					{
						Destroy(game);
					}
					_finish.SetActive(true);
					_confetti.SetActive(true);
					_missionBG.SetActive(false);
				}
			}
		}
	}

	public void GetCurrentFill()
	{
		_fillAmount = _eatCount / _max;
		_fillImage[_filledNum].fillAmount = _fillAmount;
	}

	public void MissionChange()
	{
		_missionImages[_imageNum].SetActive(false);
		_imageNum++;
		_missionImages[_imageNum].SetActive(true);
	}

	public void Count()
	{
		_numText.text = _count + " / 5";
	}
}