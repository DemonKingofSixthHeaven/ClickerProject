using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KovaElle : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 mousestart;
    public Rigidbody2D rb;
    public bool roation = false;
    public bool kova = true;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mousestart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }
    void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (!roation)
        {
            if (mousestart.y > curScreenPoint.y)
            {
                rb.velocity = new Vector2(0,3);
            }
            if (mousestart.y < curScreenPoint.y)
            {
                rb.AddForce(new Vector2(0, -3));
            }
            if (mousestart.x > curScreenPoint.x)
            {
               rb.AddForce(new Vector2(3, 0));
            }
            if (mousestart.x < curScreenPoint.x)
            {
                rb.AddForce(new Vector2(-3, 0));
            }
        }
        else
        {
            if (mousestart.x < curScreenPoint.x)
            {
                rb.AddTorque(1);
                

            }
            if (mousestart.x > curScreenPoint.x)
            {
                rb.AddTorque(-1);
                
            }


        }


    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (kova)
        {
            if (Input.GetMouseButtonDown(1))
            {
                roation = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            }
            if (Input.GetMouseButtonUp(1))
            {

                roation = false;
                rb.constraints = RigidbodyConstraints2D.None;

            }
        }
    }
    
}
