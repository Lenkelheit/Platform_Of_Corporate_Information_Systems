using System;
using System.Drawing;

namespace DataControl.Services
{
    public class DefaultDialogService : Interfaces.IDialogService
    {
        public Color Color
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FilePath
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ColorDialog()
        {
            throw new NotImplementedException();
        }

        public bool OpenFileDialog()
        {
            throw new NotImplementedException();
        }

        public bool SaveFileDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
