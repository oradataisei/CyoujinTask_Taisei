using UnityEngine;

public class Good_or_Bad : MonoBehaviour
{
    public L_calculation l_Calculation;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoodBad", 1);
    }

    // Update is called once per frame
    void GoodBad()
    {
            Destroy(gameObject);
    }
}
