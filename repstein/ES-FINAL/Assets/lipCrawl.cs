using UnityEngine;
using System.Collections;

public class lipCrawl : MonoBehaviour {
    public float speed = 5.0f;
    public GameObject player;
    Material material;
    public float originalX;
    public float originalY;
    public float originalZ;

    // Use this for initialization
    void Start()
    {
        material = this.gameObject.GetComponent<Renderer>().material;
        originalX = transform.position.x;
        originalY = transform.position.y;
        originalZ = transform.position.z;
    }


    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < 4) { 
            //running in some direction when you get close
            transform.position = new Vector3((speed * Time.deltaTime) + transform.position.x, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
        }
        else if(originalX != transform.position.x || originalY != transform.position.y || originalZ != transform.position.z)
        {
            //return a il slower when yu move away
            //if z y or z are not equal to starting values have each one increase
            //transform.position = new Vector3((speed * Time.deltaTime) + transform.position.x, transform.position.y, transform.position.z);

        }
    }
}
