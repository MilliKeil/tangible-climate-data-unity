using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;


public class InstantiateTextoptions : MonoBehaviour
{
    string[] questions = new string[]{
            "How could the future of ___ and ___ look like considering climate change?",
            "What connects ___ with ___ in the status quo of climate crisis?",
            "How will climate change impact humanity regarding ___ and ___ in 100 years?"
    };
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI m_Object;
        GameObject textTemplate = transform.GetChild(0).gameObject; 
        for (int i =0;i<questions.Length;i++){
            GameObject g = Instantiate(textTemplate,transform);
            g.name = "Question "+i;
            m_Object = g.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            m_Object.text = questions[i];
            g.transform.GetComponent<SelectQuestion>().index = i;
        }  
        textTemplate.transform.parent = null;
        Destroy(textTemplate);
        transform.GetComponent<QuestionManager>().ActiveQuestion(0);
    }
    public void FillSentences(string[] words){
        int index = 0;
        foreach(Transform child in transform){
            int index2 = 0;
            string formatedQuestion = Regex.Replace(questions[index],"(___)", (m) => {
                if(words[index2] == ""){
                    index2++;
                    return "___";
                }else{
                    return words[index2++];
                }});
            child.GetChild(0).GetComponent<TextMeshProUGUI>().text = formatedQuestion;
            index++;
        }
    }
}
