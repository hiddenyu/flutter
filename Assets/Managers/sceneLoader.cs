using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void loadScene(string sceneName)
    {
        if (sceneName == "newRun") {
            gameManager.Instance.currentState = gameManager.gameStates.RUNNING;
        }
        else if (sceneName == "startMenu") {
            gameManager.Instance.currentState = gameManager.gameStates.START;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
