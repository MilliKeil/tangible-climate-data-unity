using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWord : MonoBehaviour
{
    public bool boolean;
    public void Trigger(){
        transform.parent.parent.Find("Question").GetComponent<QuestionManager>().SetWordSwitch(boolean);
    }
}
