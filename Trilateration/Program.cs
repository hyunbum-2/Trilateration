using System;

public class Trilateration
{
	public static Point2D getTrilateration(Point2D position1, Point2D position2, Point2D position3)


		double x1 = position1.X;
	double y1 = position1.Y;
	double x2 = position2.X;
	double y2 = position2.Y;
	double x3 = position3.X;
	double y3 = position3.Y;

	double r1 = position1.Distance;
	double r2 = position2.Distance;
	double r3 = position3.Distance;

	double S = (Math.Pow(x3, 2.0) - Math.Pow(x2, 2.0) + Math.Pow(y3, 2.0) - Math.Pow(y2, 2.0) + Math.Pow(r2, 2.0) - Math.Pow(r3, 2.0)) / 2.0;
	double T = (Math.Pow(x1, 2.0) - Math.Pow(x2, 2.0) + Math.Pow(y1, 2.0) - Math.Pow(y2, 2.0) + Math.Pow(r2, 2.0) - Math.Pow(r1, 2.0)) / 2.0;

	double y = ((T * (x2 - x3)) - (S * (x2 - x1))) / (((y1 - y2) * (x2 - x3)) - ((y3 - y2) * (x2 - x1)));
	double x = ((y * (y1 - y2)) - T) / (x2 - x1);

	Point2D userLocation = new Point2D(x, y, 0);
		return userLocation;

}

public class Point2D
{
	private double x;
	private double y;
	private double distance;

	public Point2D(double x, double y, double distance)
	{
		this.x = x;
		this.y = y;
		this.distance = distance;
	}
}

public void getUserPosition()
{
	Point2D position1 = new Point2D(0, 0, Math.sprt(50));
	Point2D position2 = new Point2D(10, 0, Math.sprt(50));
	Point2D position3 = new Point2D(5, 10, 5);

	Point2D userPosition = Trilateration.getTrilateration(position1, position2, position3);
	assertThat(userPosition.getX(), is (5, 0));
	assertThat(userPosition.getY(), is (5, 0));
}
