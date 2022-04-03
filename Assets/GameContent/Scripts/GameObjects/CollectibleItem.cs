using UnityEngine;

internal class CollectibleItem : CollectibleObject
{
    public Replacement SetupReplacement;
    
    

    public Replacement OnCollect()
    {
        Debug.Log($"Collect replacement: {this.SetupReplacement}");
        return this.SetupReplacement;
    }
}