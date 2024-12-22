using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueUI : MonoBehaviour
{
    public GameObject dailogueBox;
    public Text dailogueText;
    public Image faceRight,faceLeft;
    public Text nameRight,nameLeft;
    public GameObject continuBox;
    private void Awake()
    {
        continuBox.SetActive(false);
    }
}
