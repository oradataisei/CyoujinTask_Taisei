using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Bomb arrayHolder;
    private bool onCutted = false;
    [SerializeField] BombManager bombManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundEffect;

    [SerializeField] private Sprite CuttedRed;
    [SerializeField] private Sprite CuttedBlue;
    [SerializeField] private Sprite CuttedYellow;
    private Image imege;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        arrayHolder = GameObject.FindAnyObjectByType<Bomb>();
        int firstElement = arrayHolder.RandomNumberArray[0];
        if (bombManager == null)
        {
            bombManager = FindObjectOfType<BombManager>();
            imege = GetComponent<Image>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        }
    }
    void RemoveFirstElement()
    {
        int[] newArray = new int[arrayHolder.RandomNumberArray.Length - 1];
        for(int i = 1; i < arrayHolder.RandomNumberArray.Length; i++)
        {
            newArray[i - 1] = arrayHolder.RandomNumberArray[i];
        }
        arrayHolder.RandomNumberArray = newArray;
        bombManager.line -= 1;
    }

    public void OnClicked()
    {
        if (CompareTag("lineYellow") && arrayHolder.RandomNumberArray[0] == 1 && onCutted == false)
        {
            RemoveFirstElement();
            imege.sprite = CuttedYellow;
            transform.localScale -= Vector3.right * 0.024f;
            transform.localScale += Vector3.up * 0.36f;
            transform.position += Vector3.down * 0.15f;
            onCutted = true;
            audioSource.PlayOneShot(soundEffect);

        }
        else if (CompareTag("lineBlue") && arrayHolder.RandomNumberArray[0] == 2 && onCutted == false)
        {
            RemoveFirstElement();
            imege.sprite = CuttedBlue;
            transform.localScale -= Vector3.right * 0.024f;
            transform.localScale += Vector3.up * 0.36f;
            transform.position += Vector3.down * 0.15f;
            onCutted = true;
            audioSource.PlayOneShot(soundEffect);
        }
        else if (CompareTag("lineRed") && arrayHolder.RandomNumberArray[0] == 3 && onCutted == false)
        {
            RemoveFirstElement();
            imege.sprite = CuttedRed;
            transform.localScale -= Vector3.right * 0.024f;
            transform.localScale += Vector3.up * 0.36f;
            transform.position += Vector3.down * 0.15f;
            onCutted = true;
            audioSource.PlayOneShot(soundEffect);
        }
        else if(onCutted == false)
        {
            bombManager.Out = true;
            Debug.Log("Bomb");
        }
    }
}
