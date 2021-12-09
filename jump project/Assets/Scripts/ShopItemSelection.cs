using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemSelection : MonoBehaviour
{

    GameObject[] itemList;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        itemList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            itemList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject item in itemList)
        {
            item.SetActive(false);
        }

        if (itemList[0])
            itemList[0].gameObject.SetActive(true);
    }

    public void ToggleLeft()
    {
        itemList[index].SetActive(false);

        index--;
        if (index < 0)
            index = itemList.Length - 1;

        itemList[index].SetActive(true);

        //if already purchased
        if(PlayerPrefs.GetInt(itemList[index].name) == 1)
        {
            itemList[index].transform.GetChild(0).transform.GetChild(0).
                GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
            itemList[index].transform.GetChild(0).GetComponent<Button>().interactable = false;
        }
    }
    public void ToggleRight()
    {
        itemList[index].SetActive(false);

        index++;
        if (index == itemList.Length)
            index = 0;

        itemList[index].SetActive(true);

        //if already purchased
        if (PlayerPrefs.GetInt(itemList[index].name) == 1)
        {
            itemList[index].transform.GetChild(0).transform.GetChild(0).
                GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
            itemList[index].transform.GetChild(0).GetComponent<Button>().interactable = false;

        }
    }
}
