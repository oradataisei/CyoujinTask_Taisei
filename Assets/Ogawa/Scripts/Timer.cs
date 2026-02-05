using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] BombManager bombManager;
    private float totalTime;
    [SerializeField] private int minute;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float second = 30f;

    private int oldDisplaySeconds = -1;
    private Text timer;
    private float initialTime;
    private bool isPaused = false;
    private bool The_Timer = false;
    // Start is called before the first frame update

    public bool the_timer
    {
        get { return The_Timer; }
        set { The_Timer = value; }
    }
    void Start()
    {

        isPaused = false;
        initialTime = minute * 60 + second;
        //タイマースタート
        totalTime = initialTime;
        UpdateTimer();
        Debug.Log("Timer Start!");
    }

    // Update is called once per frame
    void Update()
    {

        //制限時間が0以下なら何もしない
        if (isPaused || totalTime <= 0f)return;


        int displayMinute = (int)(totalTime / 60);
        int displaySecond = (int)(totalTime % 60);


        //totalTime = minute * 60 + second;
        totalTime -= Time.deltaTime;

        minute = (int)totalTime/60;
        second = totalTime - minute * 60;

        if((int)oldDisplaySeconds != displaySecond)
        {
            UpdateTimer();
            Debug.Log("Time Update: ");
            oldDisplaySeconds = displaySecond;
        }

        if(totalTime <= 0f)
        {
            Debug.Log("Time's up!");
            bombManager.Out = true;
        }

        if (bombManager.Out == true && The_Timer == false)
        {
            Pause();
            The_Timer = true;
        }

        if (bombManager.Delete == true && The_Timer == false)
        {
            Pause();
            The_Timer = true;
            bombManager.Delete = false;
        }

        if (bombManager.Delete == false && The_Timer == true)
        {
            Reset();
            Resume();
        }
    }

    //タイマー処理
    private void UpdateTimer()
    {
        int displayMinute = (int)(totalTime / 60);
        int displaySecond = (int)(totalTime % 60);
        string timetext = displayMinute.ToString("00") + ":" + displaySecond.ToString("00");
        timerText.text = timetext;//画面に反映
    }

    //一時停止
    public void Pause()
    {
        isPaused = true;
    }

    //再開
    public void Resume()
    {
        isPaused = false;
    }

    //タイマーのリセット
    public void Reset()
    {
        totalTime = initialTime;
        oldDisplaySeconds = -1;
        UpdateTimer();
    }
}
