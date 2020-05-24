using System.Windows.Input;
using CalmanFiltering.Models;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace CalmanFiltering.ViewModels
{
    class Moving1DViewModel : ViewModel
    {
        private readonly Moving1D _Model = new Moving1D();

        #region MovementData : Movement1D - Данные по результатам вычисления траектории

        /// <summary>Данные по результатам вычисления траектории</summary>
        private Movement1D _MovementData;

        /// <summary>Данные по результатам вычисления траектории</summary>
        public Movement1D MovementData { get => _MovementData; private set => Set(ref _MovementData, value); }

        #endregion

        #region Команды

        #region Command ComputeData : Выполнить вычисление

        /// <summary>Выполнить вычисление</summary>
        public ICommand ComputeData { get; }

        private static bool CanComputeDataExecute(object p) => true;

        private void OnComputeDataExecuted(object p) => MovementData = _Model.GetMovement();

        #endregion

        #endregion

        public Moving1DViewModel()
        {
            ComputeData = new LambdaCommand(OnComputeDataExecuted, CanComputeDataExecute);
            OnComputeDataExecuted(null);
        }
    }
}
