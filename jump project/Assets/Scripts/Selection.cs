using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selection : MonoBehaviour
{

    #region player pref var
    /// <summary>
    /// int = bg names, char names, selected char, selected bg
    /// </summary>
    #endregion
    //bg to chose from
    [SerializeField] GameObject _BG;

    //char to chose from
    [SerializeField] GameObject _Char;

    //bg that will apply
    [SerializeField] GameObject[] mainBackgroundList;
    [SerializeField] GameObject[] padsList;
    //char that will apply
    [SerializeField] GameObject character;
    GameObject[] charList;

    [SerializeField] GameObject background;
    [SerializeField] GameObject safePad;
    [SerializeField] GameObject unsafePad;


    [SerializeField] Button okButton;
    [SerializeField] Animator animator;

    GameObject[] selectionBackgroundList;

    [SerializeField] TextMeshProUGUI BGMsgPanel;
    [SerializeField] TextMeshProUGUI CharMsgPanel;


    int tmpIndexBG;
    int indexBG;
    int tmpIndexChar;
    int indexChar;

    // msg container
    IDictionary<int, string> itemProperties = new Dictionary<int, string>();

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        indexChar = PlayerPrefs.GetInt("SelectedCharacter");
        indexBG = PlayerPrefs.GetInt("SelectedBG");
        itemProperties.Add(1, "OOps!! you need a score of 200 to open the character");
        itemProperties.Add(2, "OOps!! you need a score of 400 to open the character");
        itemProperties.Add(3, "OOps!! you need a score of 600 to open the character");
        itemProperties.Add(4, "OOps!! you need to unlock the character from the store");
        itemProperties.Add(5, "OOps!! you need to unlock the character from the store");
        itemProperties.Add(6, "OOps!! you need to unlock the character from the store");
        itemProperties.Add(7, "OOps!! you need to sign in with your google account to get this character");

        itemProperties.Add(8,  "OOps!! you need a score of 300 to open the background");
        itemProperties.Add(9,  "OOps!! you need a score of 500 to open the background");
        itemProperties.Add(10, "OOps!! you need a score of 700 to open the background");
        itemProperties.Add(11, "OOps!! you need to unlock the background from the store");
        itemProperties.Add(12, "OOps!! you need to unlock the background from the store");
        itemProperties.Add(13, "OOps!! you need to unlock the background from the store");
        itemProperties.Add(14, "OOps!! you need to sign in with your google account to get this background");

    }
    public void OpenPanel()
    {
        //bg section
        selectionBackgroundList = new GameObject[_BG.transform.childCount];

        for (int i = 0; i < _BG.transform.childCount; i++)
        {
            selectionBackgroundList[i] = _BG.transform.GetChild(i).gameObject;
        }

        PlayerPrefs.SetInt(selectionBackgroundList[0].name, 1);

        animator.SetBool("availableBG", true);

        //deactivate all items
        foreach (GameObject item in selectionBackgroundList)
        {
            item.SetActive(false);
        }

        //get the last active item
        tmpIndexBG = PlayerPrefs.GetInt("SelectedBG", 0);
        Debug.LogError(tmpIndexBG);
        //show this when selection panel is opened
        if (selectionBackgroundList[tmpIndexBG])
            selectionBackgroundList[tmpIndexBG].gameObject.SetActive(true);


        //charecter section
        charList = new GameObject[_Char.transform.childCount];

        for (int i = 0; i < _Char.transform.childCount; i++)
        {
            charList[i] = _Char.transform.GetChild(i).gameObject;
        }

        PlayerPrefs.SetInt(charList[0].name, 1);

        animator.SetBool("availableChar", true);

        //deactivate all items
        foreach (GameObject item in charList)
        {
            item.SetActive(false);
        }

        //get the last active item
        tmpIndexChar = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Debug.LogError(tmpIndexChar);


        //show this when selection panel is opened
        if (charList[tmpIndexChar])
        {
            charList[tmpIndexChar].gameObject.SetActive(true);
        }

        okButton.interactable = true;

    }

    public void ToggleLeftBG()
    {
        selectionBackgroundList[tmpIndexBG].SetActive(false);

        tmpIndexBG--;
        if (tmpIndexBG < 0)
            tmpIndexBG = selectionBackgroundList.Length - 1;

        selectionBackgroundList[tmpIndexBG].SetActive(true);

        //if is available
        if (PlayerPrefs.GetInt(selectionBackgroundList[tmpIndexBG].name,0) == 1)
        {
            indexBG = tmpIndexBG;
            animator.SetBool("availableBG", true);

            if (PlayerPrefs.GetInt(charList[tmpIndexChar].name,0) == 1)
                okButton.interactable = true;
            else
                okButton.interactable = false;

        }
        //otherwise
        else
        {
            animator.SetBool("availableBG", false);
            BGMsgPanel.text = itemProperties[tmpIndexBG + 7];
            okButton.interactable = false;
        }
    }
    public void ToggleRightBG()
    {
        selectionBackgroundList[tmpIndexBG].SetActive(false);

        tmpIndexBG++;
        if (tmpIndexBG == selectionBackgroundList.Length)
            tmpIndexBG = 0;

        selectionBackgroundList[tmpIndexBG].SetActive(true);

        //if is available
        if (PlayerPrefs.GetInt(selectionBackgroundList[tmpIndexBG].name, 0) == 1)
        {
            indexBG = tmpIndexBG;
            animator.SetBool("availableBG", true);

            if (PlayerPrefs.GetInt(charList[tmpIndexChar].name, 0) == 1)
                okButton.interactable = true;
            else
                okButton.interactable = false;

        }
        //otherwise
        else
        {
            animator.SetBool("availableBG", false);
            BGMsgPanel.text = itemProperties[tmpIndexBG + 7];
            okButton.interactable = false;
        }
    }

    public void ToggleLeftChar()
    {
        charList[tmpIndexChar].SetActive(false);

        tmpIndexChar--;
        if (tmpIndexChar < 0)
            tmpIndexChar = charList.Length - 1;

        charList[tmpIndexChar].SetActive(true);
        //if is available
        if (PlayerPrefs.GetInt(charList[tmpIndexChar].name,0) == 1)
        {
            indexChar = tmpIndexChar;
            animator.SetBool("availableChar", true);

            if (PlayerPrefs.GetInt(selectionBackgroundList[tmpIndexBG].name, 0) == 1)
                okButton.interactable = true;
            else
                okButton.interactable = false;
        }
        //otherwise
        else
        {
            animator.SetBool("availableChar", false);
            CharMsgPanel.text = itemProperties[tmpIndexChar];
            okButton.interactable = false;
        }
    }
    public void ToggleRightChar()
    {
        charList[tmpIndexChar].SetActive(false);

        tmpIndexChar++;
        if (tmpIndexChar == charList.Length)
            tmpIndexChar = 0;

        charList[tmpIndexChar].SetActive(true);

        //if is available
        if (PlayerPrefs.GetInt(charList[tmpIndexChar].name, 0) == 1)
        {
            indexChar = tmpIndexChar;
            animator.SetBool("availableChar", true);

            if (PlayerPrefs.GetInt(selectionBackgroundList[tmpIndexBG].name, 0) == 1)
                okButton.interactable = true;
            else
                okButton.interactable = false;
        }
        //otherwise
        else
        {
            animator.SetBool("availableChar", false);
            CharMsgPanel.text = itemProperties[tmpIndexChar];
            okButton.interactable = false;
        }
    }

    public void ConfirmSelection()
    {
        //bg section
        background.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =  
            mainBackgroundList[tmpIndexBG*2].GetComponent<SpriteRenderer>().sprite;

        for (int i = 1; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                mainBackgroundList[(tmpIndexBG*2)+1].GetComponent<SpriteRenderer>().sprite;
        }

        safePad.GetComponent<SpriteRenderer>().sprite =
            padsList[tmpIndexBG * 2].GetComponent<SpriteRenderer>().sprite;
        unsafePad.GetComponent<SpriteRenderer>().sprite =
            padsList[(tmpIndexBG * 2)+1].GetComponent<SpriteRenderer>().sprite;

        //char section
        for (int i = 0; i < character.transform.childCount; i++)
        {
            character.transform.GetChild(i).gameObject.SetActive(false);
        }
        character.transform.GetChild(tmpIndexChar).gameObject.SetActive(true);

        tmpIndexChar = indexChar;
        tmpIndexBG = indexBG;

        PlayerPrefs.DeleteKey("SelectedCharacter");
        PlayerPrefs.DeleteKey("SelectedBG");

        PlayerPrefs.SetInt("SelectedCharacter", tmpIndexChar);
        PlayerPrefs.SetInt("SelectedBG", tmpIndexBG);
    }
    public void CloseSelection()
    {
        tmpIndexBG = indexBG;
        tmpIndexChar = indexChar;

        animator.SetBool("availableBG", true);
        animator.SetBool("availableChar", true);
    }

}
