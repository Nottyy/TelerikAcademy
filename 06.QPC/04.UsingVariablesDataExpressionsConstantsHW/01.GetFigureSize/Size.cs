using System;

public class Size
{
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; private set; }

    public double Height { get; private set; }

    public static Size CalculateSize(Size currentSize, double angleOfRotationInRadians)
    {
        double cosineAngleRotation = Math.Cos(angleOfRotationInRadians);
        double sineAngleRotation = Math.Sin(angleOfRotationInRadians);

        double absValueCosine = Math.Abs(cosineAngleRotation);
        double absValueSine = Math.Abs(sineAngleRotation);

        double width = (absValueCosine * currentSize.Width) + (absValueSine * currentSize.Height);
        double height = (absValueSine * currentSize.Width) + (absValueCosine * currentSize.Height);

        Size newSize = new Size(width, height);

        return newSize;
    }
}