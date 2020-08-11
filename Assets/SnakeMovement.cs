using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int velocity = 10;
    Vector3 direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void FixedUpdate()
    {
        this.transform.position += direction * velocity * Time.deltaTime;
    }
}
