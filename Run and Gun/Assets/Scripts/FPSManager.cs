using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSManager : MonoBehaviour
{
    void Update()
    {
        var gos = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(gos.Length);
        if (gos.Length <= 0)
        {
            SceneManager.LoadScene("Running_Level");            
        }
    }
}
