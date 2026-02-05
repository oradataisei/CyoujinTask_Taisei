using UnityEngine;
using UnityEngine.UI;
[DefaultExecutionOrder(-200)]

public class Icons : MonoBehaviour
{
    private bool _Delete = false;
    private int _line = 0;
    public int i;
    [SerializeField] private Bomb arrayHolder;
    [SerializeField] GameObject target;

    [SerializeField] private Sprite YellowIcons;
    [SerializeField] private Sprite BlueIcons;
    [SerializeField] private Sprite RedIcons;
    private Image sr;
    // Start is called before the first frame update

    public bool Delete
    {
        get { return _Delete; }
        set { _Delete = value; }
    }

    public int line
    {
        get { return _line; }
        set
        {
            _line = value;
        }
    }
    void Start()
    {
        sr = GetComponent<Image>();
        arrayHolder = GameObject.FindAnyObjectByType<Bomb>();
        int firstElement = arrayHolder.RandomNumberArray[0];

        if (CompareTag("Icon1"))i = 0;
        else if (CompareTag("Icon2")) i = 1;
        else if (CompareTag("Icon3")) i = 2;

        Debug.Log("Selected Icon i: " + i);

        SetColor();
    }
    // Update is called once per frame
    void SetColor()
    {
        int value = arrayHolder.RandomNumberArray[i];
        switch(value)
        {
            case 1:
                sr.sprite = YellowIcons;
                break;
            case 2:
                sr.sprite = BlueIcons;
                break;
            case 3:
                sr.sprite = RedIcons;
                break;
            default:
                Debug.Log("What?");
                break;
        }
    }
    public void SetArrayHolder(Bomb newArrayHolder)
    {
        arrayHolder = newArrayHolder;
    }

    void Update()
    {
        if ((_line == 0) && (_Delete == true))
        {
            Destroy(this.gameObject);
        }
    }
}
