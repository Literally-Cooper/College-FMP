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
    Dictionary<string, int> inventory = new Dictionary<string, int>(){
        {"wood", 0},
        {"stone", 0}
    };

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.enabled == true){
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            characterController.Move(move * Time.deltaTime * speed);
        }



    }

    public void addItems(string item, int amount){
        inventory[item] += amount;
    }

    public int getItem(string item){
        try{
            return inventory[item];
        }catch{
            return 0;
        }
    }
}
