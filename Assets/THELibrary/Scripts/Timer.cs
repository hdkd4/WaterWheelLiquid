using UnityEngine;
using UnityEngine.Events;

namespace THELibrary
{
public class Timer : MonoBehaviour
{
    private float m_timeLeft = 0.0f;
    public UnityEvent timeout;
    public bool autoStart = false;
    public bool autoRestart = false;
    public bool useScaleTime = true;
    public float timeLeft { get { return m_timeLeft;} }
    public float timeScale = 1.0f;
    public float countDownTime = 1.0f;
    public bool countingDown { get { return m_timeLeft > 0.0f;} }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (autoStart)
        StartTimer();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_timeLeft>0.0f)
        {
            if (useScaleTime)
                m_timeLeft -= (Time.deltaTime * timeScale);
            else
                m_timeLeft -= (Time.unscaledDeltaTime * timeScale);
            if (timeLeft <= 0.0f)
            {
                timeout.Invoke();
                if(autoRestart)
                    StartTimer();
            }
        }
    }

    public void StartTimerFromEvent()
    {
        StartTimer();
    }
    public void StopTimer()
    {
        m_timeLeft = 0.0f;
    }
    public void StartTimer(float? _countDown = null, bool? _autoRestart = false)
    {
        if (_countDown != null && _countDown > 0.0f)
            countDownTime = (float)_countDown;
        autoRestart = (bool)_autoRestart;
        m_timeLeft = countDownTime;
    }
}
}