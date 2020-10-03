using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    /*
    x: -8.5 to 8.5
    y: -6.5 to 6.5
    */
    System.Random rnd = new System.Random();
    float x;
    float y;

    public GameObject foodObject;

       
    // Start is called before the first frame update
    void Start()
    {
        x = (float)rnd.Next(-8,9) - 0.5f;
        y = (float)rnd.Next(-6,7) - 0.5f;

        Collider2D[] intersecting = Physics2D.OverlapCircleAll(new Vector2(x, y), 0.01f);
        while(intersecting.Length > 0){
            Debug.Log("food spawn at snake body detected");
            x = (float)rnd.Next(-8,9) - 0.5f;
            y = (float)rnd.Next(-6,7) - 0.5f;
            intersecting = Physics2D.OverlapCircleAll(new Vector2(x, y), 0.01f);
        }

        this.transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
