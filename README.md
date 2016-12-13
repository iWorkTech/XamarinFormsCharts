# IWORKTECH and Xamarin.Forms 
We have worked on Xamarin forms for the last several years. While working on different apps, we mustered hands on experience on the Xamarin platform and code that was share cross projects. We are sharing this code Xamarin developers and open source community to for free. 
This code is available for use on a “AS IS” BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND. 
This document is authored by members of IWORKTECH’s mobility team.  Please send all feedback and inquiries to info@iworktech.com. 
 
### Introduction

In this document, we have several illustration with demo code. Developer should use this code as it is or with minimal changes. The aim of sharing is to improve the productivity of a Xamarin developer. 

#### Plot Bar and Line chart code

##### Objective: 
This code helps a Xamarin developer to embed a code in his/her code.  It allows plotting of a bar or a line chart quickly. On the graph, currently in the Xamarin.Form, we can’t change the font size and labels of the X- and Y- axis. This utility addresses these issues by allowing you to do make necessary changes.  

##### Available on 

#### Why do I need it? 
As a developer, I need to add additional features like, 
- labeling of X- and Y- axis. 
- change the font size. 

##### Without using IWORKTECH’s utility code

In a Xamarin form, normally using the following code one can provide a bar or line chart functionalities/features. 
```sh
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

#### Using IWORKTECH’s utility code
As a developer, I want to add labels to the X and Y coordinates. 

I can achieve by using two methods. These are :
- Method 1 – change in XMAL (Explained in the document) 
- Method 2 – change in C#

**Brief:**

Using the highlighter code, one can plot the bar chart is displayed as in Fig 2. The bar chart has now:
•	X - Title
•	Y – Title

```
  <charting:Chart x:Name="MonthlySalesChart" 
                        Spacing="50"
                        WidthRequest="600"
                        HeightRequest="600"
                        Color="Purple"
                        [XTitle="Year"]
                        [YTitle="Progress]
                        VerticalOptions="FillAndExpand">
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
        </charting:Chart>
```



