using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
      
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    void OnClick(){
        Debug.Log("Loading game!");
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGame(){
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
