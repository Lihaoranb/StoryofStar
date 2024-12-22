using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField]private TextMeshProUGUI descriptionText;
    public void SetupTooltip(ItemDetails itemDetails)
    {
        nameText.text = itemDetails.itemName;
        descriptionText.text = itemDetails.itemDescription;
        
    }
}
