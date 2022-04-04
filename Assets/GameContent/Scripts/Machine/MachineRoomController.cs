using System;
using UnityEngine;
using System.Linq;

public class MachineRoomController : MonoBehaviour
{
    public RunningMachine[] RunningMachines;
    private readonly System.Random _random = new System.Random(DateTime.Now.Second);

    private const int maxDamage = 1;

    private bool _firstDamage = true;

    public bool allEngineAreDamage;

    private readonly Replacement[] Replacements = 
    {
        Replacement.Pipe, 
        Replacement.Screw, 
        Replacement.Mutter, 
        Replacement.Oil
    };

    private void Start()
    {
        foreach (var runningMachine in this.RunningMachines)
        {
            runningMachine.coolDown = (float)this._random.NextDouble();
        }
    }

    void Update()
    {
        this.allEngineAreDamage = this.RunningMachines.All(a => a.isDamage);
        
        if (this.RunningMachines.Count(c => !c.isDamage && c.replacementState != Replacement.None) >= maxDamage) return;

        var r = this._random.Next(0, 100);
        if (r < 80) return;
        
        var index = this._random.Next(0, this.RunningMachines.Length);
        if (this.RunningMachines[index].replacementState != Replacement.None) return;
        
        var damageState = this._random.Next(0, this.Replacements.Length);
        this.RunningMachines[index].StartDamageReport(this.Replacements[damageState], this._firstDamage);
        this._firstDamage = false;
    }

    public int GetPoints()
    {
        return this.RunningMachines.Sum(s => s.pointsForRepair);
    }
}
