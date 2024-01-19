using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    


    // Update is called once per frame
  

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();

    }
}
