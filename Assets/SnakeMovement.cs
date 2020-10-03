using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public int velocity = 1;
    Vector3 direction = Vector2.up;
    Vector3 currentDirection = Vector2.up;
    float currentTime;
    float stopTime;

    public GameObject foodObject;
    public GameObject body;
    public GameObject snakeObject;
    
        
    //GameObject containing tail GameObjects as children
    public Transform tails;
    Vector3 oldPosition;
    bool hasEaten;
    
    //determines if snake can move
    bool isActive = true;
    //determines if snake is visible
    bool isVisible = false;

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

        if(Time.time - currentTime >= 0.2f && isActive){
            //get old position
            oldPosition = this.transform.position;

            //reset time
            currentTime = Time.time;

            //move by one unit
            //Note: pixels per unit can be seen by viewing sprite in Inspector
            this.transform.Translate(direction * velocity);
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
        //else if wall (or snake), game over
        else{
            Debug.Log("non-food collision detected"); 
            stopTime = Time.time;          
            InvokeRepeating("Blink", 0, 0.5f);
        }

        
    }

    
 
    void Blink()
    {
        //snakeObject.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled; 
        velocity = 0;       
        isActive = false;
        isVisible = !isVisible;
        //snakeObject.SetActive(isActive);
        //this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled; 
        Renderer[] renderers = snakeObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers){
            r.enabled = isVisible;
        }

        if(Time.time - stopTime >= 5.0f){
            SceneManager.UnloadSceneAsync("GameScene");
            SceneManager.LoadSceneAsync("MenuScene");
        }
        
    }

    
}
