using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float h;
    float v;
    bool jumping;
    bool attacking;
    bool defending;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Atacando";
    }

    // Update is called once per frame
    void Update()
    {
        h = CrossPlatformInputManager.GetAxis("Horizontal");
        v = CrossPlatformInputManager.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        Move();
        //LimitedArea();
    }
    void LimitedArea()
    {
        if (transform.position.x <= -8.91f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-8.85f, transform.position.y, 0), step);
        } 
        else if (transform.position.x >= -0.47f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.5f, transform.position.y, 0), step);
        }
        else if (transform.position.y <= -3.03f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.95f, 0), step);
        }
        else if (transform.position.y >= 0.69f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0.6f, 0), step);
        }
    }
    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime * v);
        transform.Translate(Vector3.right * speed * Time.deltaTime * h);
    }
    public void Button()
    {

    }
}
