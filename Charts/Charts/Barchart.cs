using Charts.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Charts
{
    public class Barchart : ContentPage
    {
        Series firstBarSeries;
        Series secondBarSeries;
        Series lineSeries;
        Chart  barChart;
        Chart  LineChart;
        public Barchart()
        {
            DrawBarLineChart();

            var grid = new Grid
            {
                RowDefinitions =
                {
                  new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                  new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                  new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                  new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                }
            };


            var stacklayoutBarChart = new StackLayout { Orientation = StackOrientation.Vertical };
            var stacklayoutLineChart = new StackLayout { Orientation = StackOrientation.Vertical };

            stacklayoutBarChart.Children.Add(barChart);
            stacklayoutLineChart.Children.Add(LineChart);

            grid.Children.Add(stacklayoutBarChart, 0, 0);
            Grid.SetColumnSpan(stacklayoutBarChart, 2);
            grid.Children.Add(stacklayoutLineChart, 0, 1);
            Grid.SetColumnSpan(stacklayoutLineChart, 2);

            Content = grid;
        }
        private void DrawBarLineChart()
        {
            firstBarSeries = new Series
            {
                Color = Color.Red,
                Type = ChartType.Bar
            };
            firstBarSeries.Points.Add(new DataPoint() { Label = "Jan", Value = 25 });
            firstBarSeries.Points.Add(new DataPoint() { Label = "Feb", Value = 40 });
            firstBarSeries.Points.Add(new DataPoint() { Label = "March", Value = 45 });

            secondBarSeries = new Series
            {
                Color = Color.Blue,
                Type = ChartType.Bar
            };
            secondBarSeries.Points.Add(new DataPoint() { Label = "Jan", Value = 30 });
            secondBarSeries.Points.Add(new DataPoint() { Label = "Feb", Value = 35 });
            secondBarSeries.Points.Add(new DataPoint() { Label = "March", Value = 40 });

            barChart = new Chart()
            {
                Color = Color.Purple,
                WidthRequest = 600,
                HeightRequest = 350,
                Spacing = 30,
                XTitle = "Year",
                YTitle = "Progress"
            };
            barChart.Series.Add(firstBarSeries);
            barChart.Series.Add(secondBarSeries);

            lineSeries = new Series
            {
                Color = Color.Green,
                Type = ChartType.Line
            };
            lineSeries.Points.Add(new DataPoint() { Label = "Jan", Value = 27.5 });
            lineSeries.Points.Add(new DataPoint() { Label = "Feb", Value = 37.5 });
            lineSeries.Points.Add(new DataPoint() { Label = "March", Value = 42.5 });

            LineChart = new Chart()
            {
                Color = Color.Purple,
                WidthRequest = 600,
                HeightRequest = 350,
                Spacing = 30,
                XTitle = "Year",
                YTitle = "Progress"
            };
            LineChart.Series.Add(lineSeries);
        }
    }
}
