using System.Collections;
using UnityEngine;


public class Ch_Pawn : MonoBehaviour
{
    Ch_GameManager GameManager;
    public bool First = true;

    string Attack_Tag;
    bool white = false;
    int Turn_Color;
    public int img_number;

    public int Max;
   
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<Ch_GameManager>();

        if (gameObject.tag == "White")
        {
            Attack_Tag = "Black";
            Turn_Color = 2;
        }



        else
        {
            Attack_Tag = "White";
            Turn_Color = 1;
        }

        if (gameObject.tag == "White") white = true;
    }


    void Location_Prefabs(Vector3[] Dir) // 위치 이동
    {

        Vector3 pos = transform.position;
        pos.z = -15;
        RaycastHit hit;

        for (int i = 0; i < Dir.Length; i++)
        {
          
            Vector3 Loc = transform.position + Dir[i];
            Vector3 end = (Loc - pos).normalized;
           

            if (Physics.Raycast(pos, end, out hit, 20f))
            {

                // 아무것도 없고 보드안이라면 , 그전에 클릭한 유닛의 이동가능 범위의 오브젝트가 안 사라 졌다면
                if (hit.collider.gameObject.tag == "Ground")
                {
                    GameObject p = Instantiate(GameManager.Click, Loc, Quaternion.identity);
                    p.GetComponent<Ch_Click_Move>().Img_Set(img_number, Turn_Color);
                    p.GetComponent<Ch_Click_Move>().Pawn_Max_LocationSettting(Max);
                }

                else break; // 앞에 무언가 있다면 바로 나가기

              

            }

        }

    }


    void Attack(Vector3[] Dir)
    {

        Vector3 pos = transform.position;
        pos.z = -15;
        RaycastHit hit;

        for (int i = 0; i < Dir.Length; i++)
        {

            Vector3 Loc = transform.position + Dir[i];
            Vector3 end = (Loc - pos).normalized;


            if (Physics.Raycast(pos, end, out hit, 20f))
            {
                if (hit.collider.gameObject.tag == Attack_Tag)
                {
                    GameObject Enemy =  Instantiate(GameManager.Click, Loc, Quaternion.identity);

                    Enemy.GetComponent<Ch_Click_Move>().Enemy_Set(hit.collider.gameObject);
                    Enemy.GetComponent<Ch_Click_Move>().Img_Set(img_number, Turn_Color);
                    Enemy.GetComponent<Ch_Click_Move>().Pawn_Max_LocationSettting(Max);

                }

            }

        }

    }



    void OnMouseDown()
    {
        
        if (GameManager.GameEnd) return;
        if (GameManager.Turn != Turn_Color || GameManager.Target == gameObject) return;
        if (GameManager.Stop) return;

        StartCoroutine(Process());


    }

    IEnumerator Process()
    {
        yield return GameManager.Destory_Move();

        GameManager.Target = gameObject;

        if (white)
        {
            if (First) Location_Prefabs(GameManager.First_Pawn_Move2);
            else Location_Prefabs(GameManager.Pawn_Move2);

            Attack(GameManager.Pawn_Attack2);
        }

        else
        {
            if (First) Location_Prefabs(GameManager.First_Pawn_Move); // 움직임을 담당
            else Location_Prefabs(GameManager.Pawn_Move);

            Attack(GameManager.Pawn_Attack); // 공격을 담당
        }

    }


   

}
