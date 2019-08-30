using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    Vector3 hitpoint;
    public GameObject player;
    public PuppyManager puppysmanager;
    public Transform rebound;
    public Transform setpoint;
    public float x;
    public float y;

    // Start is called before the first frame update  -0.67
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (tag == "Ataque")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, puppysmanager.objball, step);
        }
        else if (tag == "Golpe")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, rebound.position, step);
        }
        else if (tag == "Rebote")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), step);
        }
        else if (tag == "Defensa")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, setpoint.position, step);
        }
        else if (tag == "Armado")
        {
             float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, hitpoint, step);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SetPoint")
        {
            if (player.transform.position.x <= -3.67f)
            {
                hitpoint = new Vector3(player.transform.position.x + 3f, player.transform.position.y + 2.5f, 0);
            }
            if (player.transform.position.x > -3.67f)
            {
                hitpoint = new Vector3(-0.67f, player.transform.position.y + 2.5f, 0);
            }
            gameObject.tag = "Armado";
        }
        if (collision.name == "Player")
        {
            if (collision.tag == "Atacando")
            {
                gameObject.tag = "Ataque";
                collision.tag = "Defendiendo";
            }
            else if (collision.tag == "Defendiendo")
            {
                gameObject.tag = "Defensa";
                collision.tag = "Atacando";
            }
        }
        /*if (collision.tag == "EnZona")
        {
            Debug.Log("funcoina");
            gameObject.tag = "Golpe";
        }*/
        if (collision.name == "Rebound")
        {
            x = Random.Range(-8.85f, -0.5f);
            y = Random.Range(0.6f, 2.95f);
            gameObject.tag = "Rebote";
        }
    }
}
