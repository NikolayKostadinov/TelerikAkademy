using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace HiddenTruth.Library.Model
{
    public class SiteModel
    {

        public string Id { get; set; }
        public string ImagePath { get; set; }

        public string Title { get; set; }

        public int SelectedIndex { get; set; }
        public ObservableCollection<ItemModel> Items { get; set; } 

        public ObservableCollection<PageModel> Pages { get; set; } 

        public SiteModel()
        {
            Id = Guid.NewGuid().ToString();
            SelectedIndex = 0;
            Items = new ObservableCollection<ItemModel>();
            Pages = new ObservableCollection<PageModel>();
        }

        private RelayCommand<string> _goToCommand;
        public RelayCommand<string> GoToCommand
        {
            get
            {
                if (_goToCommand == null)
                {
                    _goToCommand = new RelayCommand<string>(NavigateAway);
                }
                return _goToCommand;
            }
        }

        private void NavigateAway(string parameter)
        {

        }
    }
}
