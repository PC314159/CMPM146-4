public class IsInPlayerRange : BehaviorTree
{
    public override Result Run()
    {
        this.bb.TryGet<bool>("IsInPlayerRange", out var res);
        return res ? Result.SUCCESS : Result.FAILURE;
    }

    public override BehaviorTree Copy()
    {
        return new IsInPlayerRange();
    }
}
