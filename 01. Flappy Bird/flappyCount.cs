using UnityEngine;

public class flappyCount : MonoBehaviour
{
   

    void OnDestroy() // 게임을 시작할 때 카운터가 사라지면 실행되는 함수
    {
        GameObject.Find("GameManager").GetComponent<FlappyGameManager>().GameStart();
    }

}
