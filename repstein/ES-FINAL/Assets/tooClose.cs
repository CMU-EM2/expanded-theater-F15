using UnityEngine;
using System.Collections;

public class tooClose : MonoBehaviour
{
    public GameObject player;
    public float speed = 5.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position);
        print(player.transform.position);

        //change all this to test x anyd y and not think about z, try to get border collider?
        if (Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            print("actionStarting");

            transform.Translate((transform.position - player.transform.position) * speed * Time.deltaTime);

           // transform.position = 

        }


    }
}
