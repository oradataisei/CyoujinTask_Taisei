using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class L_calculation : MonoBehaviour
{
    [SerializeField] private float changeTime;
    [SerializeField] private int Answer;
    int QUIZ = 0;
    bool isQuizing = true;
    bool isInvoked = false;
    public int _QUIZ
    {
        get { return QUIZ; }
        set { QUIZ = value; }
    }

    public bool _isQuizing
    {
        get { return isQuizing; }
        set { isQuizing = value; }
    }

    public bool _isInvoked
    {
        get { return isInvoked; }
        set { isInvoked = value; }
    }
    [SerializeField] private TextMeshProUGUI _Text;
    [SerializeField] TextAsset _Calculation_Problem;

    private List<string[]> _Questions = new List<string[]>();
    // Start is called before the first frame update
    void Start()
    {

        StringReader reader = new StringReader(_Calculation_Problem.text);
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _Questions.Add(line.Split(','));
        }
        Invoke("Quiz", 0);
        Debug.Log(_Questions.Count);
    }

    // Update is called once per frame


    void Update()
    {
        if (QUIZ == 99 && !isInvoked)
        {
            isInvoked = true;
            Invoke("Quiz", changeTime);
        }
    }

    void Quiz()
    {
        isQuizing = false;
        isInvoked = false;
        
        var rndIndex = Random.Range(0, _Questions.Count);
        if(rndIndex <= 14) 
        {
            QUIZ = 1;
        }

        if (rndIndex > 14 && rndIndex <= 29)
        {
            QUIZ = 2;
        }

        if (rndIndex > 29 && rndIndex <= 44)
        {
            QUIZ = 3;
        }

        if (rndIndex > 44)
        {
            QUIZ = 4;
        }
        Debug.Log(QUIZ);
        Debug.Log(rndIndex);
        
        _Text.text = _Questions[rndIndex][0];
    }
}

