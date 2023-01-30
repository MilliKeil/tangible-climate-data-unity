using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstantiateButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] emotionPairs = new string[]{"Hoffnungsvoll","Verzweifelt","Wütend", "Verständnisvoll","Unsicher","Sicher","Überfordert","Unterfordert","Verantwortlich","Distanziert","Frustriert","Beruhigt"};
        Canvas canvas = FindObjectOfType<Canvas>();
        float h = canvas.GetComponent<RectTransform>().rect.height;
        float w = canvas.GetComponent<RectTransform>().rect.width;
        GameObject buttonTemplate = transform.GetChild(0).gameObject; 
        int div = emotionPairs.Length;
        float radianSteps = (2*Mathf.PI)/div;
        for (int i =0;i < div;i++){
            float x = w/3.5f + 370 * Mathf.Cos(radianSteps*i);
            float y = 370 * Mathf.Sin(radianSteps*i);
            Vector3 position = new Vector3(x,y,1);
            GameObject button = Instantiate(buttonTemplate,transform);
            button.name = "Emotion "+i;
            button.transform.position = position;
            button.GetComponent<SelectEmotion>().emotionIndex = i;
            button.GetComponent<SelectEmotion>().maxIndex = div-1;
            button.GetComponent<SelectEmotion>().start = position;
            button.GetComponent<SelectEmotion>().dest = new Vector3((w/3.5f),0,1);
            TextMeshProUGUI textObject = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            textObject.text = emotionPairs[i];
        }  
        GameObject.Find("EmotionQuestion").transform.GetChild(0).transform.position = new Vector3(w/3.5f,0,1);
        Destroy(buttonTemplate);
    }
}
/* Kreismathematik zur gleichmäßigen Anordnung von n Objekten
x = Verschiebung + R * cos(radianSteps * i)
y = Verschiebung + R * sin(radianSteps * i)
*/