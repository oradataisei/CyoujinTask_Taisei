using UnityEngine;

public class Kaboom : MonoBehaviour
{
    [SerializeField]private BombManager bombManager;
    [SerializeField] private GameObject The_bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bombManager.Doon) The_bomb.SetActive (false);
        else The_bomb.SetActive (true);
    }
}
