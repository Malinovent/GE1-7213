using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   
    public void SwitchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void SwitchScene(string buildName)
    {
        SceneManager.LoadScene(buildName);
    }

    public void RestartScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
