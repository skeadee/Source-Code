using UnityEngine;

public class N_Count : MonoBehaviour
{
    N_GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<N_GameManager>();
    }

    void OnDestroy()
    {
        GameManager.GameStop = false; 
    }
}
