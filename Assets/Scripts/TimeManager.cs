using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        bestTimeScoreLevels = new float[numberOfLevels];
    }

    public float[] bestTimeScoreLevels { get; set; }

    [SerializeField] private int numberOfLevels;


}
