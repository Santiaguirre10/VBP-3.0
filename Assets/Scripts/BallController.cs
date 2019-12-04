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
    float x;
    float y;
    float count = 0.0f; 

    // Start is called before the first frame update  -0.67
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
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
            Vector3 pmax = transform.position + (new Vector3(x, y, 0f) - transform.position) / 2 + Vector3.up * 5.0f;
            //float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), step);
            if (count < 1.0f)
            {
                count += 0.1f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(transform.position, pmax, count);
                Vector3 m2 = Vector3.Lerp(pmax, new Vector3(x, y, 0f), count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }
        }
        else if (tag == "Defensa")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, setpoint.position, step);
        }
        else if (tag == "Armado")
        {
            Vector3 pmax = transform.position + (hitpoint - transform.position) / 2 + Vector3.up * 5.0f;
            // float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, hitpoint, step);
            if (count < 1.0f)
            {
                count += 0.5f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(transform.position, pmax, count);
                Vector3 m2 = Vector3.Lerp(pmax, hitpoint, count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }
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
            x = Random.Range(-8.75f, -0.27f);
            y = Random.Range(-2.95f, 0.25f);
            gameObject.tag = "Rebote";
        }
    }
}
