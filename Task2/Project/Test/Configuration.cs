namespace Test
{
    static class Configuration
    {
        public static readonly string CANVAS_SERIALIZATION_FILE_NAME = @"..\..\Serialization\CanvasData.xml";
        public static readonly string PENTAGON_SERIALIZATION_FILE_NAME = @"..\..\Serialization\PentagonData.xml";
        
        public static readonly int POINTS_AMOUNT = 5;
        
        public static void UndoAll(Shapes.Models.UndoRedoManager manager)
        {
            while (manager.CanUndo)
            {
                manager.Undo();
            }
        }
    }
}
