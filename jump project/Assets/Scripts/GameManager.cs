using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject background;
    [SerializeField] GameObject safePad;
    [SerializeField] GameObject unsafePad;

    //bg that will apply
    [SerializeField] GameObject[] mainBackgroundList;
    [SerializeField] GameObject[] padsList;
    //char that will apply
    GameObject[] charList;
    /*    private void Awake()
        {

            SetUpSingleTon();

        }

        private void SetUpSingleTon()
        {
            int numberOfGameSessions = FindObjectsOfType<GameManager>().Length;
            if (numberOfGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {

                DontDestroyOnLoad(gameObject);
            }
        }
    */

    private void Start()
    {
        int tmpIndexChar;
        int tmpIndexBG;
        tmpIndexChar = PlayerPrefs.GetInt("SelectedCharacter", 0);
        tmpIndexBG = PlayerPrefs.GetInt("SelectedBG", 0);
        //bg section
        background.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            mainBackgroundList[tmpIndexBG * 2].GetComponent<SpriteRenderer>().sprite;

        for (int i = 1; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                mainBackgroundList[(tmpIndexBG * 2) + 1].GetComponent<SpriteRenderer>().sprite;
        }

        safePad.GetComponent<SpriteRenderer>().sprite =
            padsList[tmpIndexBG * 2].GetComponent<SpriteRenderer>().sprite;
        unsafePad.GetComponent<SpriteRenderer>().sprite =
            padsList[(tmpIndexBG * 2) + 1].GetComponent<SpriteRenderer>().sprite;

        //char section
        for (int i = 0; i < character.transform.childCount; i++)
        {
            character.transform.GetChild(i).gameObject.SetActive(false);
        }
        character.transform.GetChild(tmpIndexChar).gameObject.SetActive(true);

    }
}
