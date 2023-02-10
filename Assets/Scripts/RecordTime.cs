using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordTime : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TimeManager.instance.bestTimeScoreLevels[SceneManager.GetActiveScene().buildIndex - 1] = Time.timeSinceLevelLoad;
        SceneManager.LoadScene(0);
    }
}
