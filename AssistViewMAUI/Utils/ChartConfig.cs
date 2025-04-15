using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ChartGenerater;


public class ChartConfig : INotifyPropertyChanged
{
    private ChartTypeEnum chartType;
    private string title;
    private Axes xAxis;
    private Axes yAxis;
    private ObservableCollection<SeriesConfig> series;
    private bool showLegend;

    public ChartTypeEnum ChartType
    {
        get => chartType;
        set
        {
            if (chartType != value)
            {
                chartType = value;
                OnPropertyChanged();
            }
        }
    }

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }

    public Axes XAxis
    {
        get => xAxis;
        set
        {
            if (xAxis != value)
            {
                xAxis = value;
                OnPropertyChanged();
            }
        }
    }

    public Axes YAxis
    {
        get => yAxis;
        set
        {
            if (yAxis != value)
            {
                yAxis = value;
                OnPropertyChanged();
            }
        }
    }

    public bool ShowLegend
    {
        get => showLegend;
        set
        {
            if (showLegend != value)
            {
                showLegend = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<SeriesConfig> Series
    {
        get => series;
        set
        {
            if (series != value)
            {
                series = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Axes : INotifyPropertyChanged
{
    private string? title;
    private double? min;
    private double? max;

    public string? Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }

    public AxisType Type
    {
        get;
        set;
    }

    public double? Min
    {
        get => min;
        set
        {
            if (min != value)
            {
                min = value;
                OnPropertyChanged();
            }
        }
    }

    public double? Max
    {
        get => max;
        set
        {
            if (max != value)
            {
                max = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}