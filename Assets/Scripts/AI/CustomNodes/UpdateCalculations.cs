using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateCalculations : BehaviorTree
{
    public override Result Run()
    {
        EnemyController agent = this.agent;
        Blackboard bb = this.bb;
        AIWaypoint wp = AIWaypointManager.Instance.GetClosestByType(agent.transform.position, AIWaypoint.Type.SAFE);
        List<GameObject> enemiesInHealRange = GameManager.Instance.GetEnemiesInRange(this.agent.transform.position, 4.5f);
        GameObject bh = enemiesInHealRange.Aggregate((a,b) => a.GetComponent<EnemyController>().hp.hp < b.GetComponent<EnemyController>().hp.hp ? a : b);
        Vector3 plrpos = GameManager.Instance.player.transform.position;
        List<GameObject> enemies = GameManager.Instance.GetEnemiesInRange(this.agent.transform.position, 100);
        bool ictp = enemies.All(e =>(e.transform.position - plrpos).magnitude + 1 >= (agent.transform.position - plrpos).magnitude);
        bool grouped = GameManager.Instance.GetEnemiesInRange(this.agent.transform.position, 6).Count >= 5;
        bool iipr = (agent.transform.position - plrpos).magnitude < 10;
        bb.Set<AIWaypoint>("ClosestSafe", wp);
        bb.Set<GameObject>("BestHealTarget", bh);
        bb.Set<bool>("IsClosestToPlayer", ictp);
        bb.Set<bool>("IsGrouped", grouped);
        bb.Set<bool>("IsInPlayerRange", iipr);
        if (grouped){
            bb.Set<bool>("IsCharging", true);
        }
        return Result.SUCCESS;
    }

    public override BehaviorTree Copy()
    {
        return new UpdateCalculations();
    }
}
