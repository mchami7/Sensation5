using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScoredUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeScoreTxt;
    [SerializeField] private int levelIndex;

    private void Start()
    {
        timeScoreTxt.text = TimeManager.instance.bestTimeScoreLevels[levelIndex - 1].ToString() + " seconds";
    }
}
