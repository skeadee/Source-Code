using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // 이 스크립트 생성 시 Rigidbody2D 컴포넌트를 같이 생성

public class Bird : MonoBehaviour
{
    public float upForce = 200f; // 클릭 시 올라가는 높이
    public bool crash; // 플레이어가 충돌 했는지를 감지하는 변수

    Rigidbody2D _rb2d;
    PolygonCollider2D pol;
    Animator ani;
    AudioSource Audio;
    bool GameOver;
    Vector2 Velocity;

    FlappyGameManager GameManager;

    private void Awake()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<FlappyGameManager>();
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        _rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        pol = GetComponent<PolygonCollider2D>();

        crash = false;
    }

    public void crash_off() 
    {
        if (GameOver) return;

        crash = false;
    }


    public void Die() 
    {
        GameOver = true;
        pol.isTrigger = false;
        ani.SetBool("Die", true);
    }


   
    private void Jump() 
    {
        _rb2d.velocity = Vector2.zero;
        _rb2d.AddForce(new Vector2(0, upForce));
        ani.SetTrigger("Nor");
    }


    private void Crash_Column()
    {
        if (crash) return;

        ani.SetTrigger("Crash");
        GameManager.Hit(1);
        crash = true;
        Audio.Play();

        Invoke("crash_off", 1.5f);
    }

    private void Crash_Ground()
    {
        GameManager.Hit(99);
    }

    public void GameStop()
    {
        Velocity = _rb2d.velocity;
        _rb2d.bodyType = RigidbodyType2D.Static;
        ani.enabled = false;
    }


    public void GameStart()
    {
        _rb2d.bodyType = RigidbodyType2D.Dynamic;
        _rb2d.velocity = Velocity;
        ani.enabled = true;
    }
    


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameOver) Jump();
    }


    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Column") Crash_Column();
        if (col.gameObject.name == "Goal" && !crash) GameManager.ScoreAdd(100);
    }


    void OnCollisionEnter2D() 
    {
        Crash_Ground();
    }

}
