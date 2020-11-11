using System;
using System.Collections.Generic;

using System.Drawing;


namespace itv
{
    //структура которая содержит вершины треугольника
    class Triangle
    {
        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            
        }
        //площадь
        public double Area
        {
            get 
            {
                if (Area <= 0)
                {
                    return CalculateArea();
                    Area = CalculateArea();
                }
                else
                    return Area;
            }
        }
        // уровень вложенности треугольника
        public int NestedLevel;

        public Point pointA = new Point();
        public Point pointB = new Point();
        public Point pointC = new Point();

        // считает площадь треугольника 
        public double CalculateArea()
        {
            return 0.5 * Math.Abs((pointB.X - pointA.X) * (pointC.Y - pointA.Y)
                - (pointC.X - pointA.X) * (pointB.Y - pointA.Y));
        }

        public List<Line> ReturnLines()
        {
            return new List<Line> { new Line {pointOne = pointA,pointTwo = pointB }
            , new Line {pointOne = pointA,pointTwo = pointC } 
            , new Line {pointOne = pointB,pointTwo = pointC } };
        }
    }

    //структура отрезка имеено они будут проверяться на пересечение
    class Line
    {
        public Point pointOne;
        public Point pointTwo;
    }
}
