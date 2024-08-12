using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Ch_GameManager : MonoBehaviour
{
    Ch_UI UI;

    public int Turn = 1;
    public float One_Spcae = 1f; // 한칸 간격

    public GameObject Target;
    [HideInInspector] public GameObject Click;

   [HideInInspector] public Vector3[] Right, Left, Up, Down;
   [HideInInspector] public Vector3[] UR, DR, UL, DL;
   [HideInInspector] public Vector3[] Knight_Move;

   [HideInInspector] public Vector3[] First_Pawn_Move; // 검은색 
   [HideInInspector] public Vector3[] Pawn_Move;
   [HideInInspector] public Vector3[] Pawn_Attack;

   [HideInInspector] public Vector3[] First_Pawn_Move2; // 흰색
   [HideInInspector] public Vector3[] Pawn_Move2;
   [HideInInspector] public Vector3[] Pawn_Attack2;

   [HideInInspector] public GameObject White_King;
   [HideInInspector] public GameObject Black_King;

    public Sprite[] Black_MoveCheck_img;
    public Sprite[] White_MoveCheck_img;

    public bool Stop = false;
    public bool GameEnd = false;

    AudioSource Doll_Set;
    public AudioClip GameEnd_Sound;


    void Awake()
    {

        UI = GetComponent<Ch_UI>();
        Doll_Set = GetComponent<AudioSource>();
    }

    void Start()
    {
        Right = new Vector3[7];
        Up = new Vector3[7];
        Left = new Vector3[7];
        Down = new Vector3[7];

        UR = new Vector3[7];
        DR = new Vector3[7];
        UL = new Vector3[7];
        DL = new Vector3[7];

        Location_Set();
    }

    void Location_Set() // 처음시 위치를 세팅함
    {
        for (int i = 0; i < 7; i++)
        {
            float p = i + One_Spcae;

            Right[i] = new Vector3(p, 0, 0);
            Up[i] = new Vector3(0, p, 0);
            Left[i] = new Vector3((p) * -1, 0, 0);
            Down[i] = new Vector3(0, (p) * -1, 0);

            UR[i] = new Vector3(p, p, 0);
            DR[i] = new Vector3(p, p * -1, 0);

            UL[i] = new Vector3(p * -1, p, 0);
            DL[i] = new Vector3(p * -1, p * -1, 0);
        }

    }


    public void Target_Reset()
    {
        Target = null;
    }

    public IEnumerator Destory_Move()
    {
       GameObject[] tag = GameObject.FindGameObjectsWithTag("Respawn");

       for (int i = 0; i < tag.Length; i++)
       {
            Destroy(tag[i]);
       }

        yield break;

    }

   
    public void GameEnd_Check(GameObject Target) 
    {
        if (Target == White_King)
        {
            UI.Game_End(1);
            GameEnd = true;

            Doll_Set.clip = GameEnd_Sound;
            Doll_Set.Play();
        }

        else if (Target == Black_King)
        {
            UI.Game_End(2);
            GameEnd = true;

            Doll_Set.clip = GameEnd_Sound;
            Doll_Set.Play();
        }

       

    }

    public void Turn_Change()
    {
        Turn = (Turn == 1) ? 2 : 1;

        UI.Next_Turn(Turn);
    }

    public void Doll_Set_Sound()
    {
        Doll_Set.Play();    
    }


    





}
