using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyManager : MonoBehaviour
{
    public GameObject puppy1;
    public GameObject[] puppyspamer;
    public List<GameObject> puppys;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PuppyCreator", 0, 5);
        for (int i = 0; i < puppyspamer.Length; i++)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PuppyCreator()
    {
        int rdm = Random.RandomRange(0 , 3);
        Instantiate(puppy1, puppyspamer[rdm].transform.position , Quaternion.identity);
    }
}
