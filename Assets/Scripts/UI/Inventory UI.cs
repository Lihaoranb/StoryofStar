using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LFarm.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public ItemTooltip itemTooltip;

        [Header("ÍÏ×§Í¼Æ¬")]
        public UnityEngine.UI.Image dragItem;
        [Header("Íæ¼Ò±³°üUI")]
        [SerializeField] 
        private GameObject bagUI;
        private bool bagOpened;
        [SerializeField]
        private SlotUI[] playerSlots;
        private void OnEnable()
        {
            EventHandler.UpdateInventoryUI += OnUpdateInventoryUI;

        }
        private void OnDisable()
        {
            EventHandler.UpdateInventoryUI -= OnUpdateInventoryUI;

        }

        private void OnUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
        {
            switch (location)
            {
                case InventoryLocation.Player:
                    for (int i = 0; i < playerSlots.Length; i++)
                    {
                        if (list[i].itemAmount>0)
                        {
                            var item = InventoryManager.Instance.GetItemDetails(list[i].itemID);
                            playerSlots[i].UpdateSlot(item, list[i].itemAmount);
                            
                        }
                        else
                        {
                            playerSlots[i].UpdateEmptySlot();
                        }
                    }
                    break;
            }
        }

        private void Start()
        {
            for (int i = 0;i<playerSlots.Length;i++)
            {
                playerSlots[i].slotIndex = i;
            }

            bagOpened = bagUI.active;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenBagUI();
            }
        }
        public void OpenBagUI()
        {
            bagOpened =!bagOpened;
            bagUI.SetActive(bagOpened);
        }

        public void UpdateSlotHighlight(int Index)
        {
            foreach (var slots in playerSlots)
            {
                if (slots.isSelected&&slots.slotIndex==Index)
                {
                    slots.slotHightlight.gameObject.SetActive(true);
                }
                else
                {
                    slots.isSelected = false;
                    slots.slotHightlight.gameObject.SetActive(false);
                }
            }
        }
    }
}

