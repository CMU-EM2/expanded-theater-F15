using UnityEngine;
using System.Collections;

public class changeVariable : MonoBehaviour
{
    public GameObject player;
    Material material;
    //private float slowDissolve;


    // Use this for initialization
    void Start()
    {
        material = this.gameObject.GetComponent <Renderer> ().material;
        //slowDissolve = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 4)
        {
            //print("Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup))");
            material.SetFloat("_SliceAmount", Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup)));
      
        }
        else
        {
            material.SetFloat("_SliceAmount", 0);
        }
        //material.SetFloat("_SliceAmount", Input.mousePosition.x/Screen.width);
    }
}
