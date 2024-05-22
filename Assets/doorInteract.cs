using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public Transform doorExit;
    private bool canEnter = false;
    private GameObject playerObject;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("return") && canEnter == true){
            StartCoroutine(throughDoor());
        }
    }

    void OnTriggerEnter(Collider col) {
        canEnter = true;
        //Debug.Log("collide");
    }

    void OnTriggerExit(Collider col) {
        canEnter = false;
        
    }

    IEnumerator throughDoor()
    {
        CharacterController cont = playerObject.GetComponent<CharacterController>();
        menuManager menu = mainCamera.GetComponent<menuManager>();
        cont.velocity.Set(0,0,0);
        cont.enabled = !cont.enabled;
        menu.toggleFade();
        yield return new WaitForSeconds(2f);
        playerObject.transform.position = doorExit.position;
        menu.toggleFade();
        yield return new WaitForSeconds(2f);
        cont.enabled = !cont.enabled;
    } 
}
