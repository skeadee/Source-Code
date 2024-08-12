using Unity.VisualScripting;
using UnityEngine;

public class Ch_PawnChange : MonoBehaviour
{
    Ch_GameManager GameManager;
    public Sprite[] Change_img;
    GameObject Target;

    string Black = "B_";
    string White = "W_";

    string Rook = "Rook";
    string Knight = "Knight";
    string Bishop = "Bishop";
    string Queen = "Queen";

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<Ch_GameManager>();
    }



    void Unit_Length_Check() // 유닛 겟수 체크 할때
    {
        int Rook_lenght = 0;
        int Knight_lenght = 0;
        int Queen_lenght = 0;
        int Bishop_lenght = 0;

        if (Target.tag == "Black")
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Black");
            

           for(int j=0;j< obj.Length; j++)
           {
                if (obj[j].name == Black + Rook) Rook_lenght++;
                if (obj[j].name == Black + Knight) Knight_lenght++;
                if (obj[j].name == Black + Bishop) Bishop_lenght++;
                if (obj[j].name == Black + Queen) Queen_lenght++;
           }


        }

        else
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("White");


            for (int j = 0; j < obj.Length; j++)
            {
                if (obj[j].name == White + Rook) Rook_lenght++;
                if (obj[j].name == White + Knight) Knight_lenght++;
                if (obj[j].name == White + Bishop) Bishop_lenght++;
                if (obj[j].name == White + Queen) Queen_lenght++;
            }
        }

        if (Rook_lenght == 2) transform.GetChild(0).gameObject.SetActive(false);
        if (Knight_lenght == 2) transform.GetChild(1).gameObject.SetActive(false);
        if (Bishop_lenght == 2) transform.GetChild(2).gameObject.SetActive(false);
        if (Queen_lenght == 1) transform.GetChild(3).gameObject.SetActive(false);

    }


    public void Target_Set(GameObject tar)
    {
        Target = tar;

        Unit_Length_Check();
    }

    public void Change_Imgae(int unit) // 버튼을 누를때
    {
        if (GameManager.GameEnd) return;

        Target.GetComponent<SpriteRenderer>().sprite = Change_img[unit];
        Target.GetComponent<Ch_Unit>().enabled = true;
        Change_Unit_Set(unit);

        GameManager.Stop = false;
        gameObject.SetActive(false);
    }

    void Change_Unit_Set(int unit) // 이미지를 바꿀때
    {
        if (unit == 0)
        {
            Target.GetComponent<Ch_Unit>().Rook = true;
           
            if (Target.tag == "Black") Target.name = Black + Rook;
            else Target.name = White + Rook;

        }

        else if (unit == 1)
        {
            Target.GetComponent<Ch_Unit>().Knight = true;
           
            if (Target.tag == "Black") Target.name = Black + Knight;
            else Target.name = White + Knight;

        }

        else if (unit == 2)
        {
            Target.GetComponent<Ch_Unit>().Bishop = true;
           

            if (Target.tag == "Black") Target.name = Black + Bishop;
            else Target.name = White + Bishop;
        }

        else if (unit == 3)
        {
            Target.GetComponent<Ch_Unit>().Queen = true;

            if (Target.tag == "Black") Target.name = Black + Queen;
            else Target.name = White + Queen;
        }

        Target.GetComponent<Ch_Unit>().img_number = unit + 1;
        Destroy(Target.GetComponent<Ch_Pawn>());
    }


}
