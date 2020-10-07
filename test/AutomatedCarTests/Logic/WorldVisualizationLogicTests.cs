using Xunit;

namespace Tests.Logic
{
    using System;
    using System.Collections.Generic;
    using AutomatedCar.Logic;
    using AutomatedCar.Logic.Interface;
    using AutomatedCar.Models;

    public class WorldVisualizationLogicTests
    {
        private WorldVisualizationLogic _worldVisualizationLogic;
        private List<WorldObject> worldObjects;
        
        public WorldVisualizationLogicTests()
        {
            Console.WriteLine("Consturctor");
            _worldVisualizationLogic = WorldVisualizationLogic.CreateInstance();
        }

        [Fact]
        public void AllWorldObjectsTest()
        {
            worldObjects = _worldVisualizationLogic.AllWorldObjects();
            Assert.NotEmpty(this.worldObjects);
        }
    }
}