using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    GallagGameManager gallag;

    Vector3 move = new Vector3();
    public float AttackDelay = 0.5f;

    public GameObject bullet;
    [Range(1, 5)] public int speed;

    float Delay;
    Animator ani;
    bool check = true;

    void Awake()
    {
        gallag = GameObject.Find("GameManager").GetComponent<GallagGameManager>();
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        check = true;
        Delay = AttackDelay;
    }


    void Update()
    {
        if (GallagGameManager.GameMode == 4 || GallagGameManager.GameMode == 0 || GallagGameManager.GameMode == 2) return;

        Delay -= Time.deltaTime;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        move = new Vector3(h, v, 0);

        if (Input.GetKeyDown("z") && Delay < 0)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += 1f;
            Instantiate(bullet, pos, Quaternion.identity);
            Delay = AttackDelay;
        }

        move *= 0.1f;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += move;
        move = Vector3.zero;
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.name == "BackGround") return;

        if(gallag.life >= 0 && check)
        {
           if(gallag.life > 0 && col.gameObject.name != "Bullet(Clone)") Destroy(gallag.life_img[--gallag.life]);

           if(gallag.life != 0 && col.gameObject.name != "Bullet(Clone)")
           {
                ani.SetTrigger("crash");
                StartCoroutine(crash());
           }        
        }

        if (gallag.life <= 0) GallagGameManager.GameMode = 4; 

    }

    IEnumerator crash()
    {
        check = false;
        yield return new WaitForSeconds(4f);
        check = true;
    }
    

}
