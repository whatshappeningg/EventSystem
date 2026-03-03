using UnityEngine;

public class SoundController : MonoBehaviour
{
	#region Fields
	[SerializeField] private AudioClip _damageSound;
	[SerializeField] private AudioClip _dieSound;
	private AudioSource _audioSource;

	#endregion

	#region Unity Callbacks
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	#endregion

	#region Public Methods
	public void PlayDamageSound()
	{
		_audioSource.clip = _damageSound;
		_audioSource.Play();
	}
	public void PlayDieSound()
	{
		_audioSource.clip = _dieSound;
		_audioSource.Play();
	}

	#endregion
}
