using UnityEngine;
using UnityEngine.UI;

public class Ch_UI : MonoBehaviour
{
    Ch_GameManager GameManager;

    public GameObject[] Turn_txt;
    public Text[] GameEnd_txt;
    int White_win, Black_win;

    public GameObject Left_PawnMax_Panel;
    public GameObject Right_PawnMax_Panel;

    string pawn = "pawn";


    void Start()
    {
        GameManager = GetComponent<Ch_GameManager>();

        Load();
     

    }

    public void Next_Turn(int turn)
    {
        if(turn == 1)
        {
            Turn_txt[0].SetActive(true);
            Turn_txt[1].SetActive(false);
        }

        else
        {
            Turn_txt[1].SetActive(true);
            Turn_txt[0].SetActive(false);
        }

    }


    public void Game_End(int color) 
    {
        if (color == 1)
        {

            for (int i = 0; i < GameEnd_txt.Length; i++)
            {
                GameEnd_txt[i].gameObject.transform.parent.gameObject.SetActive(true);
                GameEnd_txt[i].text = "Black Win!";
            }

            Save(1);

        }

        else
        {
            for (int i = 0; i < GameEnd_txt.Length; i++)
            {
                GameEnd_txt[i].gameObject.transform.parent.gameObject.SetActive(true);
                GameEnd_txt[i].text = "White Win!";
                GameEnd_txt[i].color = Color.white;
            }

            Save(2);
                
        }

        
    }


    public void PawnMax_Panel_Setting(int color)
    {
       if (GameManager.Target.name != pawn) return;

        GameManager.Stop = true;

       if(color == 1)
       {
            Left_PawnMax_Panel.SetActive(true);
            Left_PawnMax_Panel.GetComponent<Ch_PawnChange>().Target_Set(GameManager.Target);
       }

       else
       {
            Right_PawnMax_Panel.SetActive(true);
            Right_PawnMax_Panel.GetComponent<Ch_PawnChange>().Target_Set(GameManager.Target);
       }

    }


    void Save(int color)
    {
        if (color == 1) Black_win++;
        else White_win++;

        PlayerPrefs.SetInt("Chess_White", White_win);
        PlayerPrefs.SetInt("Chess_Black", Black_win);
    }

    void Load()
    {
        White_win = PlayerPrefs.GetInt("Chess_White", 0);
        Black_win = PlayerPrefs.GetInt("Chess_Black", 0);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Chess_White", 0);
        PlayerPrefs.SetInt("Chess_Black", 0);

        Load();
       
    }

   


}
