using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SelectQuestion : MonoBehaviour
{
   public int index;
   public void ActivateQuestion(){
        transform.parent.GetComponent<QuestionManager>().ActiveQuestion(index);
    }
}
