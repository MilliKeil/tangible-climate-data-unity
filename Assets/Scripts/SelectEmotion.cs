using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SelectEmotion : MonoBehaviour
{
    public bool active = false;
    public bool main = false;
    public bool animation = false;
    public bool animation2 = false;
    float time = 0.0f;
    float speed = 0.001f;
    public int emotionIndex;
    public int maxIndex;
    public Vector3 start;
    public Vector3 dest;
    public LineRenderer lr;
    public SelectEmotion secondEmotion;
    public void Update(){
        if(animation){
            if(active){
                transform.position = Vector3.Lerp(start,dest,time);
                time += speed;
                if(main && animation2){
                    float radiusEdge = transform.GetComponent<RectTransform>().rect.width/2;
                    if(Vector3.Distance(start, transform.position) > radiusEdge){
                        lr.SetPosition(0,new Vector3(transform.position.x+radiusEdge,transform.position.y,1));
                        lr.SetPosition(1,new Vector3(secondEmotion.transform.position.x-radiusEdge,secondEmotion.transform.position.y,1));
                    }
                }
                if(time > 1.0f){
                    if(main && !animation2){
                        if(emotionIndex % 2 == 0){
                            secondEmotion = transform.parent.GetChild(emotionIndex+1).GetComponent<SelectEmotion>();
                        }else{
                            secondEmotion = transform.parent.GetChild(emotionIndex-1).GetComponent<SelectEmotion>();
                        }
                        secondEmotion.start = secondEmotion.dest;
                        secondEmotion.animation2 = true;
                        secondEmotion.dest = new Vector3(dest.x+250,dest.y,1);
                        secondEmotion.SetActive();
                    }
                    if(!animation2){
                        start = dest;
                        dest = new Vector3(dest.x-250,dest.y,1);
                        animation = true;
                        animation2 = true;
                        time = 0.0f;
                    }else if(animation2){
                        animation = false;
                        animation2 = false;
                    }
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
        main = true;
        GameObject.Find("EmotionQuestion").SetActive(false);
        transform.parent.GetComponent<AnimateEmotions>().MoveAllEmotions();
    }
}