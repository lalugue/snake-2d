﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeMovement : MonoBehaviour
{
    public int velocity = 10;
    Vector3 direction = Vector2.up;
    Vector3 currentDirection = Vector2.up;
    float currentTime;

    public GameObject foodObject;
    public GameObject body;
        
    //GameObject containing tail GameObjects as children
    public Transform tails;
    Vector3 oldPosition;
    bool hasEaten;

    //score object
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        hasEaten = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(currentDirection != Vector3.up){
                direction = Vector3.down;
            }

        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(currentDirection != Vector3.down){
                direction = Vector3.up;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(currentDirection != Vector3.right){
                direction = Vector3.left;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(currentDirection != Vector3.left){
                direction = Vector3.right;
            }
            
        }

        if(Time.time - currentTime >= 0.2f){
            //get old position
            oldPosition = this.transform.position;

            //reset time
            currentTime = Time.time;

            //move by one unit
            //Note: pixels per unit can be seen by viewing sprite in Inspector
            this.transform.Translate(direction * 1);
            currentDirection = direction;

            if(!hasEaten){
            //move end of tail to old position of head            
            tails.GetChild(tails.childCount - 1).transform.position = oldPosition;

            //set as first element of array
            tails.GetChild(tails.childCount - 1).SetAsFirstSibling();   
            }
            else{
                //add new body to tail;
                GameObject emptyObj = new GameObject();
                Transform pos = emptyObj.transform;
                pos.position = oldPosition; 
                GameObject newBody = Instantiate(body, pos);               

                newBody.transform.parent = tails;
                newBody.transform.SetSiblingIndex(0);

                Destroy(emptyObj);
            }
            
            hasEaten = false;       
            
        }
    }

    //OnTriggerEnter2D is called before Update
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        Debug.Log("Snake collision detected!");
        Debug.Log(collisionInfo.gameObject.name);        

        string name = collisionInfo.gameObject.name; 

        //if collides with food, add score and destroy
        if(name.Contains("Food")){
            Destroy(collisionInfo.gameObject);
            Instantiate(foodObject);

            //enable flag
            hasEaten = true;

            //add score
            score.AddScore();           

        }        

        //else if wall, game over

        
    }
    
}
