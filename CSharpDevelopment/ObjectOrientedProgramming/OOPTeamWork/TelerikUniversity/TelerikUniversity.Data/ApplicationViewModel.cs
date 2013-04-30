using System;
using System.Linq;
using System.Windows.Media;

namespace TelerikUniversity.Data
{
    public class ApplicationViewModel : PropertyChange
    {
        private Color _Foreground;
        public Color Foreground
        {
            get { return this._Foreground; }
            set { _Foreground = value; RaisePropertyChanged("Foreground"); }
        }
    }
}
