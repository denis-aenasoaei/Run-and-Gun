using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTimeScript : MonoBehaviour
{
    private bool timeSlowed = false;
    public void SlowTime()
    {
        StartCoroutine(SlowTimeFor5Seconds());
    }

    private IEnumerator SlowTimeFor5Seconds()
    {
        if (timeSlowed)
            yield break;
        timeSlowed = true;
        Time.timeScale = 0.6f;
        yield return new WaitForSeconds(5.0f);
        Time.timeScale = 1;
        timeSlowed = false;
    }
}
