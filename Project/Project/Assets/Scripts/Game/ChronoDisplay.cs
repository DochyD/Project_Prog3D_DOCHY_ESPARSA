using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoDisplay : MonoBehaviour
{
    
    [SerializeField] private TMPro.TextMeshProUGUI chronoDisplay;
    private bool timerStarted = false;
    private float chrono = default;

    public void  startTimer() {
        timerStarted = true;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer() {
        while (timerStarted) {
            yield return new WaitForEndOfFrame();
            chrono += Time.deltaTime;
            chronoDisplay.text = Mathf.Floor(chrono / 60) + " : " + Mathf.RoundToInt(chrono % 60);
        }
        
        
    }


    public float getTimer() {
        return chrono;
    }

    public void stopChrono() 
    {
        timerStarted = false;
    }


}
