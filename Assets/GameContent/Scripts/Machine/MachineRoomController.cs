using System;
using UnityEngine;
using System.Linq;

public class MachineRoomController : MonoBehaviour
{
    public RunningMachine[] RunningMachines;
    private System.Random _random = new System.Random(DateTime.Now.Second);

    private int maxDamage = 1;

    private readonly Replacement[] Replacements = 
    {
        Replacement.Pipe, 
        Replacement.Screw, 
        Replacement.Mutter, 
        Replacement.Oil
    };
    
    void Update()
    {
        if (this.RunningMachines.Count(c => c.replacementState != Replacement.None) >= this.maxDamage) return;

        var r = this._random.Next(0, 10);
        //Debug.Log($"one can will be damage: {r}");

        if (r < 7) return;
        
        //Debug.Log("one can will be damage will expected");

        var index = this._random.Next(0, this.RunningMachines.Length);
        if (this.RunningMachines[index].replacementState != Replacement.None) return;
        
        //Debug.Log($"one going to damage: {index}");
        
        var damageState = this._random.Next(0, this.Replacements.Length);
        this.RunningMachines[index].StartDamageReport(this.Replacements[damageState]);
    }
}
