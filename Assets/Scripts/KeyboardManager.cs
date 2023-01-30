using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyboardManager : MonoBehaviour
{
    public void Type(){
        
        char c = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text[0];
        GameObject.Find("Questions").GetComponent<QuestionManager>().Type(c);
    }
    public void Enter(){
        GameObject.Find("Questions").GetComponent<QuestionManager>().SwitchWord();
    }
    public void Backspace(){
        GameObject.Find("Questions").GetComponent<QuestionManager>().Type('\b');
    }
    public void Space(){
        GameObject.Find("Questions").GetComponent<QuestionManager>().Type(' ');
    }
}
