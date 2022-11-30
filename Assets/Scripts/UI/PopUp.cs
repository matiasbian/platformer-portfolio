using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer;
public class PopUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI period;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject visitButton;
    [SerializeField] TextMeshProUGUI visitButtonText;
    string URL;
    // Start is called before the first frame update
    public void SetText (string title, string company, string description, string period, string URL) {
        this.title.text = title;
        this.period.text = period;
        this.description.text = description;
        this.URL = URL;
        visitButton.SetActive(!string.IsNullOrEmpty(URL));
        visitButtonText.text = company + " website";
    }

    public void VisitLink () {
        Application.OpenURL(URL);
    }

    public void ResetLevel () {
        GameObject.FindObjectOfType<PlayerController>().deathState = true;
    }
}
