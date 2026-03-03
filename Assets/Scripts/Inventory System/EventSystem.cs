using UnityEngine;

namespace Inventory
{
    public class EventSystem : MonoBehaviour
    {
        #region Fields
        [SerializeField] private InventorySystem _inventorySystem;
        [SerializeField] private UIController _ui;
        #endregion

        #region Unity Callbacks
        void Awake()
        {
            _inventorySystem.OnInitialize += OnInitializeUI;
            _inventorySystem.OnConsumeItem += OnDestroyButton;
            _ui.OnSellItem += OnSellItem;
            _ui.OnUseItem += OnUseItem;
        }

        #endregion

        #region Private Methods
        private void OnInitializeUI()
        {
            _ui.InitializeUI(_inventorySystem.ItemsList);
        }
        private void OnDestroyButton()
        {
            _ui.DestroyButton();
        }
        private void OnSellItem()
        {
            _inventorySystem.SellCurrentItem(_ui.CurrentItemSelected.CurrentItem);
        }
        private void OnUseItem()
        {
            _inventorySystem.UseCurrentItem(_ui.CurrentItemSelected.CurrentItem);
        }

        #endregion
    }
}
