using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    string question = null;
    string formatedQuestion = null;
    string [] words = new string[]{"",""};
    bool wordSwitch = false;

    // Update is called once per frame
    void Update()
    {   
        if(question != null){
            int matchCount = 0;
            formatedQuestion = Regex.Replace(question,"(___)", (m) => words[matchCount++]);
            transform.GetComponent<TextMeshProUGUI>().text = formatedQuestion;
        }else{
            transform.parent.GetChild(1).GetChild(0).GetComponent<InstantiateTextoptions>().FillSentences(words);
        }
    }
    public void Type(char c)
    {
        if(!wordSwitch){
            words[0] += c;
        }else{
            words[1] += c;
        }
    }
    public void SetWordSwitch(bool word){
        wordSwitch = word;
    }
    public void SetQuestion(string question)
    {
        this.question = question;
    }
}
