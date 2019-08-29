using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public Vector3 hitpoint;
    public GameObject player;
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
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, hitpoint, step);
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
        }
    }
}
