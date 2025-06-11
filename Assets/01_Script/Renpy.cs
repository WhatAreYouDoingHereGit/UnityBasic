using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG;
    [SerializeField] Image[] img_Character;

    [SerializeField] TextMeshProUGUI txt_Name;
    [SerializeField] TextMeshProUGUI txt_NameTitle;
    [SerializeField] TextMeshProUGUI txt_Dialouge;

    [SerializeField] Button btn_Next;

    int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        id++;
        RefreshUI();
    }

    public void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Character;
        txt_Name.text = SData.GetCharacterData(characterID).Name;
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title;

        txt_Dialouge.text = SData.GetDialogueData(id).Dialogue;

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);

        for (int i = 0; i <= img_Character.Length; i++)
        {
            if (i == SData.GetDialogueData(id).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(characterID).Image);
                img_Character[i].gameObject.SetActive(true);
            }
            else
            {
                img_Character[i].gameObject.SetActive(false);
            }
        }
    
    }
}

