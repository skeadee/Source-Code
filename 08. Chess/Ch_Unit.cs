using UnityEngine;
using System.Collections;

public class Ch_Unit : MonoBehaviour
{
    Ch_GameManager GameManager;
   
    string Attack_Tag;
    public bool Rook, Bishop, Queen , Knight , King;
    int Turn_Color;

    public int img_number;


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


    }


    void Straight_Check(Vector3[] Dir , int Length) // 일직선 유닛 담당 (룩 , 비숍 , 퀸 , 킹)
    {

        Vector3 pos = transform.position;
        pos.z = -15;
        RaycastHit hit;

        for (int i = 0; i < Length; i++)
        {

            Vector3 Loc = (transform.position + Dir[i]);
            Vector3 end = (Loc - pos).normalized;

            if (Physics.Raycast(pos, end, out hit, 20f))
            {

                if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Respawn")
                {
                    GameObject Empty = Instantiate(GameManager.Click, Loc, Quaternion.identity);
                    Empty.GetComponent<Ch_Click_Move>().Img_Set(img_number , Turn_Color);
                }
               
                else if (hit.collider.tag == Attack_Tag) // 적과 충돌 한다면
                {
                    GameObject Enemy = Instantiate(GameManager.Click, Loc, Quaternion.identity); 
                    Enemy.GetComponent<Ch_Click_Move>().Enemy_Set(hit.collider.gameObject);
                    Enemy.GetComponent<Ch_Click_Move>().Img_Set(img_number , Turn_Color);

                    break;
                }

                else break; // 아군과 충돌시 바로 종료
               

            }

        }

    }


    void Exception_Check(Vector3[] Dir, int Length) // 예외 유닛 (나이트)
    {
        Vector3 pos = transform.position;
        pos.z = -15;
        RaycastHit hit;

        for (int i = 0; i < Length; i++)
        {

            Vector3 Loc = (transform.position + Dir[i]);
            Vector3 end = (Loc - pos).normalized;

            if (Physics.Raycast(pos, end, out hit, 20f))
            {

                if (hit.collider.gameObject.tag == "Ground")
                {
                   GameObject Empty = Instantiate(GameManager.Click, Loc, Quaternion.identity);
                    Empty.GetComponent<Ch_Click_Move>().Img_Set(img_number , Turn_Color);
                }

                else if (hit.collider.tag == Attack_Tag) // 적과 충돌 한다면
                {
                    GameObject Enemy = Instantiate(GameManager.Click, Loc, Quaternion.identity);
                    Enemy.GetComponent<Ch_Click_Move>().Enemy_Set(hit.collider.gameObject);
                    Enemy.GetComponent<Ch_Click_Move>().Img_Set(img_number , Turn_Color);
                }

                


            }

        }
    }


    void OnMouseDown()
    {

        if (GetComponent<Ch_Unit>().enabled == false) return; 
        if (GameManager.Turn != Turn_Color || GameManager.GameEnd) return;
        if (GameManager.Stop) return; // 게임 정지 상태라면 리턴
        if (GameManager.Target == gameObject) return;

        StartCoroutine(Process());
       
    }

    IEnumerator Process()
    {
        yield return GameManager.Destory_Move();

        GameManager.Target = gameObject;


        if (Rook)
        {
            Straight_Check(GameManager.Right, 7);
            Straight_Check(GameManager.Left, 7);
            Straight_Check(GameManager.Up, 7);
            Straight_Check(GameManager.Down, 7);
        }

        else if (Bishop)
        {
            Straight_Check(GameManager.UR, 7);
            Straight_Check(GameManager.DR, 7);
            Straight_Check(GameManager.UL, 7);
            Straight_Check(GameManager.DL, 7);
        }

        else if (Queen)
        {
            Straight_Check(GameManager.Right, 7);
            Straight_Check(GameManager.Left, 7);
            Straight_Check(GameManager.Up, 7);
            Straight_Check(GameManager.Down, 7);
            Straight_Check(GameManager.UR, 7);
            Straight_Check(GameManager.DR, 7);
            Straight_Check(GameManager.UL, 7);
            Straight_Check(GameManager.DL, 7);
        }

        else if (King)
        {
            Straight_Check(GameManager.Right, 1);
            Straight_Check(GameManager.Left, 1);
            Straight_Check(GameManager.Up, 1);
            Straight_Check(GameManager.Down, 1);
            Straight_Check(GameManager.UR, 1);
            Straight_Check(GameManager.DR, 1);
            Straight_Check(GameManager.UL, 1);
            Straight_Check(GameManager.DL, 1);
        }

        else if (Knight)
        {
            Exception_Check(GameManager.Knight_Move, 8);
        }
    }

   




}
