using Avalonia.Logging;
using ReactiveUI;
using System;
using System.Reactive;

namespace Mapper_Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";

        private string start1;
        public string Start1
        {
            get => start1;
            set => this.RaiseAndSetIfChanged(ref start1, value);
        }

        private string stop1;
        public string Stop1
        {
            get => stop1;
            set => this.RaiseAndSetIfChanged(ref stop1, value);
        }

        private string start2;
        public string Start2
        {
            get => start2;
            set => this.RaiseAndSetIfChanged(ref start2, value);
        }

        private string stop2;
        public string Stop2
        {
            get => stop2;
            set => this.RaiseAndSetIfChanged(ref stop2, value);
        }

        private string valueToMap;
        public string ValueToMap
        {
            get => valueToMap;
            set => this.RaiseAndSetIfChanged(ref valueToMap, value);
        }

        private string result;
        public string Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }

        public ReactiveCommand<Unit, Unit> Mapping { get; }

        public MainWindowViewModel()
        {
            Mapping = ReactiveCommand.Create(Mapping_Click);
        }

        private void Mapping_Click()
        {
            try
            {
                Result = Convert.ToString(Map(Convert.ToDouble(valueToMap), Convert.ToDouble(start1), Convert.ToDouble(stop1), Convert.ToDouble(start2), Convert.ToDouble(stop2)));
            }
            catch (Exception ex)
            {
                //Logger.Error("Maping_Click: " + ex);
            }
        }

        private double Map(double valueToMap, double start1, double stop1, double start2, double stop2) => ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
    }
}
