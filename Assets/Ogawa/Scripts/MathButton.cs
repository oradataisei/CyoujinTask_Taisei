using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MathButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip BAD;
    [SerializeField] private AudioClip Nice;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject BUTTON;
    [SerializeField] private GameObject Good;
    [SerializeField] private GameObject Bad;
    [SerializeField] private GameObject Parent;

    public L_calculation l_Calculation;
    // Start is called before the first frame update




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
    public void Calc()
    {
        if(l_Calculation._QUIZ != 0 && !l_Calculation._isInvoked)
        {
            StartCoroutine("Push");
            if (CompareTag("Plus") && l_Calculation._QUIZ == 1)
            {
                Debug.Log("That's right!");
                l_Calculation._QUIZ = 99;
                audioSource.PlayOneShot(Nice);
                GameObject GoodInstance = Instantiate(Good, Parent.transform);
            }

            else if (CompareTag("Minus") && l_Calculation._QUIZ == 2)
            {
                Debug.Log("That's right!");
                l_Calculation._QUIZ = 99;
                audioSource.PlayOneShot(Nice);
                GameObject GoodInstance = Instantiate(Good, Parent.transform);
            }

            else if (CompareTag("Multi") && l_Calculation._QUIZ == 3)
            {
                Debug.Log("That's right!");
                l_Calculation._QUIZ = 99;
                audioSource.PlayOneShot(Nice);
                GameObject GoodInstance = Instantiate(Good, Parent.transform);
            }

            else if (CompareTag("Divi") && l_Calculation._QUIZ == 4)
            {
                Debug.Log("That's right!");
                l_Calculation._QUIZ = 99;
                audioSource.PlayOneShot(Nice);
                GameObject GoodInstance = Instantiate(Good, Parent.transform);
            }

            else
            {
                Debug.Log("That's wrong!");
                l_Calculation._QUIZ = 99;
                GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");
                audioSource.PlayOneShot(BAD);
                if (failedManager != null)

                {

                    AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();

                    allMiniGameFailedManager.AddPoint();

                }
                GameObject BadInstance = Instantiate(Bad, Parent.transform);

            }
        }
        
    }
    IEnumerator Push()
    {
        UnityEngine.UI.Image img = gameObject.GetComponent<UnityEngine.UI.Image>();
        Color originalColor = img.color;
        Color darkerColor = originalColor * 0.5f;

        img.color = darkerColor;
        yield return new WaitForSecondsRealtime(0.1f);
        Debug.Log($"Original: {originalColor}, Darker: {darkerColor}");
        img.color = originalColor;

        yield return null;
    }

}
