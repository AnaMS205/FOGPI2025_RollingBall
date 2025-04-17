using UnityEngine;
using UnityEngine.Events;
//Universal timer script, should be useable anywhere I need
namespace MySavedScripts{  // stop claching if myltiple timers


public class Timer //countdown timer
{
    private float m_timeLeft = 0.0f;

    public float timeLeft{get{return m_timeLeft;}}

    public UnityEvent timeout;  //pause timer

    public bool autoStart = false;
    public bool autoRestart = false;
    public bool useScaledTime = true;

    public float countDownTime = 1.0f;
    public float timeScale = 1.0f;  //make timer faster or slower
    public bool timeRunning {get{return m_timeLeft>0.0f;}} //check if time is running

    void Start(){
        if (autoStart){
            //Start timer
        }
    }

    void Update(){
        if (m_timeLeft >0.0f){
            if(useScaledTime){
                m_timeLeft -= (Time.deltaTime* timeScale);
            }else{
                m_timeLeft -= (Time.unscaledDeltaTime* timeScale);
            }
            if(m_timeLeft <= 0.0f){
                timeout.Invoke();

                if(autoRestart){
                    StartTimer();
                }
            }
        }
    }

    public void StartTimerFromEvent(){
        StartTimer();

    }

    public void StopTimer(){
        m_timeLeft = 0.0f;
    }

    public void StartTimer(float? _countDown = null, bool _autoRestart = false){
        if(_countDown != null && _countDown > 0.0f){
            countDownTime = (float)_countDown;
        }
        autoRestart = _autoRestart;

        m_timeLeft = countDownTime;
    }
}


}