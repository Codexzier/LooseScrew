using System;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    public Vector3 change;
    public float speed = 1f;
    public float speedByScreenSize { get; set; } = 1f;
    private static readonly float pixelFrac = 1f / 16f;
    private Animator anim;

    public ReplacementItem[] ReplacementItems;
    public Replacement carriesSparePart = Replacement.None;

    private ContactFilter2D _triggerContactFilter2D; 
    
    private void Update()
    {
        var found = this._boxCollider2D.OverlapCollider(this._triggerContactFilter2D, this._collider2Ds);
        for (var i = 0; i < found; i++)
        {
            Debug.Log($"Sammel objekt: {i}");
            
            var foundCollider = this._collider2Ds[i];
            if (!foundCollider.isTrigger)
            {
                continue;
            }

            Debug.Log("Sammel objekt gefunden");
                
            foreach (var collectible in foundCollider.GetComponents<CollectibleObject>())
            {
                switch (collectible)
                {
                    case CollectibleItem collectibleItem:
                        this.carriesSparePart = collectibleItem.OnCollect();
                        this.ShowReplacementIcon();
                        break;
                    case RepairPlace repairPlace:
                    {
                        if (repairPlace.OnRepair(this.carriesSparePart))
                        {
                            this.carriesSparePart = Replacement.None;
                            this.HideReplacementIcons();
                        }
                        
                        break;
                    }
                }
            }
        }

    }

    private void HideReplacementIcons()
    {
        foreach (var replacementItem in this.ReplacementItems)
        {
            replacementItem.Hide();
        }
    }

    private void ShowReplacementIcon()
    {
        foreach (var replacementItem in this.ReplacementItems)
        {
            if (replacementItem.Replacement == this.carriesSparePart)
            {
                replacementItem.Show();
            }
            else
            {
                replacementItem.Hide();
            }
        }
    }
    
    private void LateUpdate()
    {
        if(this.change == null)
            return;
        
        this.anim.SetFloat("change_x", this.change.x);
        this.anim.SetFloat("change_y", this.change.y);
        
        if(this.change.y <= -1f) this.anim.SetFloat("lookAt", 0f);
        else if(this.change.x <= -1f) this.anim.SetFloat("lookAt", 1f);
        else if(this.change.y >= 1f) this.anim.SetFloat("lookAt", 2f);
        else if(this.change.x >= 1f) this.anim.SetFloat("lookAt", 3f);
        
        
        var step = roundToPixelGrid(Time.deltaTime);
        var oldPosition = this.transform.position;
        this.transform.position += this.change * step * this.speed; // * this.speedByScreenSize;
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

        foreach (var replacementItem in this.ReplacementItems)
        {
            replacementItem.Hide();
        }

        this._triggerContactFilter2D = new ContactFilter2D();
        this._triggerContactFilter2D.useTriggers = true;
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

    private static float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}