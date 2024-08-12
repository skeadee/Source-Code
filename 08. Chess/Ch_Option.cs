using UnityEngine;

public class Ch_Option : MonoBehaviour
{
    Ch_GameManager GameManager;

    public GameObject Option_Panel;
    public GameObject Empty_Panel;

    public GameObject EmptyCheck;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<Ch_GameManager>();
    }

    public void Button_Click()
    {
        if (EmptyCheck.activeSelf || GameManager.GameEnd) return;

        if (Option_Panel.activeSelf)
        {
            Option_Panel.SetActive(false);
            Empty_Panel.SetActive(false);
            GameManager.Stop = false;
        }

        else
        {
            Option_Panel.SetActive(true);
            Empty_Panel.SetActive(true);
            GameManager.Stop = true;
        }

    }
}
