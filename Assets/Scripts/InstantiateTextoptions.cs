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
        GameObject g;
        for (int i =0;i<questions.Length;i++){
            g = Instantiate(textTemplate,transform);
            m_Object = g.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            m_Object.text = questions[i];
        }  
        Destroy(textTemplate);
    }

    public void FillSentences(string[] words){
        int index = 0;
        foreach(Transform child in transform){
            int index2 = 0;
            string formatedQuestion = Regex.Replace(questions[index],"(___)", (m) => words[index2++]);
            child.GetChild(0).GetComponent<TextMeshProUGUI>().text = formatedQuestion;
            index++;
        }
    }
}
