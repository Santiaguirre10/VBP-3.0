using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyController : MonoBehaviour
{
    GameObject escapepoint;
    public float speed;
    PuppyManager puppymanager;
    GameManager gamemanager;
    public int vida;
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
        gameObject.tag = "EnZona";
        puppymanager.puppys.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "EnZona")
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (tag == "Escapando")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, escapepoint.transform.position, step );
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Valla")
        {
            gameObject.tag = "Escapando";
        }
        if (collision.name == "EscapePoint")
        {
           gamemanager.gameover = true;
        }
    }
}
