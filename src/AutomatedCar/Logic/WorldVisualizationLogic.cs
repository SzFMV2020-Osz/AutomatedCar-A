namespace AutomatedCar.Logic
{
    using System.Collections.Generic;
    using Interface;
    using Models;

    public class WorldVisualizationLogic : IWorldVisualisation
    {
        /// <inheritdoc/>
        public List<WorldObject> GameItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldVisualizationLogic"/> class.
        /// Constructor to set gameItems and start parsing.
        /// </summary>
        public WorldVisualizationLogic()
        {
        }

        /// <inheritdoc/>
        public List<WorldObject> AllWorldObjects()
        {
            return this.GameItems;
        }
    }
}