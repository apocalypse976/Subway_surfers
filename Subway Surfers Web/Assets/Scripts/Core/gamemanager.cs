using System.Threading;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    [HideInInspector] public float _timer;
    [SerializeField] private float _timeduration;

    [SerializeField] private TextMeshProUGUI _firstMin;
    [SerializeField] private TextMeshProUGUI _secondMin;
    [SerializeField] private TextMeshProUGUI separetor;
    [SerializeField] private TextMeshProUGUI _firstSec;
    [SerializeField] private TextMeshProUGUI _secondsec;

    public float coin, winnigs,after_fifty,total_winings;
    public float coin_miltiplier;

    private static gamemanager Singleton;
    public static gamemanager singleton
    {
        get
        {
            return Singleton;
        }
    }
    private void Start()
    {
        _timer= _timeduration;
        coin_miltiplier = 0.1f;
    }
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
           
        }
    }

   
    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            UpdateTimer(_timer);
        }
        else
        {
            stopTimer();
        }
       
       
    }
    #region Timer

    void UpdateTimer(float time)
    {
        float mins = Mathf.FloorToInt(time / 60);
        float secs= Mathf.FloorToInt(time % 60);

        string format= string.Format("{00:00}{1:00}",mins,secs);
        _firstMin.text = format[0].ToString();
        _secondMin.text = format[1].ToString();
        _firstSec.text = format[2].ToString();
        _secondsec.text = format[3].ToString();
    }

    void stopTimer() {
        if (_timer != 0)
        {
            _timer = 0;
            UpdateTimer(_timer); 
        }
    }
    #endregion

    #region Buttons
    public void BacktoHome()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
