namespace AutomatedCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Avalonia;
    using Avalonia.Controls.Shapes;
    using ReactiveUI;

    public class World : ReactiveObject
    {
        // private static readonly System.Lazy<World> lazySingleton = new System.Lazy<World> (() => new World());
        // public static World Instance { get { return lazySingleton.Value; } }

        private AutomatedCar _controlledCar;

        public static World Instance { get; } = new World();

        public ObservableCollection<WorldObject> WorldObjects { get; } = new ObservableCollection<WorldObject>();

        public AutomatedCar ControlledCar
        {
            get => this._controlledCar;
            set => this.RaiseAndSetIfChanged(ref this._controlledCar, value);
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public void AddObject(WorldObject worldObject)
        {
            this.WorldObjects.Add(worldObject);
        }

        private static double GetArea(Point a, Point b, Point c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) +
                             b.X * (c.Y - a.Y) +
                             c.X * (a.Y - b.Y)) / 2.0);
        }

        /* A function to check whether point P(x, y) lies 
        inside the triangle formed by A(x1, y1), 
        B(x2, y2) and C(x3, y3) */
        static bool IsInside(List<Point> triangle, Point target)
        {
            Point a = triangle[0];
            Point b = triangle[1];
            Point c = triangle[2];

            /* Calculate area of triangle ABC */
            double areaFull = GetArea(a, b, c);

            /* Calculate area of triangle PBC */
            double area1 = GetArea(target, b, c);

            /* Calculate area of triangle PAC */
            double area2 = GetArea(a, target, c);

            /* Calculate area of triangle PAB */
            double area3 = GetArea(a, b, target);

            double dummy = (area1 + area2 + area3);

            /* Check if sum of A1, A2 and A3 is same as A */
            return areaFull == (area1 + area2 + area3);
        }

        public List<GameItem> GetWorldObjectsInsideTriangle(List<Point> pointsOfTriangle)
        {
            List<GameItem> objectsInside = new List<GameItem>();
            bool hasBeenAdded = false;

            foreach (GameItem item in this.WorldObjects)
            {
                foreach (Polygon polygon in item.Polygons)
                {
                    foreach (Point point in polygon.Points)
                    {
                        if (IsInside(pointsOfTriangle, point))
                        {
                            objectsInside.Add(item);
                            hasBeenAdded = true;
                            break;
                        }
                    }

                    if (hasBeenAdded)
                    {
                        hasBeenAdded = false;
                        break;
                    }
                }
            }

            return objectsInside;
        }
    }
}