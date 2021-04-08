using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameover = false;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject tapToStartText;
    public GameObject abilityButton1;


    void Start()
    {
        gameover = false;
        isGameStarted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            Destroy(abilityButton1);
        }
        if (SwipeManager.tap)
        {
            isGameStarted = true;

            abilityButton1.SetActive(true);
            Destroy(tapToStartText);
        }
    }
}
