using UnityEngine;

public class EventSystem : MonoBehaviour
{
	#region Fields
	[SerializeField] private InputSystem _inputSystem;

	[SerializeField] private Points _points;
	[SerializeField] private Health _payerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	#endregion

	#region Unity Callbacks
	void Start()
	{
		//Event Listener
		_inputSystem.OnKeyDamage += OnGetDamage;
		_inputSystem.OnKeyHeal += OnGetHeal;
		_inputSystem.OnKeyPoints += OnAddPoints;

		_points.OnAddLevel += OnAddLevel;

		_payerHealth.OnDie += OnDie;
	}


	#endregion

	#region Private Methods
	private void OnGetDamage()
	{
		_payerHealth.GetDamage(20);
		_sound.PlayDamageSound();
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnGetHeal()
	{
		_payerHealth.GetHeal(20);
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Destroy(_payerHealth.gameObject);
	}
	private void OnAddPoints()
	{
		_points.AddPoints(100);
		_ui.UpdatePoints(_points.CurrentPoints);
	}
	private void OnAddLevel()
	{
		_ui.UpdateLevel(_points.CurrentLevel);
	}

	#endregion
}
