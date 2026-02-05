using System.Collections;
using UnityEngine;
using TMPro;

public class Calc_Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CalcTimer;
    public L_calculation l_Calculation;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip BAD;
    [SerializeField] private int inputTime;
    [SerializeField] private GameObject TimeUp;
    [SerializeField] private GameObject Parent;
    private int h;
    private int m;
    private int s;

    private int num;
    private Coroutine Timer;

    private void Start()
    {
        num = inputTime;
        Timer = StartCoroutine(TimeCount());
    }

    private void Update()
    {       
        if (l_Calculation._isQuizing == false && Timer == null)
        {
            l_Calculation._isQuizing = true;

            inputTime = 20;
            num = inputTime;
            Timer = StartCoroutine(TimeCount());
        }
    }

    private IEnumerator TimeCount()
    {
        for (int i = 0; i < num; i++)
        {
            if (l_Calculation._QUIZ == 99)
            {
                Timer = null;
                yield break;
            }
            inputTime -= 1;
            h = inputTime / 3600;
            m = (inputTime - 3600 * h) / 60;
            s = (inputTime - 3600 * h) % 60;

            CalcTimer.text = m.ToString("D2") + ":" + s.ToString("D2");
            yield return new WaitForSeconds(1f);

        }
        Debug.Log("Time's Up!");
        GameObject TimeUpInstance = Instantiate(TimeUp, Parent.transform);
        audioSource.PlayOneShot(BAD);
        l_Calculation._QUIZ = 99;
        l_Calculation._isQuizing = false;
        Timer = null;
        yield break;
    }
}
