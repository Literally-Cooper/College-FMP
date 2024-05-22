using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInteract : MonoBehaviour
{
    private Character characterScript;
    private GameObject player;
    private bool canPickUp = false;

    public string itemType;
    public int itemAmt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        characterScript = player.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("return") && canPickUp == true){
            characterScript.addItems(itemType, itemAmt);
            gameObject.transform.position = new Vector3(999,999,999);
            StartCoroutine(waitThenDestroy(1.0f));
            
        }
    }
    void OnTriggerEnter(Collider col) {
        canPickUp = true;
    }

    void OnTriggerExit(Collider col) {
        canPickUp = false;
        
    }

    IEnumerator waitThenDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(gameObject);
    }
}
