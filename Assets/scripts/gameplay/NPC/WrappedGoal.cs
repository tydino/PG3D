public class WrappedGoal : Goal
{
    public Goal goal;
    public int priority;
    public bool isRunning;

    public WrappedGoal(int priority, Goal goal)
    {
        this.priority = priority;
        this.goal = goal;
    }

    public bool canBeReplacedBy(WrappedGoal goal)
    {
        return this.isInterruptable() && goal.getPriority() < this.getPriority();
    }

    public override bool canUse() { return this.goal.canUse(); }

    public override bool canContinueToUse() { return this.goal.canContinueToUse(); }

    public override bool isInterruptable() { return this.goal.isInterruptable(); }

    public override void start()
    {
        if (!this.isRunning)
        {
            this.isRunning = true;
            this.goal.start();
        }
    }

    public override void stop()
    {
        if (this.isRunning)
        {
            this.isRunning = false;
            this.goal.stop();
        }
    }

    public override void update()
    {
        this.goal.update();
    }

    public override bool requiresUpdate() { return this.goal.requiresUpdate(); }

    public int getPriority() { return this.priority; }

    public Goal getGoal() { return this.goal; }

    public bool equals(object o)
    {
        if (this == o)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int hashCode() { return this.goal.GetHashCode(); }
}
