using ReactiveUI;
using System;
using System.Reactive;

namespace Mapper_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string start1;
    private string stop1;
    private string start2;
    private string stop2;
    private string valueToMap;
    private string result;

    public string tbStart1
    {
        get => start1;
        set => SetAndRaise(ref start1, value);
    }

    public string tbStop1
    {
        get => stop1;
        set => SetAndRaise(ref stop1, value);
    }

    public string tbStart2
    {
        get => start2;
        set => SetAndRaise(ref start2, value);
    }

    public string tbStop2
    {
        get => stop2;
        set => SetAndRaise(ref stop2, value);
    }

    public string tbValueToMap
    {
        get => valueToMap;
        set => SetAndRaise(ref valueToMap, value);
    }

    public string tbResult
    {
        get => result;
        set => SetAndRaise(ref result, value);
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
            //Logger.Error("bMaping_Click: " + ex);
        }
    }

    private double Map(double valueToMap, double start1, double stop1, double start2, double stop2)
    {
        return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
    }
}
