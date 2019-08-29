using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyController : MonoBehaviour
{
    GameObject escapepoint;
    public float speed;
    PuppyManager puppymanager;
    GameManager gamemanager;
    public int life;
    public Vector3 initpos;
    public bool kicked;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.tag = "EnZona";
        escapepoint = GameObject.Find("EscapePoint");
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
        gamemanager = GameObject.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        life = 3;
        puppymanager.puppys.Add(gameObject);
        puppymanager.distances.Add(transform.position.x);
        initpos = transform.position;
        kicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Valla")
        {
            gameObject.tag = "Escapando";
        }
        if (collision.name == "EscapePoint")
        {
            gamemanager.gameover = true;
        }
        if (collision.name == "Player")
        {
            gameObject.tag = "Pateado";
        }
        if (collision.tag == "Spamer")
        {
            gameObject.tag = "EnZona";
        }
    }
    void Move()
    {
        if (tag == "EnZona")
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (tag == "Escapando")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, escapepoint.transform.position, step);
        }
        else if (tag == "Pateado")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initpos, step);
        }
    }
}
