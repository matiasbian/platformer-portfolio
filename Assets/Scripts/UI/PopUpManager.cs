using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] PopUp popUp;
    [SerializeField] PopUp popUpReset;
    [SerializeField] TextAsset json;
    JSONNode parsedJSON;

    static PopUpManager self;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        parsedJSON = JSON.Parse(json.text);
    }

    public static PopUpManager Get () {
        if (self) return self;
        self = GameObject.FindObjectOfType<PopUpManager>();
        return self;
    }

    public void ShowPopUp (string id) {
        popUp.gameObject.SetActive(true);
        string company = parsedJSON[id]["company"];
        string title = parsedJSON[id]["title"];
        string period = parsedJSON[id]["period"];
        string texttitle = !string.IsNullOrEmpty(company) ?  $"<#C12B2B>{company}</color> - {title}" : title;
        popUp.SetText(texttitle, company, parsedJSON[id]["description"], period, parsedJSON[id]["url"]);
    }

    public void ShowPopUpReset (string id) {
        popUpReset.gameObject.SetActive(true);
        string company = parsedJSON[id]["company"];
        string title = parsedJSON[id]["title"];
        string period = parsedJSON[id]["period"];
        string texttitle = !string.IsNullOrEmpty(company) ?  $"<#000000>{company}</color> - {title}" : title;
        popUpReset.SetText(texttitle, company, parsedJSON[id]["description"], period, parsedJSON[id]["url"]);
    }

    public void ClosePopUp () {
        popUp.gameObject.SetActive(false);
        popUp.SetText("", "", "", "", "");
    }
}
