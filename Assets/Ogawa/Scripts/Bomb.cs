using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[DefaultExecutionOrder(-100)]

public class Bomb : MonoBehaviour
{
    private int _line = 0;
    public int rand;
    private EventSystem eventSystem;
    private int[] randomNumberArray = new int[3];
    public int line
    {
        get { return _line; }
        set
        {
            _line = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    public int[] RandomNumberArray
    {
        get { return randomNumberArray; }
        set { randomNumberArray = value; }
    }

    // Update is called once per frame

    public void Spawn()
    {
        //Raycast‚ÅF‚ğ”»’f‚·‚é‚½‚ß‚Ì”z—ñ
        List<int> numbers = new List<int> { 1, 2, 3};
        randomNumberArray = new int[3];
        for (int i = 0; i < randomNumberArray.Length; i++)
        {
            
            int randomIndex = UnityEngine.Random.Range(0, numbers.Count);
            randomNumberArray[i] = numbers[randomIndex];
            numbers.RemoveAt(randomIndex);
        }
    }
}
