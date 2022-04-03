using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameObject statusBar;
    
    public void SetValue(float status)
    {
        var scale = this.statusBar.transform.localScale;

        scale = new Vector3(status, 1, 1);
        
        this.statusBar.transform.localScale = scale;
    }
    
    private SpriteRenderer _renderer;
    private SpriteRenderer _rendererStatusBar;
    private void Awake()
    {
        this._renderer = this.gameObject.GetComponent<SpriteRenderer>();
        this._rendererStatusBar = this.statusBar.gameObject.GetComponent<SpriteRenderer>();
    }
    
    public void Show()
    {
        //Debug.Log("replacement item is enable");
        
        this._renderer.enabled = true;
        this._rendererStatusBar.enabled = true;
    }

    public void Hide()
    {
        this._renderer.enabled = false;
        this._rendererStatusBar.enabled = false;
    }
}
