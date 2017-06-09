using System;

public class Bug
{
    public Point p;
    public Point velocity;
    public int id;

    public static double CENTER_FACTOR = .01;
    public static double NEIGHBOR_RANGE = 1;
    public static double VELOCITY_MATCH_FACTOR = 2;

    public Bug(int id, Point p)
    {
        this.id = id;
        this.p = p;
        this.velocity = new Point();
    }

    public Point FlyTowardsCenter()
    {
        Point c = new Point();
        foreach (Bug b in SwarmController.swarm)
        {
            if (b.id != this.id)
            {
                c = c.add(b.p);
            }
        }
        c = c.divide(SwarmController.swarm.Count - 1);
        return new Point(CENTER_FACTOR * (c.x - p.x), CENTER_FACTOR * (c.y - p.y), CENTER_FACTOR * (c.z - p.z));
    }

    public Point KeepDistance()
    {
        Point c = new Point();
        foreach (Bug b in SwarmController.swarm) {
            if (b.id != this.id)
            {
                if (p.distanceTo(b.p) < NEIGHBOR_RANGE)
                {
                    c = c.subtract(b.p.subtract(p));
                }
            }
        }
        return c;

    }

    public Point MatchVelocity()
    {
        Point c = new Point();
        foreach (Bug b in SwarmController.swarm)
        {
            if (b.id != id)
            {
                c = c.add(b.velocity);
            }
        }
        c = c.divide(SwarmController.swarm.Count - 1);
        return c.subtract(velocity).divide(VELOCITY_MATCH_FACTOR);
    }
}
