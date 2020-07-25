using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSelection : MonoBehaviour
{
    //bg that will apply
    [SerializeField] GameObject[] mainBackgroundList;
    [SerializeField] GameObject[] padsList;

    [SerializeField] GameObject background;
    [SerializeField] GameObject safePad;
    [SerializeField] GameObject unsafePad;


    GameObject[] selectionBackgroundList;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        selectionBackgroundList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            selectionBackgroundList[i] = transform.GetChild(i).gameObject; 
        }


        foreach (GameObject item in selectionBackgroundList)   
        {
            item.SetActive(false);
        }

        if (selectionBackgroundList[0])
            selectionBackgroundList[0].gameObject.SetActive(true);

    }

    public void ToggleLeft()
    {
        selectionBackgroundList[index].SetActive(false);

        index--;
        if (index < 0)
            index = selectionBackgroundList.Length - 1;

        selectionBackgroundList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        selectionBackgroundList[index].SetActive(false);

        index++;
        if (index == selectionBackgroundList.Length)
            index = 0;

        selectionBackgroundList[index].SetActive(true);
    }
    public void ConfirmSelection()
    {
        background.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =  
            mainBackgroundList[index*2].GetComponent<SpriteRenderer>().sprite;

        for (int i = 1; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                mainBackgroundList[(index*2)+1].GetComponent<SpriteRenderer>().sprite;
        }
        safePad.GetComponent<SpriteRenderer>().sprite =
            padsList[index * 2].GetComponent<SpriteRenderer>().sprite;
        unsafePad.GetComponent<SpriteRenderer>().sprite =
            padsList[(index * 2)+1].GetComponent<SpriteRenderer>().sprite;
    }
    public void CloseSelection()
    {
        background.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =  
            mainBackgroundList[index*2].GetComponent<SpriteRenderer>().sprite;

        for (int i = 1; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                mainBackgroundList[(index*2)+1].GetComponent<SpriteRenderer>().sprite;
        }
    }

}
