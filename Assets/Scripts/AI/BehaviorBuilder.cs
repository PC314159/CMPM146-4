using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviorBuilder
{
    public static BehaviorTree MakeTree(EnemyController agent)
    {
        BehaviorTree result = null;
        Blackboard bb = new Blackboard();
        bb.Set<AIWaypoint>("ClosestSafe", null);
        bb.Set<GameObject>("BestHealTarget", null);
        bb.Set<bool>("IsClosestToPlayer", false);
        bb.Set<bool>("IsGrouped", false);
        bb.Set<bool>("IsInPlayerRange", false);
        bb.Set<bool>("IsCharging", false);

        if (agent.monster == "warlock")
        {
            Sequence tooclose = new Sequence(new BehaviorTree[] {
                new IsInPlayerRange(),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            Sequence infront = new Sequence(new BehaviorTree[] {
                new IsClosestToPlayer(),
                new GoTowardsClosestSafe(2,1)
            });
            Sequence charge = new Sequence(new BehaviorTree[] {
                new Selector(new BehaviorTree[] {
                    new IsCharging(),
                    new IsGrouped(),
                }),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            result = new Sequence(new BehaviorTree[] {
                new UpdateCalculations(),
                new Selector(new BehaviorTree[] {
                    new HealBest(),
                    new PermaBuff(),
                    new Buff(),
                    new Attack(),
                    tooclose,
                    infront,
                    charge,
                    new GoTowardsClosestSafe(2,1)
                })
            });
        }
        else if (agent.monster == "zombie")
        {
            Sequence tooclose = new Sequence(new BehaviorTree[] {
                new IsInPlayerRange(),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            Sequence charge = new Sequence(new BehaviorTree[] {
                new Selector(new BehaviorTree[] {
                    new IsCharging(),
                    new IsGrouped(),
                }),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            result = new Sequence(new BehaviorTree[] {
                new UpdateCalculations(),
                new Selector(new BehaviorTree[] {
                    new Attack(),
                    tooclose,
                    charge,
                    new GoTowardsClosestSafe(2,1)
                })
            });
        }
        else
        {
            Sequence tooclose = new Sequence(new BehaviorTree[] {
                new IsInPlayerRange(),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            Sequence infront = new Sequence(new BehaviorTree[] {
                new IsClosestToPlayer(),
                new GoTowardsClosestSafe(2,1)
            });
            Sequence charge = new Sequence(new BehaviorTree[] {
                new Selector(new BehaviorTree[] {
                    new IsCharging(),
                    new IsGrouped(),
                }),
                new GoTowardsPlayer(agent.GetAction("attack").range,1)
            });
            result = new Sequence(new BehaviorTree[] {
                new UpdateCalculations(),
                new Selector(new BehaviorTree[] {
                    new Attack(),
                    tooclose,
                    infront,
                    charge,
                    new GoTowardsClosestSafe(2,1)
                })
            });
        }

        // do not change/remove: each node should be given a reference to the agent
        foreach (var n in result.AllNodes())
        {
            n.SetAgent(agent);
            n.SetBlackboard(bb);
        }
        return result;
    }
}
