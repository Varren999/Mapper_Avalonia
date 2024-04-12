using ReactiveUI;
using System;
using System.Reactive;
using Log;

namespace Mapper_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string start1 = "0";
    private string stop1 = "10";
    private string start2 = "4";
    private string stop2 = "20";
    private string valueToMap = "5";
    private string result = "0";

    public string tbStart1
    {
        get => start1;
        set => this.RaiseAndSetIfChanged(ref start1, value);
    }

    public string tbStop1
    {
        get => stop1;
        set => this.RaiseAndSetIfChanged(ref stop1, value);
    }

    public string tbStart2
    {
        get => start2;
        set => this.RaiseAndSetIfChanged(ref start2, value);
    }

    public string tbStop2
    {
        get => stop2;
        set => this.RaiseAndSetIfChanged(ref stop2, value);
    }

    public string tbValueToMap
    {
        get => valueToMap;
        set => this.RaiseAndSetIfChanged(ref valueToMap, value);
    }

    public string tbResult
    {
        get => result;
        set => this.RaiseAndSetIfChanged(ref result, value);
    }

    public ReactiveCommand<Unit, Unit> bMapping { get; }
    
    public MainViewModel()
    {
        bMapping = ReactiveCommand.Create(bMapping_Click);
    }

    private void bMapping_Click()
    {
        try
        {
            result = Convert.ToString(Map(Convert.ToDouble(valueToMap), Convert.ToDouble(start1), Convert.ToDouble(stop1), Convert.ToDouble(start2), Convert.ToDouble(stop2)));
        }
        catch (Exception ex)
        {
            Logger.Error("bMaping_Click: " + ex);
        }
    }

    private double Map(double valueToMap, double start1, double stop1, double start2, double stop2)
    {
        return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
    }
}
