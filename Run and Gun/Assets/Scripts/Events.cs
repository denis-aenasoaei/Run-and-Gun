using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Running_Level");
    }

    public void LoadMainMenu()
    {
        // load menu scene
    }


}
