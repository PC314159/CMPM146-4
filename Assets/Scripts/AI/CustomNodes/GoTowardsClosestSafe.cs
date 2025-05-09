using UnityEngine;

public class GoTowardsClosestSafe : BehaviorTree
{
    Transform target;
    float arrived_distance;
    float distance;
    bool in_progress;
    Vector3 start_point;

    public override Result Run()
    {
        
        // self added
        this.bb.TryGet<AIWaypoint>("ClosestSafe", out var res);
        if (res == null) {
            return Result.FAILURE;
        }
        target = res.transform;
        // ----

        if (!in_progress)
        {
            in_progress = true;
            start_point = agent.transform.position;
        }
        Vector3 direction = target.position - agent.transform.position;
        // if ((direction.magnitude < arrived_distance) || (agent.transform.position - start_point).magnitude >= distance)
        // {
        //     agent.GetComponent<Unit>().movement = new Vector2(0, 0);
        //     in_progress = false;
        //     return Result.SUCCESS;
        // }
        // else
        {
            agent.GetComponent<Unit>().movement = direction.normalized;
            // return Result.IN_PROGRESS;  
            in_progress = false;
            return Result.SUCCESS;
        }
    }

    public GoTowardsClosestSafe(float distance, float arrived_distance) : base()
    {
        this.target = null;
        this.arrived_distance = arrived_distance;
        this.distance = distance;
        this.in_progress = false;
    }

    public override BehaviorTree Copy()
    {
        return new GoTowardsClosestSafe(distance, arrived_distance);
    }
}

