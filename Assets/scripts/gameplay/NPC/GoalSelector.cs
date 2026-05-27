using System.Collections.Generic;

public class GoalSelector
{
    class NoGoal : Goal
    {
        public override bool canUse()
        {
            return false;
        }
    }
    public WrappedGoal NO_GOAL = new WrappedGoal(int.MaxValue, new NoGoal());

    ISet<WrappedGoal> availableGoals = new HashSet<WrappedGoal>();

    public void addGoal(int prio, Goal goal)
    {
        this.availableGoals.Add(new WrappedGoal(prio, goal));
    }

    public void removeGoal(Goal toRemove)
    {
        foreach(WrappedGoal ag in availableGoals)
        {
            if (ag.getGoal() == toRemove)
            {
                if (ag.isRunning)
                {
                    ag.stop();
                }
                availableGoals.Remove(ag);
            }
        }
    }

    public void tickOnUpdate()
    {
        foreach(WrappedGoal goal in availableGoals)
        {
            if (!goal.canContinueToUse())
            {
                goal.stop();
            }
            if (goal.canUse())
            {
                goal.start();
            }
        }
        tickRunningGoals(true);
    }

    public void tickRunningGoals(bool forceTickAllRunningGoals)
    {
        foreach(WrappedGoal goal in availableGoals)
        {
            if(goal.isRunning && (forceTickAllRunningGoals || goal.requiresUpdate()))
            {
                goal.update();
            }
        }
    }

    public ISet<WrappedGoal> getAvailableGoals() { return availableGoals; }
}