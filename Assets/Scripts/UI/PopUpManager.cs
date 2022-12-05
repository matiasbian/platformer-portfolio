using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
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
        StartCoroutine(GetRequest("https://www.mati-dev.com.ar/timeapi.json"));
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


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                    parsedJSON = JSON.Parse(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
