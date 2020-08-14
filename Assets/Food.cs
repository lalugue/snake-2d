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
    float x;
    float y;

    System.Random rnd = new System.Random();
    
    
    void Start()
    {
        this.transform.position = new Vector2((float)rnd.Next(-5,6) - 0.5f, (float)rnd.Next(-3,5) - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
