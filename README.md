#IWORKTECH and Xamarin.Forms 
[![N|Solid](http://www.iworktech.com/Themes/iWorkTheme/Content/iwork_logo.png)](https://nodesource.com/products/nsolid)
We have worked on Xamarin forms for the last several years. While working on different apps, we mustered hands on experience on the Xamarin platform and code that was share cross projects. We are sharing this code Xamarin developers and open source community to for free. 
This code is available for use on a “AS IS” BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND. 
This document is authored by members of IWORKTECH’s mobility team.  Please send all feedback and inquiries to info@iworktech.com. 

Introduction

In this document, we have several illustration with demo code. Developer should use this code as it is or with minimal changes. The aim of sharing is to improve the productivity of a Xamarin developer. 

1.	 Plot Bar and Line chart code
Objective: 

This code helps a Xamarin developer to embed a code in his/her code.  It allows plotting of a bar or a line chart quickly. On the graph, currently in the Xamarin.Form, we can’t change the font size and labels of the X- and Y- axis. This utility addresses these issues by allowing you to do make necessary changes. 

2.	Available on 

Android and iOS


 
 

 
  
  
   
    
    
    <charting:Chart.Series>

                <charting:Series
    Type="Bar"
    Color="Red">

                  <charting:Series.Points>

                    <charting:DataPoint
    Label="Jan"
    Value="25"
    />

                    <charting:DataPoint
    Label="Feb"
    Value="40"
    />

                    <charting:DataPoint
    Label="March"
    Value="45"
    />

                  </charting:Series.Points>

                </charting:Series>

                <charting:Series
    Type="Bar"
    Color="Blue">

                  <charting:Series.Points>

                    <charting:DataPoint
    Label="Jan"
    Value="30"
    />

                    <charting:DataPoint
    Label="Feb"
    Value="35"
    />

                    <charting:DataPoint
    Label="March"
    Value="40"
    />

                  </charting:Series.Points>

                </charting:Series>

              </charting:Chart.Series>

     

     

    

    
   
  
  
 
