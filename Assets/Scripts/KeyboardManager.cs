using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyboardManager : MonoBehaviour
{
    public void Type(){
        Transform topLevelTransform = transform.parent.parent;
        char c = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text[0];
        topLevelTransform.GetChild(0).GetComponent<QuestionManager>().Type(c);
    }
}
