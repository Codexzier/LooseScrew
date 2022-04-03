using System;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    public Vector3 change = new Vector3();
    public float speed = 1f;
    public float speedByScreenSize { get; set; } = 1f;
    private static readonly float pixelFrac = 1f / 16f;
    protected Animator anim;
    private void Update()
    {
        if (Time.timeScale < 1f)
        {
            return;
        }
        
        if ( Input.GetKey(KeyCode.D))
        {
            this.change.x = 1;
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            this.change.x = -1;
        }
        else if (Input.GetKey(KeyCode.W)) 
        {
            this.change.y = 1;
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            this.change.y = -1;
        }
        else if (Input.GetKeyUp(KeyCode.E)) 
        {
            // Interact
        }
    }


    //private Vector3 oldPosition;
    private void LateUpdate()
    {
        this.anim.SetFloat("change_x", this.change.x);
        this.anim.SetFloat("change_y", this.change.y);
        
        if(this.change.y <= -1f) this.anim.SetFloat("lookAt", 0f);
        else if(this.change.x <= -1f) this.anim.SetFloat("lookAt", 1f);
        else if(this.change.y >= 1f) this.anim.SetFloat("lookAt", 2f);
        else if(this.change.x >= 1f) this.anim.SetFloat("lookAt", 3f);
        
        
        var step = this.roundToPixelGrid(Time.deltaTime);
        var oldPosition = this.transform.position;
        this.transform.position += this.change * step * this.speedByScreenSize * this.speed;
        if (this.isColliding())
        {
            //Debug.Log($"collide: {DateTime.Now}, Count: {this._countColliders}, Change: {this.change}, old:{oldPosition}, new: {this.transform.position}");
            this.transform.position = oldPosition;
        }
        
        this.change = Vector3.zero;
    }

    private void Awake()
    {
        this._boxCollider2D = this.GetComponent<BoxCollider2D>();
        this._collider2Ds = new Collider2D[10];
        this._obstacleFilter = new ContactFilter2D();
        this.anim = this.GetComponent<Animator>();
    }

    private BoxCollider2D _boxCollider2D;
    private Collider2D[] _collider2Ds;
    private ContactFilter2D _obstacleFilter;
    private int _countColliders;
    
    private bool isColliding()
    {
        this._countColliders = this._boxCollider2D.OverlapCollider(this._obstacleFilter, this._collider2Ds);
        return this._countColliders > 0;
    }

    private float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}