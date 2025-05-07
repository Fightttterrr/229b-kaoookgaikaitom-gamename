using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad = "SampleScene";

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void ExitButtonClicked()
    {
        Application.Quit();
    }
    
    
}