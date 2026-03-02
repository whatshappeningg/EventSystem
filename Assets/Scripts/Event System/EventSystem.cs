using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private InputSystem _inputSystem;

	[SerializeField] private Points _points;
	[SerializeField] private Health _payerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
	{
		//Event Listener
		//_payerHealth.OnGetDamage += OnGetDamage;
		//_payerHealth.OnGetHeal += OnGetHeal;
		_inputSystem.OnKeyDamage += OnGetDamage;
		_inputSystem.OnKeyHeal += OnGetHeal;
		_inputSystem.OnKeyPoints += OnAddPoints;
		_inputSystem.OnKeyAddLevel += OnAddLevel;

		_payerHealth.OnDie += OnDie;

		//_points.OnGetPoints += OnAddPoints;
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
		throw new NotImplementedException();
	}
	#endregion
}
