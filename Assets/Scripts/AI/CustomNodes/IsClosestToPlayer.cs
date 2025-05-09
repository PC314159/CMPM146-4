public class IsClosestToPlayer : BehaviorTree
{
    public override Result Run()
    {
        this.bb.TryGet<bool>("IsClosestToPlayer", out var res);
        return res ? Result.SUCCESS : Result.FAILURE;
    }

    public override BehaviorTree Copy()
    {
        return new IsClosestToPlayer();
    }
}
