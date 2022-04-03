using UnityEngine;

public class RepairPlace : CollectibleObject
{
    public Replacement NeedReplacement = Replacement.None;
    
    public bool MustRepair { get; set; }
    public bool HasRepaired { get; set; }
    
    
    
    public bool OnRepair(Replacement replacement)
    {
        Debug.Log($"Try repair with {replacement}. Need for repair: {this.NeedReplacement}");
        
        if(this.NeedReplacement == Replacement.None) return false;
        
        if(replacement !=  this.NeedReplacement) return false;
        
        Debug.Log($"Repair with {this.NeedReplacement}");
        this.HasRepaired = true;
        return true;
    }
    
  
}