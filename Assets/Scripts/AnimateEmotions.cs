using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEmotions : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveAllEmotions(){
        foreach(Transform child in transform){
            child.GetComponent<SelectEmotion>().animation = true;
        } 
    }
}
