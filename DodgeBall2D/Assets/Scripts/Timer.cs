﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour {
    #region Attributes
    [SerializeField]
    private Text text;          // The text to show the time
    private Coroutine routine;  // The current timer routine
    [SyncVar(hook = "SetSeconds")]
    private int seconds;        // The time left in seconds
    #endregion

    #region Properties
	#endregion

	#region Event Functions
	// Awake is called before Start
	private void Awake ()
	{
		
	}

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}
	#endregion
	
	#region Methods
	// Start a timer and stop the other one
    public void StartTimer (int sec)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(TimeRoutine(sec));
    }

    // Set the seconds
    private void SetSeconds (int sec)
    {
        seconds = sec;
        if (text != null)
        {
            text.text = string.Format("{0}:{1:00}", seconds / 60, seconds % 60);
        }
    }
	#endregion
	
	#region Coroutines
    // Start a timer with certain seconds
	public IEnumerator TimeRoutine (int sec)
    {
        SetSeconds(sec);
        while (seconds > 0)
        {
            yield return new WaitForSeconds(1);
            SetSeconds(seconds - 1);
        }
    }
	#endregion
}
