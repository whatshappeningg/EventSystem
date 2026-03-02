using UnityEngine;
using System;

public class Points : MonoBehaviour
{
	#region Properties
	public int CurrentPoints { get; set; }
	public int CurrentLevel { get; set; }
	public event Action OnAddLevel;

	#endregion

	#region Unity Callbacks
	void Start()
	{
		CurrentPoints = 0;
	}

	#endregion

	#region Public Methods
	public void AddPoints(int pointsToAdd)
	{
		CurrentPoints += pointsToAdd;
		if (CurrentPoints % 500 == 0)
		{
			CurrentLevel++;
			OnAddLevel?.Invoke();
		}
	}

	#endregion
}
