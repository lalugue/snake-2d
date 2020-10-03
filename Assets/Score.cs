using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text text;
    void Start()
    {      
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(){
        score++;
        text.text = score.ToString();
    }
}
