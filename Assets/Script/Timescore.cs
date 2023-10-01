
using UnityEngine;
using UnityEngine.UI;
public class Timescore : MonoBehaviour
{
    float _second;
    float _minute;

   [SerializeField] GameObject _timescore;
   [SerializeField] GameObject _timer;
    private void OnEnable()
    {
        _second = _timer.GetComponent<Timer>().ClearTimeSecond();
        _minute = _timer.GetComponent<Timer>().ClearTimeMinute();

            if (_second > 9 && _minute > 9)
            {
                this._timescore.GetComponent<Text>().text = _minute + " : " + _second;
            }
            else if (_second < 10 && _minute > 9)
            {
                this._timescore.GetComponent<Text>().text = _minute + " : " + "0" + _second;
            }
            else if (_second > 9 && _minute < 10)
            {
                this._timescore.GetComponent<Text>().text = "0" + _minute + " : " + _second;
            }
            else
            {
                this._timescore.GetComponent<Text>().text = "0" + _minute + " : " + "0" + _second;
            }
            // this._timescore.GetComponent<Text>().text = _minute + " : " + _second;
    }
}
