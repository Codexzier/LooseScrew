using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic1 : MonoBehaviour
{
    private void FixedUpdate()
    {
        var step = roundToPixelGrid(Time.deltaTime);
        
        Vector3 change = new Vector3();

        if (Input.GetKey(KeyCode.D))
        {
            change.x = step;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            change.x = -step;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            change.y = step;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            change.y = -step;
        }

        var oldPos = transform.position;
        transform.position += change; // * Time.deltaTime;
        if (isColliding()) transform.position = oldPos;
    }

    private bool isColliding()
    {
        BoxCollider2D boxCollider2D = this.GetComponent<BoxCollider2D>();
        var collideres = new Collider2D[10];
        return boxCollider2D.OverlapCollider(new ContactFilter2D(), collideres) > 0;
    }

    private static readonly float pixelFrac = 1f / 16f;
    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}
