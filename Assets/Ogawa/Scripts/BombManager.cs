using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] Timer Timer;
    private int _line = 0;
    bool Success = false;
    bool isFirstSpawn = true;
    private bool _Delete = false;
    private bool _Out = false;
    private bool _Doon = false;
    private GameObject lineBlueObject;
    private GameObject lineYellowObject;
    private GameObject lineRedObject;

    [SerializeField] private GameObject Kaboom;
    [SerializeField] private GameObject lineBlue;
    [SerializeField] private GameObject lineYellow;
    [SerializeField] private GameObject lineRed;


    [SerializeField] private GameObject Icon1;
    [SerializeField] private GameObject Icon2;
    [SerializeField] private GameObject Icon3;

    [SerializeField] private GameObject lineManager;
    [SerializeField] private Bomb BombScript;
    [SerializeField] private GameObject Parent;
    GameObject Icon1Object;
    GameObject Icon2Object;
    GameObject Icon3Object;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundEffect;

    public int line
    {
        get { return _line; }
        set { _line = value;}
    }
    public bool Delete
    {
        get { return _Delete; }
        set { _Delete = value; }
    }

    public bool Doon
    {
        get { return _Doon; }
        set { _Doon = value; }
    }

    public bool Out
    {
        get { return _Out; }
        set { _Out = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _line = 3;
        audioSource = GetComponent<AudioSource>();
        Invoke("SpawnBomb", 0.01f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_line == 0)
        {
            _line = 3;
            _Delete = true;
            Destroy(Icon1Object);
            Destroy(Icon2Object);
            Destroy(Icon3Object);
            Invoke("SpawnBomb", 1f);
            Success = true;
        }

        if(_Out == true)
        {
            //爆発した
            _Out = false;
            _line = 3;
            _Delete = true;
            Destroy(Icon1Object);
            Destroy(Icon2Object);
            Destroy(Icon3Object);
            Destroy(lineBlueObject);
            Destroy(lineYellowObject);
            Destroy(lineRedObject);
            GameObject KaboomInstance = Instantiate(Kaboom, Parent.transform);
            _Doon = true;
            Destroy(KaboomInstance,0.7f);
            Invoke("SpawnBomb", 1f);
            audioSource.PlayOneShot(soundEffect);

            GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");

            if (failedManager != null)

            {

                AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();

                allMiniGameFailedManager.AddPoint();

            }

        }
    }


    void SpawnBomb()
    {
        if (Success)
        {
            Destroy(lineBlueObject);
            Destroy(lineYellowObject);
            Destroy(lineRedObject);
            Success = false;
        }

        if (isFirstSpawn == false && !Success)
        {
            
        }
        else
        {
            isFirstSpawn = false;
        }

        //リスポーン

        _Delete = false;
        _Doon = false;
        BombScript.Spawn();
        lineBlueObject = Instantiate(lineBlue, Parent.transform);
        lineYellowObject= Instantiate(lineYellow, Parent.transform);
        lineRedObject = Instantiate(lineRed, Parent.transform);
        Icon1Object = Instantiate(Icon1, Parent.transform);
        Icon2Object = Instantiate(Icon2, Parent.transform);
        Icon3Object = Instantiate(Icon3, Parent.transform);
        Timer.the_timer = false;
    }
}
