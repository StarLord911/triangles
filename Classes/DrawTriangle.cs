using itv.Algo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace itv
{
    class DrawTriangle
    {

        private PictureBox Holst;
        private LoadCordinates loadCordinates = new LoadCordinates();
        private List<Triangle> triangles = null;
        private List<Line> Lines = new List<Line>();
        public int ColorCount = 0;

        public DrawTriangle(PictureBox Holst)
        {

            this.Holst = Holst;
            triangles = loadCordinates.LoadCordinate();
            AddLines();
            triangles = SortTriangel();
            NestedTriangle();
        }
        // проверка на пересичение и рисование
        public void Draw()
        {
            Bitmap bitmap = new Bitmap(Holst.Width, Holst.Height);
            if (triangles != null)
            {
                
                for (int i = 0; i < Lines.Count - 1; i++)
                {
                    for (int y = i+1; y < Lines.Count - 1; y++)
                    {
                        if (Intersected(Lines[i].pointOne, Lines[i].pointTwo, Lines[y].pointOne, Lines[y].pointTwo))
                        {
                            MessageBox.Show("ERROR");
                            return;
                        }


                    }
                }

                FiilTriangle(bitmap);
                Holst.Image = bitmap;
          
            }
        }

       
        // метод добовляет все отрезки из которых строятся тругольники для проверки их на пересечение
        private void AddLines()
        {
                foreach (var item in triangles)
                {
                    Lines.AddRange(item.ReturnLines());
                }
        }

        // проверяет на пересичение
        private bool Intersected(Point a, Point b, Point c, Point d)
        {
            //проверка двух отрезков на пересечение 


            var v1 = (d.X - c.X) * (a.Y - c.Y) - (d.Y - c.Y) * (a.X - c.X);
            var v2 = (d.X - c.X) * (b.Y - c.Y) - (d.Y - c.Y) * (b.X - c.X);
            var v3 = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            var v4 = (b.X - a.X) * (d.Y - a.Y) - (b.Y - a.Y) * (d.X - a.X);
            bool intersect = (v1 * v2 < 0) && (v3 * v4 < 0);

            return intersect;
        }
        //сортирует треугольники по площади (для удобства)
        public List<Triangle> SortTriangel()
        {
            var sortedTriangles = from t in triangles
                                  orderby t.Area descending
                                  select t;
            return sortedTriangles.ToList<Triangle>();
        }
        // метод закрашивает треугольники с учетом их вложенности
        private void FiilTriangle(Bitmap bitmap)
        {
            int Level = 255 / ColorCount;
            Graphics gr = Graphics.FromImage(bitmap);
            for (int s = 0; s < triangles.Count; s++)
            {

                
                Color color =  Color.FromArgb(0,255 - (Level*triangles[s].NestedLevel), 0);
             
                gr.FillPolygon(new SolidBrush(color)
                                       , new Point[] { triangles[s].pointA, triangles[s].pointB, triangles[s].pointC });
            }
        }

        // проверка находиться ли точка внутри треугольника
        private bool PointInTriangle(Triangle tr, Point point)
        {
           float a = (tr.pointA.X - point.X) * (tr.pointB.Y - tr.pointA.Y) - (tr.pointB.X - tr.pointA.X) * (tr.pointA.Y - point.Y);
           float b = (tr.pointB.X - point.X) * (tr.pointC.Y - tr.pointB.Y) - (tr.pointC.X - tr.pointB.X) * (tr.pointB.Y - point.Y);
           float c = (tr.pointC.X - point.X) * (tr.pointA.Y - tr.pointC.Y) - (tr.pointA.X - tr.pointC.X) * (tr.pointC.Y - point.Y);
            if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c < 0))
            {
                return true;
            }
            else
                return false;
        }
        // метод считает сколько у треугольника вложенных треугольников
        private void NestedTriangle()
        {
            for (int i = 0; i < triangles.Count; i++)
            {
                for (int j = 0; j < triangles.Count; j++)
                {
                    if (triangles[i] == triangles[j])
                    {

                    }
                    else
                    {
                        if (PointInTriangle(triangles[i], triangles[j].pointA)
                            || PointInTriangle(triangles[i], triangles[j].pointB)
                            || PointInTriangle(triangles[i], triangles[j].pointC))

                        {
                            triangles[j].NestedLevel += 1;
                        }
                    }
                }
            }
            //нахождения колва цветов
            try
            {
                ColorCount = triangles.Max(u => u.NestedLevel) + 1;
            }
            catch (Exception)
            {
            }
         

            
            
        }
    }
}

