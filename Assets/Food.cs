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

    public GameObject foodObject;

       
    
    void Start()
    {
        x = (float)rnd.Next(-5,6) - 0.5f;
        y = (float)rnd.Next(-3,5) - 0.5f;

        Collider2D[] intersecting = Physics2D.OverlapCircleAll(new Vector2(x, y), 0.01f);
        while(intersecting.Length > 0){
            Debug.Log("food spawn at snake body detected");
            x = (float)rnd.Next(-5,6) - 0.5f;
            y = (float)rnd.Next(-3,5) - 0.5f;
            intersecting = Physics2D.OverlapCircleAll(new Vector2(x, y), 0.01f);
        }

        this.transform.position = new Vector2(x, y);

        /*if (intersecting.Length == 0) {
            //code to run if nothing is intersecting as the length is 0
            this.transform.position = new Vector2(x, y);
        } else {
            //code to run if something is intersecting it
            Debug.Log("Food about to spawn at snake");            
            Instantiate(foodObject);
            Destroy(this.gameObject);
        }*/
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
