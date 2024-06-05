using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Vector3 = UnityEngine.Vector3;
using System;

public class Character : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    Dictionary<string, int> inventory = new Dictionary<string, int>(){ //This is the players inventory, using a dictionary
        {"wood", 0},
        {"stone", 0}
    };

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); //gets the character controller component from the object this 
                                                                   //script is attached to, this is to allow for the script to control the player movement
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.enabled == true){
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //creates a Vector3, which is used to store 3D positions, taking the players input as variables
            characterController.Move(move * Time.deltaTime * speed); //Moves the player using the created Vector3
        }
    }

    public void addItems(string item, int amount){
        inventory[item] += amount; //adds whatever amount to whatever item the function calls for, if the item doesn't exist then it will be automatically added to the dictionary
    }

    public int getItem(string item){
        try{
            return inventory[item]; //returns the amount of whatever speciffic item is called for
        }catch{
            return 0; //if the item doesn't exist in the inventory dictionary, it just returns 0
        }
    }
}
