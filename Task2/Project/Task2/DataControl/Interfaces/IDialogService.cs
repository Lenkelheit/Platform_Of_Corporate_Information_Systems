namespace DataControl.Interfaces
{
    public interface IDialogService
    {
        string FilePath { get; }
        System.Drawing.Color Color { get; }

        void ShowMessage(string message);
        bool ColorDialog();
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
}
