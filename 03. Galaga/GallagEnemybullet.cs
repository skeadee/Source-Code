using System.Collections;
using UnityEngine;

public class GallagEnemybullet : MonoBehaviour
{

    public float speed = 2.5f; 

    void Start()
    {
        StartCoroutine(Move());
    }


    void Update()
    {
        if (GallagGameManager.GameMode == 4) StopAllCoroutines();
    }

    IEnumerator Move()
    {
        Vector3 player = (GameObject.FindGameObjectWithTag("Player").transform.position - gameObject.transform.position).normalized * 0.1f;

        while (true)
        {
            gameObject.transform.position += player;
            yield return new WaitForSeconds(0.01f * speed);
        }
    }



    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }


}
