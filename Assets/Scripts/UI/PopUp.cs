using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    // Start is called before the first frame update
    public void SetText (string title, string description) {
        this.title.text = title;
        this.description.text = description;
    }
}
