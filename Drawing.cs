using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera cam;
    public GameObject plane;
    public Material material;
    private LineRenderer curLine;
    private int positionCount = 2;
    private Vector3 prevPos = Vector3.zero;

    
    void Update()
    {
       DrawMouse();
    }
    void DrawMouse()
    {
        //Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.3f));
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,11f));
        if(Input.GetMouseButtonDown(0)){
            CreateLine(mousePos);
        }
        else if(Input.GetMouseButton(0)){
            connectLine(mousePos);
        }
    }
    void CreateLine(Vector3 mousePos)
    {
        positionCount = 2;
        GameObject line = new GameObject("Line");
        LineRenderer lineRend = line.AddComponent<LineRenderer>();

        line.transform.parent = cam.transform;
        line.transform.position = mousePos;

        lineRend.startWidth = 1f;
        lineRend.endWidth = 1f;
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = material;
        lineRend.SetPosition(0,mousePos);
        lineRend.SetPosition(1,mousePos);

        curLine = lineRend;
    }
    void connectLine(Vector3 mousePos)
    {
        if(prevPos !=null && Mathf.Abs(Vector3.Distance(prevPos,mousePos))>=0.001f){

            prevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount -1,mousePos);

        }
    }

   
   
}
