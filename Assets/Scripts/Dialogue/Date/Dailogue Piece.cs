using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFarm.Dialogue
{
    [System.Serializable]
    public class DialoguePiece
    {
        [Header("∂‘ª∞œÍ«È")]
        public Sprite faceImage;
        public bool onLeft;
        public string name;
        [TextArea]
        public string dailogueText;
        public bool hasToPause;
        public bool isDone;
    }
}

