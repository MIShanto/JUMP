using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivationManager : MonoBehaviour
{
   public void setActivePanel()
    {
        gameObject.SetActive(true);
    }
    public void setDeactivePanel()
    {
        gameObject.SetActive(false);
    }
}
