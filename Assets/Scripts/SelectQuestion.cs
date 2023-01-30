using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SelectQuestion : MonoBehaviour
{
    public TextMeshProUGUI textfield;
    // Start is called before the first frame update
    public void SetText(){
        string text = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        Transform topLevelTransform = transform.parent.parent.parent;
        topLevelTransform.GetChild(0).GetComponent<QuestionManager>().SetQuestion(text);
        topLevelTransform.GetChild(1).gameObject.SetActive(false);
    }
}
