using System;

public class Point
{
    public double x, y, z;

    public Point()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

	public Point(double x, double y, double z)
	{
        this.x = x;
        this.y = y;
        this.z = z;
	}

    public double distanceTo(Point p)
    {
        return Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2) + Math.Pow(this.z - p.z, 2));
    }

    public Point add(Point p)
    {
        return new Point(this.x + p.x, this.y + p.y, this.z + p.z);
    }

    public Point divide(double n)
    {
        return new Point(this.x / n, this.y / n, this.z / n);
    }

    public Point subtract(Point p)
    {
        return new Point(this.x - p.x, this.y - p.y, this.z - p.z);
    }

    public Point multiply(double n):
    {
        return new Point(this.x * p.x, this.y * p.y, this.z * p.z);
    }
}
