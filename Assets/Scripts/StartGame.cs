using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad = "SampleScenes";

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void ExitButtonClicked()
    {
        Application.Quit();
    }
    
    
}