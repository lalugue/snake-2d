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
    /*void OnClick(){
        Debug.Log("Loading game!");
        SceneManager.LoadSceneAsync("GameScene");
    }*/

    public void LoadGame(){
        SceneManager.UnloadSceneAsync("MenuScene");
        SceneManager.LoadSceneAsync("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
