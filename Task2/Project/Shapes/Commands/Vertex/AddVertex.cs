﻿using System.Collections.Generic;

namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Class that represents command for adding vertex to pentagon
    /// </summary>
    public class AddVertex : Interfaces.ICommand
    {

        // FIELDS
        Models.Canvas baseCanvas;
        Models.Vertex target;
        Models.UndoRedoManager workCommandManger;


        //CONSTRUCTORS
        /// <summary>
        /// Constructor with 3 parameters
        /// </summary>
        /// <param name="baseCanvas">Vertex in which will be added vertex</param>
        /// <param name="target">Added vertex</param>
        /// <param name="workCommandManger">program command manager</param>
        /// <exception cref="System.NullReferenceException">Pentagon, command manager or vertex doesn't exist!</exception>
        AddVertex(Models.Canvas baseCanvas, Models.Vertex target, Models.UndoRedoManager workCommandManger)
        {
            if (baseCanvas == null)
            {
                throw new System.NullReferenceException("Canvas doesn't exist!");
            }
            if (target == null)
            {
                throw new System.NullReferenceException("Vertex doesn't exist!");
            }
            if (workCommandManger == null)
            {
                throw new System.NullReferenceException("Command manager doesn't exist!");
            }
            this.baseCanvas = baseCanvas;
            this.target = target;
            this.workCommandManger = workCommandManger;
        }


        // PROPERTIES
        /// <summary>
        /// Property that enable to interract with command name
        /// </summary>
        /// <returns>Command name</returns>
        public string Name
        {
            get
            {
                return "Vertex added";
            }
        }

        // METHODS
        /// <summary>
        /// Method that execute command
        /// </summary>
        public void Execute()
        {
            baseCanvas.Add(target);
            Models.Vertex.NumberOfVertex++;
            if (Models.Vertex.NumberOfVertex == Models.Pentagon.NUM_OF_EDGE_IN_PENTAGON)
            {
                workCommandManger.PopUndo();
                workCommandManger.Execute(new Pentagon.AddPentagon(baseCanvas));
            }
        }
        /// <summary>
        /// Method that returns command execution
        /// </summary>
        /// <exception cref="System.NullReferenceException">Vertex doesn't exist!</exception>
        public void UnExecute()
        {
            if (Models.Vertex.NumberOfVertex == 0)
            {
                throw new System.NullReferenceException("Vertex doesn't exist!");
            }
            else
            {
                baseCanvas.RemoveAt(Models.Vertex.NumberOfVertex - 1);
                Models.Vertex.NumberOfVertex--;
            }

        }
    }
}
