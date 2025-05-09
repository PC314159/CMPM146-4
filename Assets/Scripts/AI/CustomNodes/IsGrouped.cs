public class IsGrouped : BehaviorTree
{
    public override Result Run()
    {
        this.bb.TryGet<bool>("IsGrouped", out var res);
        return res ? Result.SUCCESS : Result.FAILURE;
    }

    public override BehaviorTree Copy()
    {
        return new IsGrouped();
    }
}
