using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
      
    
    // Start is called before the first frame update
    void Start()
    {
        //disable logging if not in editor
        #if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
        #else
        Debug.unityLogger.logEnabled = false;
        #endif        
    }

    public void LoadGame(){
        SceneManager.UnloadSceneAsync("MenuScene");
        SceneManager.LoadSceneAsync("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
