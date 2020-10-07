using AutomatedCar.Models;
using Avalonia;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Models
{
    public class WorldTests
    {
        World world;
        public WorldTests()
        {
            world = World.Instance;
            Polygon woodPoly = new Polygon();
            woodPoly.Points = new List<Point>();
            woodPoly.Points.Add(new Point(92, 81));
            woodPoly.Points.Add(new Point(91, 88));
            woodPoly.Points.Add(new Point(87, 94));
            woodPoly.Points.Add(new Point(82, 98));
            woodPoly.Points.Add(new Point(75, 101));
            woodPoly.Points.Add(new Point(69, 101));
            woodPoly.Points.Add(new Point(62, 98));
            woodPoly.Points.Add(new Point(57, 94));
            woodPoly.Points.Add(new Point(53, 88));
            woodPoly.Points.Add(new Point(52, 81));
            woodPoly.Points.Add(new Point(53, 74));
            woodPoly.Points.Add(new Point(57, 68));
            woodPoly.Points.Add(new Point(62, 64));
            woodPoly.Points.Add(new Point(69, 61));
            woodPoly.Points.Add(new Point(75, 61));
            woodPoly.Points.Add(new Point(82, 64));
            woodPoly.Points.Add(new Point(87, 68));
            woodPoly.Points.Add(new Point(91, 74));
            woodPoly.Points.Add(new Point(92, 81));
            world.AddObject(new Tree(10, 20, "tree", true, new RotationMatrix(1, 0, 0, 1), woodPoly));
        }

        [Fact]
        public void NotInsideTrianglTest()
        {
            List<Point> pointsOfTriangle = new List<Point>()
            {
                new Point(0, 0),
                new Point(15, 15),
                new Point(5, 10)
            };
            List<GameItem> itemsInside = world.GetWorldObjectsInsideTriangle(pointsOfTriangle);
            Assert.True(itemsInside.Count == 0);
        }

        [Fact]
        public void InsideTrianglTest()
        {
            List<Point> pointsOfTriangle = new List<Point>()
            {
                new Point(70, 100),
                new Point(120, 100),
                new Point(90, 110)
            };
            List<GameItem> itemsInside = world.GetWorldObjectsInsideTriangle(pointsOfTriangle);
            Assert.True(itemsInside.Count == 1);
        }
    }
}