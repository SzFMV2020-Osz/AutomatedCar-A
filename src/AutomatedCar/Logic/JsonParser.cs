using System;
using System.Collections.Generic;
using System.Text;
using Json.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using Avalonia.Controls.Shapes;
using Newtonsoft.Json;
using AutomatedCar.Models;

namespace AutomatedCar.Logic
{
    public class JsonParser
    {
        //List<Models.WorldObject> GameItems;
        Models.World world;
        IList<JToken> ObjectList;
        IList<JToken> PolygonList;
        List<List<Polygon>> ParsedPolygonList;

        public JsonParser()
        {
            //this.InputJson = inputJson;
            //GameItems = new List<Models.WorldObject>();
            world = new Models.World();
            string readFile;
            //beolvasás
            using (StreamReader file = File.OpenText(@"C:\Users\Bence\Documents\AutomatedCar-A\src\AutomatedCar\Assets\test_world_1kmx1km.json"))
            {
                readFile = file.ReadToEnd();
            }

            JObject UnparsedObjectList = JObject.Parse(readFile);
            //world szélessség, magasság beállítása
            world.Height = int.Parse(UnparsedObjectList["height"].ToString());
            world.Width = int.Parse(UnparsedObjectList["width"].ToString());
            //Objectek átadása a listának
            this.ObjectList = UnparsedObjectList["objects"].Children().ToList();

            //polygonok beolvasása
            using (StreamReader file = File.OpenText(@"C:\Users\Bence\Documents\AutomatedCar-A\src\AutomatedCar\Assets\worldobject_polygons.json"))
            {
                readFile = file.ReadToEnd();
            }

            JObject UnparsedPolygonList = JObject.Parse(readFile);
            //Polygon Objectek átadása a listának
            this.PolygonList = UnparsedPolygonList["objects"].Children().ToList();

            //Feltöltjük a polygonokkal a polygon listát
            this.ParsedPolygonList = PolygonLoader();
            //GameItems();
        }


        public List<Models.WorldObject> ItemLoader()
        {
            List<Models.WorldObject> list = new List<Models.WorldObject>();
            foreach (JToken obj in this.ObjectList)
            {
                string type = obj["type"].ToString();
                int x = int.Parse(obj["x"].ToString());
                int y = int.Parse(obj["y"].ToString());
                RotationMatrix rm = new RotationMatrix(int.Parse(obj["m11"].ToString()), int.Parse(obj["m12"].ToString()), int.Parse(obj["m21"].ToString()), int.Parse(obj["m22"].ToString()));

                List<Polygon> temp = new List<Polygon>();
                foreach (List<Polygon> polygonList in ParsedPolygonList)
                {
                    foreach (Polygon polygon in polygonList)
                    {
                        if (polygon.Name == type)
                        {
                            temp = polygonList;
                            break;
                        }
                    }
                }

                switch (type)
                {
                    //ROADS
                    case "road_2lane_90right":
                        Road road = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road);
                        break;
                    case "road_2lane_45right":
                        Road road2 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road2);
                        break;
                    case "road_2lane_45left":
                        Road road3 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road3);
                        break;
                    case "road_2lane_6right":
                        Road road4 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road4);
                        break;
                    case "road_2lane_6left":
                        Road road5 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road5);
                        break;
                    case "road_2lane_straight":
                        Road road6 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road6);
                        break;
                    case "road_2lane_90left":
                        Road road7 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road7);
                        break;
                    case "2_crossroad_1":
                        Road road8 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road8);
                        break;
                    case "2_crossroad_2":
                        Road road9 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road9);
                        break;
                    case "road_2lane_rotary":
                        Road road10 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road10);
                        break;
                    case "road_2lane_tjunctionleft":
                        Road road11 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road11);
                        break;
                    case "road_2lane_tjunctionright":
                        Road road12 = new Road(x, y, type, false, rm, temp);
                        world.AddObject(road12);
                        break;

                    //PARKING
                    case "parking_90":
                        Parking parking = new Parking(x, y, type, false, rm, temp);
                        world.AddObject(parking);
                        break;
                    case "parking_space_parallel":
                        Parking parking2 = new Parking(x, y, type, false, rm, temp);
                        world.AddObject(parking2);
                        break;

                    //SIGNS
                    case "roadsign_parking_right":
                        Sign sign = new Sign(x, y, type, true, rm, temp.First());
                        world.AddObject(sign);
                        break;
                    case "roadsign_priority_stop":
                        Sign sign1 = new Sign(x, y, type, true, rm, temp.First());
                        world.AddObject(sign1);
                        break;
                    case "roadsign_speed_40":
                        Sign sign2 = new Sign(x, y, type, true, rm, temp.First());
                        world.AddObject(sign2);
                        break;
                    case "roadsign_speed_50":
                        Sign sign3 = new Sign(x, y, type, true, rm, temp.First());
                        world.AddObject(sign3);
                        break;
                    case "roadsign_speed_60":
                        Sign sign4 = new Sign(x, y, type, true, rm, temp.First());
                        world.AddObject(sign4);
                        break;

                    //EGYÉB
                    case "garage":
                        Garage garage = new Garage(x, y, type, true, rm, temp.First());
                        world.AddObject(garage);
                        break;
                    case "tree":
                        Tree tree = new Tree(x, y, type, true, rm, temp.First());
                        world.AddObject(tree);
                        break;
                    case "bollard":
                        Circle bollard = new Circle(x, y, type, 100);   //circle radiusa mennyi?
                        world.AddObject(bollard);
                        break;

                }


            }

            return list;
        }
        public List<List<Polygon>> PolygonLoader()
        {
            List<List<Polygon>> List = new List<List<Polygon>>();

            //minden object feldolgozása
            foreach (JToken obj in this.PolygonList)
            {
                List<Polygon> subList = new List<Polygon>();
                string typename = obj["typename"].ToString();

                //egy object polyjai
                var polys = obj["polys"].Children();

                foreach (var polyObject in polys)
                {
                    //a poly ponjtai
                    IList<JToken> points2 = polyObject["points"].Children().ToList();
                    Polygon polyg = new Polygon();
                    polyg.Name = typename;              //mivel egy konkrét polygonnál lehet csak tárolni nevet, ezért minden polygonnál ott lesz
                    polyg.Points = new List<Avalonia.Point>();

                    foreach (JToken item in points2)
                    {
                        string[] xystrings = item.ToString().Split(',');
                        double x = double.Parse(xystrings[0].Where(Char.IsDigit).ToArray());
                        double y = double.Parse(xystrings[0].Where(Char.IsDigit).ToArray());

                        polyg.Points.Add(new Avalonia.Point(x, y));

                    }
                    subList.Add(polyg);

                }
                List.Add(subList);
            }

            return List;
        }

    }
}
