using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeMovement : MonoBehaviour
{
    public int velocity = 10;
    Vector3 direction = Vector2.up;
    float currentTime;

    public GameObject foodObject;
        
    //GameObject containing tail GameObjects as children
    public Transform tails;
    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(direction != Vector3.up){
                direction = Vector3.down;
            }

        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(direction != Vector3.down){
                direction = Vector3.up;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(direction != Vector3.right){
                direction = Vector3.left;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(direction != Vector3.left){
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

            //move end of tail to old position of head            
            tails.GetChild(tails.childCount - 1).transform.position = oldPosition;

            //set as first element of array
            tails.GetChild(tails.childCount - 1).SetAsFirstSibling();          
            
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        Debug.Log("Snake collision detected!");
        Debug.Log(collisionInfo.gameObject.name);        

        string name = collisionInfo.gameObject.name; 

        //if collides with food, add score and destroy
        if(name.Contains("Food")){
            Destroy(collisionInfo.gameObject);
            Instantiate(foodObject);
        }        

        //else if wall, game over

        
    }
    
}
