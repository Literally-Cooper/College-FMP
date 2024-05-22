using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class uiInteract : MonoBehaviour
{
    public string uiText;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //text.text = "collide";
        text.faceColor = new Color32(255, 255, 255, 0); //on start makes the Alpha of the text object 0 to render it invisible
    }

    void OnTriggerEnter(Collider col) {
        text.text = uiText;
        text.faceColor = new Color32(255, 255, 255, 255); //when interacted with sets the Alpha to 255 to make it visable, along with setting the text
                                                          //also sets the text to the uiText variable, aming this script modular for any interaction
    }

    void OnTriggerExit(Collider other) {
        text.faceColor = new Color32(255, 255, 255, 0); //makes the text invisible when the player moves away from the object
    }
}
