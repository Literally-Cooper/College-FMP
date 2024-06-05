using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuManager : MonoBehaviour
{
    private Character characterScript;
    private GameObject player;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public Image invBase;
    private int wood;
    private int stone;
    public Image screenImage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        characterScript = player.GetComponent<Character>();
        invBase.enabled = false;
        woodText.enabled = false;
        stoneText.enabled = false;
        //fadeToBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i")){
            CharacterController controller = player.GetComponent<CharacterController>();
            //controller.enabled = !controller.enabled; (I first wanted the player to not be able to move when the inventory was open,I later scrapped this because it made the controls feel sluggish. 
            invBase.enabled = !invBase.enabled;
            woodText.enabled = !woodText.enabled;
            stoneText.enabled = !stoneText.enabled; //these three lines toggle the visibility of various UI elements
        }
        wood = characterScript.getItem("wood");
        stone = characterScript.getItem("stone"); //this block of code gets the values of wood and stone from the players inventory dictionary and update the respective UI texts
        woodText.text = "Wood:" + wood.ToString();
        stoneText.text = "Stone:" + stone.ToString();
    }

    public void toggleFade()
    {
        if(screenImage.color.a == 1)
        {
            StartCoroutine(fadetoNorm());
        }else{
            StartCoroutine(fadetoBlack());
        }
    }
    IEnumerator fadetoBlack(){
        float testing = 0.0f; //this function slowly adds to this testing value, which then gets converted into a byte
        while(testing < 255){ //This byte can then be added as the alpha (transparrency) value of the black screen in the UI
            testing = testing + 5f; 
            byte newaByte = (byte) (testing);
            screenImage.color = new Color32(0, 0, 0, newaByte);
            if(screenImage.color.a >= 0.9f){ //once the alpha of the screen is more than 0.9 it will get automatically set to 1
                testing = 255;               //this is to avoid the alpha going over 1, which causes it to reset back to 0 and start again
                byte newbByte = (byte) (testing);//Although the "testing" float value goest from 0 - 1, once converted into a bute it goes from 0 - 255, this caused me a lot of confusion when initially writing this script
                screenImage.color = new Color32(0, 0, 0, newbByte); 
                break;
            }
            yield return new WaitForSeconds(0.025f);
        }
    }
    IEnumerator fadetoNorm(){ //this function does the same as fadetoBlack but in reverse, these could have been one script butI made them spereate for simplicity's sake
        float testing = 255f;
        while(testing > 0){
            testing = testing - 5f;
            byte newaByte = (byte) (testing);
            screenImage.color = new Color32(0, 0, 0, newaByte);
            //Debug.Log(screenImage.color.a);
            if(screenImage.color.a <= 0.1f){
                testing = 0;
                byte newbByte = (byte) (testing);
                screenImage.color = new Color32(0, 0, 0, newbByte);
                break;
            }
            yield return new WaitForSeconds(0.025f);
        }
    }
}
