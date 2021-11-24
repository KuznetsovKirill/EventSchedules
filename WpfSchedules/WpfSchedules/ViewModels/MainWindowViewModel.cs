using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfSchedules.Infrastructure;
using WpfSchedules.ViewModels.Base;

namespace WpfSchedules.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Event Shedules";
        
        public string Title
        {
            get => _Title;           
            set => Set(ref _Title, value);
        }

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }   

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
