using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    GameObject Time_daily;

    int second = 0;
    int minute = 0;
    float Time_current;
    float Time_start;
    float Time_Sumcooltime = 1;
    float Time_clearSecond;
    float Time_clearMinute;

    void Start()
    {
        this.Time_daily = GameObject.Find("Time");
    }
    void Update()
    {
        UI_Time();
        Check_CoolTime();
    }
    void Check_CoolTime()
    {
        Time_current = Time.time - Time_start;
        if (Time_current > Time_Sumcooltime)
        {
            second += 1;
            if (second >= 60)
            {
                minute++;
                second = 0;
            }
            Reset_CoolTime();
        }
    }
    void UI_Time()
    {
        if (second > 9 && minute > 9)
        {
            this.Time_daily.GetComponent<Text>().text = minute + " : " + second;
        }
        else if (second < 10 && minute > 9)
        {
            this.Time_daily.GetComponent<Text>().text = minute + " : " + "0" + second;
        }
        else if (second > 9 && minute < 10)
        {
            this.Time_daily.GetComponent<Text>().text = "0" + minute + " : " + second;
        }
        else
        {
            this.Time_daily.GetComponent<Text>().text = "0" + minute + " : " + "0" + second;
        }
    }
    void Reset_CoolTime()
    {
        Time_current = Time_Sumcooltime;
        Time_start = Time.time;
    }
    public float ClearTimeSecond()
    {
        Time_clearSecond = second;
        return Time_clearSecond;
    }
    public float ClearTimeMinute()
    {
        Time_clearMinute = minute;
        return Time_clearMinute;
    }
}
