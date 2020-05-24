using System.Windows.Input;
using CalmanFiltering.Models;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace CalmanFiltering.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Модель фильтрации";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов...";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        public Moving1DViewModel Model { get; }

        public MainWindowViewModel(Moving1DViewModel Model) => this.Model = Model;
    }
}
