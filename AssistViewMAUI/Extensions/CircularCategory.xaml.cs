using System.Collections.ObjectModel;
using Syncfusion.Maui.Toolkit.Charts;

namespace ChartGenerater;

public partial class CircularCategory : SfCircularChart
{
	public CircularCategory()
	{
		InitializeComponent();
	}

public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ObservableCollection<SeriesConfig>), typeof(CircularCategory), null, BindingMode.Default, null, OnPropertyChanged);
public ObservableCollection<SeriesConfig> Source
{
    get => (ObservableCollection<SeriesConfig>)GetValue(SourceProperty);
    set => SetValue(SourceProperty, value);
}

private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
{
    if (bindable is CircularCategory chart)
    {
        chart.GenerateSeries(newValue as ObservableCollection<SeriesConfig>);
    }
}

private void GenerateSeries(ObservableCollection<SeriesConfig> configs)
{
    if (configs != null)
    {
        this.Series.Clear();
        foreach (var config in configs)
        {
            CreateSeriesFromTemplate(config);
        }
    }
}

private void CreateSeriesFromTemplate(SeriesConfig config)
{
    var templateSelector = (SeriesTemplateSelector)Resources["seriesTemplateSelector"];
    var template = templateSelector.SelectTemplate(config, null);

    if (template != null)
    {
        ChartSeries series = (ChartSeries)template.CreateContent();

        if (series != null)
        {
            series.BindingContext = config;
            this.Series.Add(series);
        }
    }
}
}