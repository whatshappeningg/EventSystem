using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class UIController : MonoBehaviour
    {
        #region Properties
        [SerializeField] public ItemButtom CurrentItemSelected { get; set; }

        public event Action OnSellItem;
        public event Action OnUseItem;

        #endregion

        #region Fields
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private ItemButtom _prefabButton;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _sellButton;

        #endregion

        #region Unity Callbacks
        void Start()
        {
            _sellButton.onClick.AddListener(() => OnSellItem?.Invoke());
            _useButton.onClick.AddListener(() => OnUseItem?.Invoke());
        }

        #endregion

        #region Public Methods
        public void InitializeUI(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                ItemButtom newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
                newButton.CurrentItem = items[i];
                newButton.OnClick += () => AddItem(newButton);
            }
            _prefabButton.gameObject.SetActive(false);
            _sellButton.gameObject.SetActive(false);
            _useButton.gameObject.SetActive(false);
        }
        public void DestroyButton()
        {
            Destroy(CurrentItemSelected.gameObject);
            CurrentItemSelected = null;
            _sellButton.gameObject.SetActive(false);
            _useButton.gameObject.SetActive(false);
        }

        #endregion

        #region Private Methods
        private void AddItem(ItemButtom buttonItemToAdd)
        {
            ItemButtom newButtonItem = Instantiate(buttonItemToAdd, _inventoryPanel);
            newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
            newButtonItem.OnClick += () => SelecItem(newButtonItem);
        }
        private void SelecItem(ItemButtom currentItem)
        {
            CurrentItemSelected = currentItem;
            //If Sellable
            if (CurrentItemSelected.CurrentItem is ISellable)
                _sellButton.gameObject.SetActive(true);
            else
                _sellButton.gameObject.SetActive(false);

            //If Usable
            if (CurrentItemSelected.CurrentItem is IUsable)
                _useButton.gameObject.SetActive(true);
            else
                _useButton.gameObject.SetActive(false);
        }

        #endregion
    }
}
