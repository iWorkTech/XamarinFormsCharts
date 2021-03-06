This code is available for use on a “AS IS” BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND. 
This document is authored by members of IWORKTECH’s mobility team.  Please send all feedback and inquiries to info@iworktech.com. 
 
## Introduction

In this document, we have several illustration with demo code. Developer should use this code as it is or with minimal changes. The aim of sharing is to improve the productivity of a Xamarin developer. 

### Plot Bar and Line chart code

#### Objective: 
This code helps a Xamarin developer to embed a code in his/her code.  It allows plotting of a bar or a line chart quickly. On the graph, currently in the Xamarin.Form, we can’t change the font size and labels of the X- and Y- axis. This utility addresses these issues by allowing you to do make necessary changes.  

#### Available on 

![icons] (https://thedistance.co.uk/wp-content/uploads/2015/10/ios.android.icon_.jpg)

### Why do I need it? 
As a developer, I need to add additional features like, 
- labeling of X- and Y- axis. 
- change the font size. 

#### Without using IWORKTECH’s utility code

In a Xamarin form, normally using the following code one can provide a bar or line chart functionalities/features. 
```
<charting:Chart.Series>
            <charting:Series Type="Bar" Color="Red">
              <charting:Series.Points>
                <charting:DataPoint Label="Jan" Value="25" />
                <charting:DataPoint Label="Feb" Value="40" />
                <charting:DataPoint Label="March" Value="45" />
              </charting:Series.Points>
            </charting:Series>
            <charting:Series Type="Bar" Color="Blue">
              <charting:Series.Points>
                <charting:DataPoint Label="Jan" Value="30" />
                <charting:DataPoint Label="Feb" Value="35" />
                <charting:DataPoint Label="March" Value="40" />
              </charting:Series.Points>
            </charting:Series>
          </charting:Chart.Series>
<charting:Chart x:Name="MonthlySalesChart" 
                        Spacing="50"
                        WidthRequest="600"
                        HeightRequest="600"
                        Color="Purple"
                        VerticalOptions="FillAndExpand">

        </charting:Chart>
         chart.cs
         private float DrawGrid(double highestValue)
        {
            int noOfHorizontalLines = 4;
            double quarterValue = highestValue / 4;
            double valueOfPart = ((int)Math.Round(quarterValue / 10.0)) *10;
            if (valueOfPart < quarterValue)
                noOfHorizontalLines = 5;
            double quarterHeight = (HeightRequest - PADDING_TOP) / noOfHorizontalLines;
            
            // Horizontal lines and Y-value labels
            OnDrawText (this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData((valueOfPart * noOfHorizontalLines).ToString(), 10, PADDING_TOP + 5) });
            for (int i = 1; i <= noOfHorizontalLines; i++)
            {
                if (Grid)
                {
                    OnDrawGridLine(this, new DrawEventArgs<DoubleDrawingData>() { Data = new DoubleDrawingData(PADDING_LEFT, PADDING_TOP + (quarterHeight * i), WidthRequest, PADDING_TOP + (quarterHeight * i), 0) });
                }
                double currentValue = (valueOfPart * noOfHorizontalLines) - (valueOfPart * i);
                OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(currentValue.ToString(), 10, PADDING_TOP + (quarterHeight * i) + 5) });
            }
                        return (float)valueOfPart * noOfHorizontalLines;
        }
        
         private void DrawLabels(double highestValue, double widthPerBar, DataPointCollection points)
{

int noOfBarSeries = Series.Count(s => s.Type == ChartType.Bar);
            if (noOfBarSeries == 0)
                noOfBarSeries = 1;
            double widthOfAllBars = noOfBarSeries * widthPerBar;
            double widthIterator = 2 + PADDING_LEFT;

            for (int i = 0; i < points.Count; i++)
            {
                OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(points[i].Label, (widthIterator + widthOfAllBars / 2) - (points[i].Label.Length * 4), HeightRequest + 25) });
                widthIterator += widthPerBar * noOfBarSeries + Spacing;
            }
                 
        //in android chartsurface.cs
        
        public ChartSurface(Context context, Chart chart, AndroidColor color, AndroidColor[] colors)
            : base(context)
        {
            SetWillNotDraw(false);
            Chart = chart;
            Paint = new Paint() { Color = color, StrokeWidth = 2 };
            Colors = colors;
        }
 ```
Using the above XAML code we have generated the following graph.

![Graph1] (http://52.77.35.210:83/Media/Default/images/githubimages/graph1.png)

Fig 1- Progress chart in the sales without X and Y axis labels

### Using IWORKTECH’s utility code
As a developer, I want to add labels to the X and Y coordinates. 

I can achieve by using two methods. These are :
- Method 1 – change in XMAL
- Method 2 – change in C#

**Brief:**

Using the following code, one can plot the bar chart is displayed as in Fig 2. The bar chart has now:

- X - Title
- Y – Title

## Method 1  –  XAML code:

```
  <charting: Chart x: Name="MonthlySalesChart" 
                        Spacing="50"
                        WidthRequest="600"
                        HeightRequest="600"
                        Color="Purple"
                        XTitle="Year"
                        YTitle="Progress"
                        VerticalOptions="FillAndExpand">
          <charting: Chart.Series>
            <charting:Series Type="Bar" Color="Red">
              <charting:Series.Points>
                <charting:DataPoint Label="Jan" Value="25" />
                <charting:DataPoint Label="Feb" Value="40" />
                <charting:DataPoint Label="March" Value="45" />
              </charting:Series.Points>
            </charting:Series>
            <charting:Series Type="Bar" Color="Blue">
              <charting:Series.Points>
                <charting:DataPoint Label="Jan" Value="30" />
                <charting:DataPoint Label="Feb" Value="35" />
                <charting:DataPoint Label="March" Value="40" />
              </charting:Series.Points>
            </charting:Series>
          </charting:Chart.Series>
        </charting:Chart>

chart.cs

        public static readonly BindableProperty XTitleProperty = BindableProperty.Create("XTitle", typeof(string), typeof(Chart), "XAxis", BindingMode.OneWay, null, null, null, null);

        public static readonly BindableProperty YTitleProperty = BindableProperty.Create("YTitle", typeof(string), typeof(Chart), "YAxis", BindingMode.OneWay, null, null, null, null);
        
         public string XTitle
        {
            get
            {
                return (string)base.GetValue(Chart.XTitleProperty);
            }
            set
            {
                base.SetValue(Chart.XTitleProperty, value);
            }
        }
        public string YTitle
        {
            get
            {
                return (string)base.GetValue(Chart.YTitleProperty);
            }
            set
            {
                base.SetValue(Chart.YTitleProperty, value);
            }
        }
     private float DrawGrid(double highestValue)
        {
            int noOfHorizontalLines = 4;
            double quarterValue = highestValue / 4;
            double valueOfPart = ((int)Math.Round(quarterValue / 10.0)) * 10;
            if (valueOfPart < quarterValue)
                noOfHorizontalLines = 5;
            double quarterHeight = (HeightRequest - PADDING_TOP) / noOfHorizontalLines;
            // Horizontal lines and Y-value labels
            OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData((valueOfPart * noOfHorizontalLines).ToString(), 10, PADDING_TOP + 5) });
            for (int i = 1; i <= noOfHorizontalLines; i++)
{
  if (Grid)
                {
                    OnDrawGridLine(this, new DrawEventArgs<DoubleDrawingData>() { Data = new DoubleDrawingData(PADDING_LEFT, PADDING_TOP + (quarterHeight * i), WidthRequest, PADDING_TOP + (quarterHeight * i), 0) });
                }
                double currentValue = (valueOfPart * noOfHorizontalLines) - (valueOfPart * i);
                OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(currentValue.ToString(), 10, PADDING_TOP + (quarterHeight * i) + 5) });
            }
            
            OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(YTitle, 5, (quarterHeight * noOfHorizontalLines)/2+15) });

            return (float)valueOfPart * noOfHorizontalLines;
        }
        
         private void DrawLabels(double highestValue, double widthPerBar, DataPointCollection points)
        {
            int noOfBarSeries = Series.Count(s => s.Type == ChartType.Bar);
            if (noOfBarSeries == 0)
                noOfBarSeries = 1;
            double widthOfAllBars = noOfBarSeries * widthPerBar;
            double widthIterator = 2 + PADDING_LEFT;

            for (int i = 0; i < points.Count; i++)
            {
                OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(points[i].Label, (widthIterator + widthOfAllBars / 2) - (points[i].Label.Length * 4), HeightRequest + 25) });
                widthIterator += widthPerBar * noOfBarSeries + Spacing;
            }
           
            OnDrawText(this, new DrawEventArgs<TextDrawingData>() { Data = new TextDrawingData(XTitle, widthIterator/2, HeightRequest + 55) });
            
        }

//in android chartsurface.cs
        
        public ChartSurface(Context context, Chart chart, AndroidColor color, AndroidColor[] colors)
            : base(context)
        {
            SetWillNotDraw(false);

            Chart = chart;
            Paint = new Paint() { Color = color, StrokeWidth = 2 };
            Paint.TextSize = 20.0f;
            Colors = colors;
        }
```

 Using the above code the following graph gets generated. 
 
![Graph2] (http://52.77.35.210:83/Media/Default/images/githubimages/graph2.png)

Fig 2- Progress chart in the sales with X and Y axis labels


**To get this code readymade take the following steps:**

- Step 1-  Go to GitHub, Down load code using URL https://github.com/iWorkTech/XamarinFormsCharts
- Step 2-  Unzip the code and open the solution file in Visual Studio 
- Step 3 – Open tab < BarChartPage.xaml > code 
- Step 4 – Make changes shown in highlighted nodes of XAML. 
- Step 5 – Run the code  



## Method 2 –  C# code:

```
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
```
Using the above code the following graph gets generated. 
 
![Graph3] (http://52.77.35.210:83/Media/Default/images/githubimages/graph2.png)

Fig 3- Progress chart in the sales with X and Y axis labels


**To get this code readymade take the following steps:**

- Step 1-  Go to GitHub, Down load code using URL https://github.com/iWorkTech/XamarinFormsCharts
- Step 2-  Unzip the code and open the solution file in Visual Studio 
- Step 3 – Run the code  
