using UnityEngine;
using System.Collections.Generic;
using System;

namespace Inventory
{
	public class InventorySystem : MonoBehaviour
	{
		#region Properties
		[SerializeField] public List<Item> ItemsList = new List<Item>();
		public event Action OnInitialize;
		public event Action OnConsumeItem;

		#endregion

		#region Fields
		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _foods;
		[SerializeField] private Other[] _others;

		#endregion

		#region Unity Callbacks
		void Start()
		{
			InitializeItems();
		}

		#endregion

		#region Public Methods
		public void SellCurrentItem(Item currentItem)
		{
			(currentItem as ISellable).Sell();
			Consume();
		}
		public void UseCurrentItem(Item currentItem)
		{
			(currentItem as IUsable).Use();
			if (currentItem is IConsumable)
				Consume();
		}

		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			//Weapons
			for (int i = 0; i < _weapons.Length; i++)
				ItemsList.Add(_weapons[i]);

			//Food
			for (int i = 0; i < _foods.Length; i++)
				ItemsList.Add(_foods[i]);

			//Other
			for (int i = 0; i < _others.Length; i++)
				ItemsList.Add(_others[i]);

			OnInitialize?.Invoke();
		}
		private void Consume()
		{
			OnConsumeItem?.Invoke();
		}

		#endregion
	}
}
