using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToUpperCase : MonoBehaviour
{
    bool uppercase = true;
    public void SwitchCase(){
        uppercase = !uppercase;
        Transform parentTransform =  transform.parent;
        if(uppercase){            
            for(int i = 0; i<29;i++){
                parentTransform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = parentTransform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text.ToUpper();
            } 
        }else{                  
            for(int i = 0; i<29;i++){
                parentTransform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = parentTransform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text.ToLower();
            } 
        }
    }
}
