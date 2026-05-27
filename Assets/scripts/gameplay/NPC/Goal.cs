public abstract class Goal
{
    public abstract bool canUse();

    public bool canInterruptThis;

    public virtual bool canContinueToUse() { return canUse(); }

    public virtual bool isInterruptable() { return canInterruptThis; }

    public virtual bool requiresUpdate() { return false; }

    public virtual void start()
    {

    }

    public virtual void stop()
    {

    }

    public virtual void update()
    {

    }
}
