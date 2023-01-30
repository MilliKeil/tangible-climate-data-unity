using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    string [] words = new string[]{"",""};
    bool switchWord = false;

    void Update()
    {   
        transform.GetComponent<InstantiateTextoptions>().FillSentences(words);
    }
    public void Type(char c)
    {
        int array = switchWord? 1 : 0;
        if(c == '\b' && words[array].Length > 0){
           words[array] = words[array].Substring(0,words[array].Length-1);
        }else if(c != '\b'){
           words[array] += c;
        }
    }
    public void SwitchWord(){
        switchWord = !switchWord;
    }
    public void ActiveQuestion(int index){
        for(int i = 0;i < transform.childCount;i++){
            Debug.Log(index +" == "+i + " "+transform.childCount);
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().color = i == index ? new Color32(0, 0, 0, 255): new Color32(0, 0, 0, 128);
        }
    }
}
