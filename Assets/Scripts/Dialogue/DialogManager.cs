using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor.Rendering;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceLeft,faceRight;
    public Text nameText;
    public Button next;
    public GameObject Optionbutton;
    public Transform buttonGroup;
    [Header("文本文件")]
    public TextAsset textFile;
    public int index=0;
    public string[] dialogRows;
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    public List<Sprite> images = new List<Sprite>();

    
    
    private void Awake()
    {
        imageDic["马杰"] = images[0];
        imageDic["胡一波"] = images[1];
    }
    private void Start()
    {
        ReadText(textFile);
        ShowDialogRow();
        //UpdateText("博士", "沙克来解释拉开");
        //UpdateImage("马杰", false);
    }
    public void UpdateText(string _name,string _text)
    {
        nameText.text = _name;
        textLabel.text = _text;
    }
    public void UpdateImage(string _name,string pos)
    {
        if (pos=="左")
        {
            faceRight.enabled = false;
            faceLeft.enabled = true;
            faceLeft.sprite = imageDic[_name];  
        }
        else if(pos=="右")
        {
            faceLeft.enabled = false;
            faceRight.enabled=true;
            faceRight.sprite = imageDic[_name];
        }
    }
    public void ReadText(TextAsset textAsset)
    {
        dialogRows = textAsset.text.Split('\n');
        //foreach (var row in rows)
        //{
        //    string[] cell = row.Split(',');
        //}
       
    }
    public void ShowDialogRow()
    {
        for(int i=0;i<dialogRows.Length;i++)
        {
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == index)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                index = int.Parse(cells[5]);
                next.gameObject.SetActive(true);
                break;
            }
            else if (cells[0] == "&" && int.Parse(cells[1]) == index) 
            {
                next.gameObject.SetActive(false);
                GenrateOption(i);
            }
            else if (cells[0] == "END" && int.Parse(cells[1])==index)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void OnClickNext()
    {
        ShowDialogRow();
    }
    public void GenrateOption(int index)
    {
        string[] cells = dialogRows[index].Split(",");
        if (cells[0]=="&")
        {
            GameObject button = Instantiate(Optionbutton, buttonGroup);
            button.GetComponentInChildren<Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener(delegate { OnOptionClick(int.Parse(cells[5])); });
            GenrateOption(index + 1);
        }
    }
    public void OnOptionClick(int ID)
    {
        index= ID;
        ShowDialogRow();
        for (int i = 0;i<buttonGroup.childCount;i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        } 
    }
}
