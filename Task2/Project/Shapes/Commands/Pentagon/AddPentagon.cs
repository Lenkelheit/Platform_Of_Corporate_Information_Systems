namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents command of adding <see cref="Models.Pentagon"/>.
    /// </summary>
    public class AddPentagon : Interfaces.ICommand
    {
        // CONST
        private const int COUNT_VERTEX = 5;
        // FIELDS
        private Models.Canvas canvas;
        private System.Collections.Generic.List<System.Windows.Point> sortedPoints;
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Pentagon added";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="canvas">Current canvas.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when canvas is null.
        /// </exception>
        public AddPentagon(Models.Canvas canvas)
        {
            if (canvas == null)
            {
                throw new System.ArgumentNullException("Canvas is null.");
            }
            this.canvas = canvas;
            sortedPoints = new System.Collections.Generic.List<System.Windows.Point>();
        }
        // METHODS
        private void SortPoints(System.Collections.Generic.List<System.Windows.Point> pointsList)
        {
            double distance = 0, prevDistance = 0;
            for (int i = 0; i < COUNT_VERTEX; i++)
            {
                for (int j = 0; j < COUNT_VERTEX; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    for (int k = 0; k < COUNT_VERTEX; k++)
                    {
                        if (k == i || k == j)
                        {
                            continue;
                        }
                        for (int m = 0; m < COUNT_VERTEX; m++)
                        {
                            if (m == i || m == j || m == k)
                            {
                                continue;
                            }
                            for (int p = 0; p < COUNT_VERTEX; p++)
                            {
                                if (p == i || p == j || p == k || p == m)
                                {
                                    continue;
                                }

                                distance = System.Math.Sqrt(System.Math.Pow(pointsList[j].X - pointsList[i].X, 2) + System.Math.Pow(pointsList[j].Y - pointsList[i].Y, 2)) +
                                    System.Math.Sqrt(System.Math.Pow(pointsList[k].X - pointsList[j].X, 2) + System.Math.Pow(pointsList[k].Y - pointsList[j].Y, 2)) +
                                    System.Math.Sqrt(System.Math.Pow(pointsList[m].X - pointsList[k].X, 2) + System.Math.Pow(pointsList[m].Y - pointsList[k].Y, 2)) +
                                    System.Math.Sqrt(System.Math.Pow(pointsList[p].X - pointsList[m].X, 2) + System.Math.Pow(pointsList[p].Y - pointsList[m].Y, 2));
                                if (prevDistance == 0 || prevDistance > distance)
                                {
                                    sortedPoints.Clear();
                                    sortedPoints.Add(pointsList[i]);
                                    sortedPoints.Add(pointsList[j]);
                                    sortedPoints.Add(pointsList[k]);
                                    sortedPoints.Add(pointsList[m]);
                                    sortedPoints.Add(pointsList[p]);

                                    prevDistance = distance;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Adds <see cref="Models.Pentagon"/>.
        /// </summary>
        public void Execute()
        {
            System.Collections.Generic.List<System.Windows.Point> pointsList = new System.Collections.Generic.List<System.Windows.Point>();
            for (int i = 0; i < COUNT_VERTEX; i++)
            {
                pointsList.Add((canvas[canvas.Count - 1] as Models.Vertex).Location);
                canvas.Remove(canvas[canvas.Count - 1]);
            }
            // Sorts points if they aren`t sorted.
            if (sortedPoints.Count == 0)  
            {
                SortPoints(pointsList);
            }
            Models.Pentagon pentagon = new Models.Pentagon
            {
                Points = sortedPoints.ToArray()
            };
            canvas.Add(pentagon);
        }
        /// <summary>
        /// Restores previous state without added <see cref="Models.Pentagon"/>.
        /// </summary>
        public void UnExecute()
        {
            canvas.RemoveAt(canvas.Count - 1);
            for (int i = 0; i < COUNT_VERTEX; i++)
            {
                canvas.Add(new Models.Vertex
                {
                    Location = sortedPoints[i]
                });
            }
        }
    }
}
