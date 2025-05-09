public class IsCharging: BehaviorTree
{
    public override Result Run()
    {
        this.bb.TryGet<bool>("IsCharging", out var res);
        return res ? Result.SUCCESS : Result.FAILURE;
    }

    public override BehaviorTree Copy()
    {
        return new IsCharging();
    }
}
