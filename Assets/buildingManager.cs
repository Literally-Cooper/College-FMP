using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class buildingManager : MonoBehaviour
{
    private Character characterScript;
    private GameObject player;
    public string uiText;
    public TextMeshProUGUI text;
    private bool canPickUp;
    public string itemType;
    public int itemAmt;
    public GameObject buildingPrefab;
    public GameObject buildingPlaceholder;
    // Start is called before the first frame update
    void Start()
    {
        //text.text = "collide";
        text.faceColor = new Color32(255, 255, 255, 0); //on start makes the Alpha of the text object 0 to render it invisible
        player = GameObject.Find("Player");
        characterScript = player.GetComponent<Character>();
    }

    void Update()
    {
        if(Input.GetKeyDown("return") && canPickUp == true){
            int currentItems = characterScript.getItem(itemType);
            if(currentItems >= itemAmt)
            {
                Transform placeholderTransform = buildingPlaceholder.GetComponent<Transform>();
                Instantiate(buildingPrefab, placeholderTransform.position, Quaternion.identity);
                characterScript.addItems(itemType, -itemAmt);
                buildingPlaceholder.transform.position = new Vector3(999,999,999);
                StartCoroutine(waitThenDestroy(1.0f, buildingPlaceholder));
                gameObject.transform.position = new Vector3(999,999,999);
                StartCoroutine(waitThenDestroy(1.0f, gameObject));
            }
            

            
        }
    }
    void OnTriggerEnter(Collider col) {
        text.text = uiText;
        text.faceColor = new Color32(255, 255, 255, 255); //when interacted with sets the Alpha to 255 to make it visable, along with setting the text
                                                          //also sets the text to the uiText variable, aming this script modular for any interaction
        canPickUp = true;
    }

    void OnTriggerExit(Collider other) {
        text.faceColor = new Color32(255, 255, 255, 0); //makes the text invisible when the player moves away from the object
        canPickUp = false;
    }
    
    IEnumerator waitThenDestroy(float secs, GameObject theObject)
    {
        yield return new WaitForSeconds(secs);
        Destroy(theObject);
    }
}
