namespace AutomatedCar.Logic
{
    using System.Collections.Generic;
    using AutomatedCar.Logic.Interface;
    using AutomatedCar.Models;

    /// <summary>
    /// Return a list containing world objects.
    /// </summary>
    public class WorldVisualizationLogic : IWorldVisualisation
    {
        /// <summary>
        /// Create Logic instance.
        /// </summary>
        /// <returns>WorldVisualizationLogic instance</returns>
        public static WorldVisualizationLogic CreateInstance()
        {
            return new WorldVisualizationLogic();
        }

        /// <summary>
        /// Gets parameter to hold world objects.
        /// </summary>
        private List<WorldObject> GameItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldVisualizationLogic"/> class.
        /// Constructor to set gameItems and start parsing.
        /// </summary>
        private WorldVisualizationLogic()
        {
            JsonParser jsonParser = new JsonParser("src/AutomatedCar/Assets/test_world_1kmx1km.json",
                "src/AutomatedCar/Assets/worldobject_polygons.json");
            this.GameItems = jsonParser.ItemLoader();
        }

        /// <inheritdoc/>
        public List<WorldObject> AllWorldObjects()
        {
            return this.GameItems;
        }
    }
}