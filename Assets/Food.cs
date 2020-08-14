using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    /*
    x: -5.5 to 4.5
    y: -3.5 to 3.5
    */
    // Start is called before the first frame update
    

    System.Random rnd = new System.Random();
    float x;
    float y;
    
    
    void Start()
    {
        x = (float)rnd.Next(-5,6) - 0.5f;
        y = (float)rnd.Next(-3,5) - 0.5f;

        this.transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
    }
}
