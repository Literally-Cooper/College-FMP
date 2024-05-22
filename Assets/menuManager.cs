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
            //controller.enabled = !controller.enabled;
            invBase.enabled = !invBase.enabled;
            woodText.enabled = !woodText.enabled;
            stoneText.enabled = !stoneText.enabled;
        }
        wood = characterScript.getItem("wood");
        stone = characterScript.getItem("stone");
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
        float testing = 0.0f;
        while(testing < 255){
            testing = testing + 5f;
            byte newaByte = (byte) (testing);
            screenImage.color = new Color32(0, 0, 0, newaByte);
            //Debug.Log(screenImage.color.a);
            if(screenImage.color.a >= 0.9f){
                testing = 255;
                byte newbByte = (byte) (testing);
                screenImage.color = new Color32(0, 0, 0, newbByte);
                break;
            }
            yield return new WaitForSeconds(0.025f);
        }
    }
    IEnumerator fadetoNorm(){
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
