using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace LFarm.Inventory
{
    [RequireComponent(typeof(SlotUI))]
    public class ShowItemToolTip : MonoBehaviour,IPointerClickHandler
    {
        private SlotUI slotUI;

        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

        public void OnPointerClick(PointerEventData eventData)
        {
            
            if (slotUI.itemAmount != 0&&slotUI.slotHightlight.isActiveAndEnabled)
            {
                inventoryUI.itemTooltip.gameObject.SetActive(true);
                inventoryUI.itemTooltip.SetupTooltip(slotUI.itemDetails);

                inventoryUI.itemTooltip.transform.position = transform.position + Vector3.up * 180;
            }

            else
            {
                inventoryUI.itemTooltip.gameObject.SetActive(false);
            }
        }

      

        private void Awake()
        {
            slotUI = GetComponent<SlotUI>();
        }
    }

}
