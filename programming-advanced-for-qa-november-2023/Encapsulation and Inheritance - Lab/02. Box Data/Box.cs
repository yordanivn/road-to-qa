using System;
using System.Text;

namespace BoxData;

public class Box
{
    private double _length;
    private double _width;
    private double _height;

    public double Length
    {
        get
        { return _length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            _length = value; 
        }
    }

    public double Width
    {
        get { return _width; }
        private set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            _width = value; 
        }
    }

    public double Height
    {
        get { return _height; }
        private set 
        { 
            if(value<=0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            _height = value; 
        }
    }
    public Box(double length,double width,double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea()
    {
        return 2 * this._length * this._width + 2 * this._length * this._height + 2 * this._width * this._height;
    }

    public double Volume()
    {
        return this._length * this._width * this._height;
    }

    public override string ToString()
    {
        return $"Surface Area - {this.SurfaceArea():f2}{Environment.NewLine}Volume - {this.Volume():f2}";
    }
}




