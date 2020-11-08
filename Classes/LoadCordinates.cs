using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace itv
{
    class LoadCordinates
    {
        private Triangle triangle;
        private List<string> lines = new List<string>();
        private List<Triangle> triangles = new List<Triangle>();

        private string[] chars = {" ","  ",","};

        //Метод загружает кординаты из файла и из строк переводит в числа и возвращает колекцию структур треугольников
        public List<Triangle> LoadCordinate()
        {
            lines = File.ReadAllLines("cordinates.txt").ToList();

            int countTriangles = Convert.ToInt32(lines[0]);

            lines.RemoveAt(0);

            if (countTriangles>lines.Count)
            {
                return new List<Triangle>();
            }
            if (lines.Count==0)
            {
                System.Windows.Forms.MessageBox.Show("Фаил пуст");
            }
           
            else
            {
                for (int i = 0; i <countTriangles ; i++)
                {
                    string[] numbers = null;
                    foreach (var c in chars)
                    {
                        numbers = lines[i].Split(c.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (numbers!=null)
                        {
                            break;
                        }
                    }
                    
                    
                    if (numbers.Length==6)
                    {
                        try
                        {
                            triangle = new Triangle(
                          new Point { X = Convert.ToInt32(numbers[0]), Y = Convert.ToInt32(numbers[1]) }
                          , new Point { X = Convert.ToInt32(numbers[2]), Y = Convert.ToInt32(numbers[3]) }
                          , new Point { X = Convert.ToInt32(numbers[4]), Y = Convert.ToInt32(numbers[5]) });

                            triangles.Add(triangle);
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Возможно неферный формат кординат");
                            return new List<Triangle>();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("ошибка в кординатах");
                        return new List<Triangle>();
                    }
                }
                return triangles;
            }
            return null;
            
        }
        
    }
}
