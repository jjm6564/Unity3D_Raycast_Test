using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    RaycastHit hit;
    public Camera cam;
    float maxDistance = 15f;
    public GameObject parent;
    public GameObject prefab;
    public LayerMask layerMask;
    void Start()
    {   
        //cam.ScreenPointToRay;
        
    }

    // Update is called once per frame
    void Update()
    {
       casting();
    }
    void casting(){
        
        if(Input.GetMouseButton(1)){
            Debug.DrawRay(transform.position, transform.forward*maxDistance,Color.red ,0.3f);
             if(Physics.Raycast(transform.position,transform.forward, out hit,maxDistance,layerMask)==true){
                 
                //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                GameObject dot = Instantiate(prefab,hit.point,parent.transform.rotation);
                //Instantiate(prefab,parent);
                dot.transform.parent = parent.transform;
                dot.transform.position = dot.transform.position + new Vector3(0,0,-0.001f);
                Debug.Log(hit.point);
            }    
        }

        if(Input.GetKey(KeyCode.RightArrow)){
               transform.position = new Vector3(transform.position.x +0.1f,transform.position.y,transform.position.z);
                //parent.SetActive(false);
            }
        if(Input.GetKey(KeyCode.LeftArrow)){
                //parent.SetActive(true);
                transform.position = new Vector3(transform.position.x -0.1f,transform.position.y,transform.position.z);
            }
    }
}
