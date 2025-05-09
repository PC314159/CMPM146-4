using UnityEngine;
using System.Collections.Generic;

public class BehaviorTree 
{
    public enum Result { SUCCESS, FAILURE, IN_PROGRESS };

    public EnemyController agent;

    public Blackboard bb;

    public virtual Result Run()
    {
        return Result.SUCCESS;
    }

    public BehaviorTree()
    {

    }

    public void SetAgent(EnemyController agent)
    {
        this.agent = agent;
    }

    public void SetBlackboard(Blackboard bb)
    {
        this.bb = bb;
    }

    public virtual IEnumerable<BehaviorTree> AllNodes()
    {
        yield return this;
    }

    public virtual BehaviorTree Copy()
    {
        return null;
    }
}
