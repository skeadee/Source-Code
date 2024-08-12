using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Ch_Click_Move : MonoBehaviour
{
    Ch_GameManager GameManager;
    Ch_UI UI;
  
    Vector3 org_Loc;
    public Vector3 Start_Move;
    public GameObject enemy;
    int Pawn_Max;

    void Awake()
    {
        GameObject Manager = GameObject.Find("GameManager");
        
        GameManager = Manager.GetComponent<Ch_GameManager>();
        UI = Manager.GetComponent<Ch_UI>();

        org_Loc = transform.position;
        gameObject.transform.position = org_Loc + Start_Move;
    }

    public void Enemy_Set(GameObject target)
    {
        enemy = target;
    }

    public void Img_Set(int img_number , int color)
    {
       if(color == 1) gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Black_MoveCheck_img[img_number];   
       
       else
       {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.White_MoveCheck_img[img_number];
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
       }
    }

    public void Pawn_Max_LocationSettting(int max)
    {
        Pawn_Max = max;
    }


    void Pawn_Max_End() // 폰이 맵 끝쪽에 도착했을 때
    {
        if(GameManager.Target.tag == "Black") UI.PawnMax_Panel_Setting(1);
        else UI.PawnMax_Panel_Setting(0);
       
    }

   

    void OnMouseDown()
    {
        if (GameManager.Stop) return;

        GameManager.Target.transform.position = org_Loc;
        if (GameManager.Target.name == "pawn") GameManager.Target.GetComponent<Ch_Pawn>().First = false;

        if (GameManager.Target.transform.position.y == Pawn_Max) Pawn_Max_End();

        GameManager.Turn_Change();
        GameManager.Target_Reset();
        GameManager.Doll_Set_Sound();

        if (enemy != null) Destory_Target();
      

        Destory_Move();
    }

    void Destory_Target() // 타겟 오브젝트를 제거할 때
    {
        GameManager.GameEnd_Check(enemy);
        Destroy(enemy);
       
    }

   

    void Destory_Move()
    {
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Respawn");

        for (int i = 0; i < tag.Length; i++) Destroy(tag[i]);
    }


}
