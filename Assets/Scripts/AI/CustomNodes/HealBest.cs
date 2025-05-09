using UnityEngine;

public class HealBest : BehaviorTree
{
    public override Result Run()
    {
        this.bb.TryGet<GameObject>("BestHealTarget", out var target);
        if (target == null) return Result.FAILURE;
        EnemyAction act = agent.GetAction("heal");
        if (act == null) return Result.FAILURE;

        bool success = act.Do(target.transform);
        return (success ? Result.SUCCESS : Result.FAILURE);
        
    }

    public HealBest() : base()
    {
        
    }

    public override BehaviorTree Copy()
    {
        return new HealBest();
    }
}
