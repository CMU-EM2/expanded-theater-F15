using UnityEngine;
using System.Collections;

public class moveWithKeys : MonoBehaviour {
    // Update is called once per frame
    public float speed = 5.0f;

    void Update()
    {
        //print(transform.position);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3((speed * Time.deltaTime)+ transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x-(speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
        }
    }
}
