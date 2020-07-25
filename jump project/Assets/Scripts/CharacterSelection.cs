using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    //char that will apply
    [SerializeField] GameObject character;

    GameObject[] charList;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        charList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            charList[i] = transform.GetChild(i).gameObject; 
        }

        foreach (GameObject item in charList)   
        {
            item.SetActive(false);
        }

        if (charList[0])
            charList[0].gameObject.SetActive(true);
    }

    public void ToggleLeft()
    {
        charList[index].SetActive(false);

        index--;
        if (index < 0)
            index = charList.Length - 1;

        charList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        charList[index].SetActive(false);

        index++;
        if (index == charList.Length)
            index = 0;

        charList[index].SetActive(true);
    }
    public void ConfirmSelection()
    {
        for (int i = 0; i < character.transform.childCount; i++)
        {
            character.transform.GetChild(i).gameObject.SetActive(false);
        }
        character.transform.GetChild(index).gameObject.SetActive(true);
    }
}
