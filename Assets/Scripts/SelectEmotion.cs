using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SelectEmotion : MonoBehaviour
{
    public bool active = false;
    public bool animation = false;
    float time = 0.0f;
    float speed = 0.001f;
    public int emotionIndex;
    public int maxIndex;
    public Vector3 start;
    public Vector3 dest;
    public void Update(){
        if(animation){
            if(active){
                transform.position = Vector3.Lerp(start,dest,time);
                time += speed;
                if(time > 1.0f){
                    animation = false;
                    time = 0.0f;
                }
            }else{
                SetDeactive();
            }
        }
    }
    public void SetDeactive(){
        transform.gameObject.SetActive(false); 
    }
    public void SetActive(){
        transform.gameObject.SetActive(true);
        animation = true;
        active = true;
    }
    public void TriggerAllEmotionsMovement(){
        active = true;
        transform.parent.GetComponent<AnimateEmotions>().MoveAllEmotions();
        SelectEmotion secondEmotion;
        if(emotionIndex % 2 == 0){
            secondEmotion = transform.parent.GetChild(emotionIndex+1).GetComponent<SelectEmotion>();
        }else{
            secondEmotion = transform.parent.GetChild(emotionIndex-1).GetComponent<SelectEmotion>();
        }
        secondEmotion.dest = new Vector3(dest.x+200,0,1);
        secondEmotion.SetActive();
    }
}