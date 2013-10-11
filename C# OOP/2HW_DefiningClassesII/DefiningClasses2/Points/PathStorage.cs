using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public static class PathStorage
    {
        public static void SaveFile(string pathOutputFile, Path inputPath)
        {
            StreamWriter writer;
            try
            {
                writer = new StreamWriter(pathOutputFile);
                using (writer)
                {
                    foreach (var point in inputPath.Points)
                    {
                        writer.WriteLine(point.ToString());
                    }
                }
                Console.WriteLine("Points successfully saved");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }

        }

        //Reads a text file with 3 coordinates per line for the coresponding points 
        public static Path LoadFile(string path)
        {
            Path outputPath = new Path();
            try
            {
                StreamReader reader = new StreamReader(path);
                Console.WriteLine("File successfully opened.");
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        char[] splitter = { ' ' };
                        string[] tokens = line.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                        double first = double.Parse(tokens[0]);
                        double second = double.Parse(tokens[1]);
                        double third = double.Parse(tokens[2]);
                        Point3D point = new Point3D(first, second, third);
                        outputPath.Points.Add(point);
                        line = reader.ReadLine();
                    }
                }
            }
            catch
            {
                Console.Error.WriteLine("Can't find first file.");
            }
            return outputPath;

        }
    }
}

