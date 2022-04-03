using UnityEngine;

public class ReplacementItem: MonoBehaviour
{
    private SpriteRenderer _renderer;
    public Replacement Replacement;
    
    private void Awake()
    {
        this._renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void Show()
    {
        //Debug.Log("replacement item is enable");
        
        this._renderer.enabled = true;
    }

    public void Hide()
    {
        this._renderer.enabled = false;
    }
}