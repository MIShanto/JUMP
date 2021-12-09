using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ShopControlScript : MonoBehaviour {

	int availableCoins;

	public Animator animator;
	public GameObject congoPanel;
	public TextMeshProUGUI congoMsg;

	// msg container
	IDictionary<string, string> itemProperties = new Dictionary<string, string>();

	// Use this for initialization
	void Start () 
	{
		animator.SetBool("oops", false);
		PlayerPrefs.SetInt("Coins", 1300);
		availableCoins = PlayerPrefs.GetInt ("Coins",0);

		itemProperties.Add("combo", "You have just unlocked the Combo package");
		itemProperties.Add("bg (7)", "You have just unlocked the Desert Background");
		itemProperties.Add("bg (6)", "You have just unlocked the Woodland Background");
		itemProperties.Add("bg (5)", "You have just unlocked the city Background");
		itemProperties.Add("mouse", "You have just unlocked the mouse (mate of jerry)");
		itemProperties.Add("coala", "You have just unlocked the cuty coala");
		itemProperties.Add("fox", "You have just unlocked  MR. fox ");

	}
	public void onButtonPress()
	{
		//gte the current button gameobject
		GameObject mainButton = EventSystem.current.currentSelectedGameObject;
		//get the button text (price of the item)
		TextMeshProUGUI buttonChildTxt = mainButton.transform.GetComponentInChildren<TextMeshProUGUI>();
		string itemName = mainButton.transform.parent.name;
		int price = int.Parse(buttonChildTxt.text);
		//get the button
		Button btn = mainButton.GetComponent<Button>();

		if (availableCoins >= price)
		{
			availableCoins -= price;

			buttonChildTxt.text = "Equipped";

			PlayerPrefs.SetInt(itemName, 1);

			btn.interactable = false;

			congoPanel.SetActive(true);
			congoPanel.GetComponent<Animator>().SetTrigger("on");
			congoMsg.text = itemProperties[itemName];
			gameObject.SetActive(false);
		}
		else
			animator.SetTrigger("oops");
		}


	public void exitShop()
	{
		PlayerPrefs.SetInt ("Coins", availableCoins);
	}


}
