namespace AutomatedCar.Logic.Interface
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using AutomatedCar.Models;

    /// <summary>
    /// Interface for handling World Object List.
    /// </summary>
    public interface IWorldVisualisation
    {
        /// <summary>
        /// Parameter to hold world objects.
        /// </summary>
        List<WorldObject> GameItems { get; }

        /// <summary>
        /// Return world objects
        /// </summary>
        /// <returns>World objects</returns>
        List<WorldObject> AllWorldObjects();
    }
}