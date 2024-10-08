using UnityEngine;

public class Tetris_Data : MonoBehaviour
{
    

    protected int[][,] Ori_Blocks = new int[][,] // 시작시 블럭 위치
    {
       new int[,] { { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 } } ,
       new int[,] { { 0, 3 }, { 1, 3 }, { 1, 4 }, { 1, 5 } } ,
       new int[,] { { 0, 5 }, { 1, 3 }, { 1, 4 }, { 1, 5 } } ,
       new int[,] { { 0, 4 }, { 1, 3 }, { 1, 4 }, { 1, 5 } } ,
       new int[,] { { 1, 3 }, { 1, 4 }, { 0, 4 }, { 0, 5 } } ,
       new int[,] { { 0, 3 }, { 0, 4 }, { 1, 4 }, { 1, 5 } } ,
       new int[,] { { 0, 3 }, { 0, 4 }, { 1, 3 }, { 1, 4 } }
    };


    protected int[][][,] Change_Blocks = new int[][][,] // 블럭 모양 바꾸는 위치
    {
        new int[][,]
        {
            new int[,] { { 1, -1 }, { 0, 0 }, { -1, 1 }, { -2, 2 } } ,
            new int[,] { { -1, 1 }, { 0, 0 }, { 1, -1 }, { 2, -2 } }
        } ,

        new int[][,]
        {
            new int[,] { { -2, 0 }, { -1, -1 }, { 0 , 0 }, { 1 , 1 } } , // 4번쨰 
            new int[,] { { 0, 2 }, { -1 , 1 }, { 0 , 0 }, { 1 , -1 } } ,  // 1번째
            new int[,] { { 2, 0 }, { 1, 1 }, { 0 , 0 }, { -1 , -1 } } , // 2번째
            new int[,] { { 0, -2 }, { 1, -1 }, { 0 , 0 }, { -1 , 1 } }  // 3번쨰 
        } , 

        new int[][,]
        {
            new int[,] { { -2 , 1 }, { 1, -1 }, { 0 , 0 }, { 1 , 2 } } ,
            new int[,] { { 0, -1 }, { 1, 1 }, { 0 , 0 }, { 1 , 0 } } ,
            new int[,] { { 1, 1 }, { -1, -1 }, { 0 , 0 }, { 0 , -2 } } ,
            new int[,] { { 1, -1 }, { -1, 1 }, { 0 , 0 }, { -2 , 0 } }
        } ,

        new int[][,]
        {
           new int[,] { { -1, 1 }, { -1, -1 }, { 0 , 0 }, { 1 , 1 } } ,
           new int[,] { { 1 , 1 }, { -1 , 1 }, { 0 , 0 }, { 1 , -1 } } ,
           new int[,] { { 1 , -1 }, { 1, 1 }, { 0 , 0 }, { -1 , -1 } } ,
           new int[,] { { -1, -1 }, { 1, -1 }, { 0 , 0 }, { -1 , 1 } }
        } ,


        new int[][,]
        {
           new int[,] { { 2 , 0 }, { 1, 1 }, { 0 , 0 }, { -1 , 1 } } ,
           new int[,] { { -2, 0 }, { -1 , -1 }, { 0 , 0 }, { 1 , -1 } } ,
        } ,

        new int[][,]
        {
           new int[,] { { 0 , -2 }, { -1, -1 }, { 0 , 0 }, { -1 , 1 } } ,
           new int[,] { { 0, 2 }, { 1 , 1 }, { 0 , 0 }, { 1 , -1 } } ,
        } ,

        new int[][,]
        {
           new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }
        }


     };

    protected int[,] NextOrgBlock(int mode) // 원본 블럭 다음꺼 세팅하는것 
    {
        return Ori_Blocks[mode - 1];
    }


    protected int[][,] BlockMode(int mode) // 블럭 변형값이들어가 있는 걸 반환하는 함수
    {
        return Change_Blocks[mode - 1];
    }



}
