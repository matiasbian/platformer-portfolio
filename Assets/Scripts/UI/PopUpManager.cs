using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] PopUp popUp;

    static PopUpManager self;

    public static PopUpManager Get () {
        if (self) return self;
        self = GameObject.FindObjectOfType<PopUpManager>();
        return self;
    }

    public void ShowPopUp (string title, string description) {
        popUp.gameObject.SetActive(true);
        popUp.SetText(title, description);
    }

    public void ClosePopUp () {
        popUp.gameObject.SetActive(false);
        popUp.SetText("", "");
    }
}
