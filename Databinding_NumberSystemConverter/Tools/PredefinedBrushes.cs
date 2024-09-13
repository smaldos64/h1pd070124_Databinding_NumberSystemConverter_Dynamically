using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Reflection;
using System.Diagnostics.Metrics;

namespace Databinding_NumberSystemConverter.Tools
{
  public static class PredefinedBrushes
  {
    private static List<PredefinedBrush> list = new List<PredefinedBrush>();

    static PredefinedBrushes()  
    {  
      Type type = typeof(Brushes);  
      foreach (PropertyInfo info in type.GetProperties())  
      {  
        MethodInfo method = info.GetGetMethod();  
        if (method.IsStatic)  
        {  
          object brush = method.Invoke(null, null);  
          list.Add( new PredefinedBrush(info.Name,(Brush)brush));  
        }  
      }  
    }

    public static int GetIndex(string Name)
    {
        for (int Counter = 0; Counter < list.Count; ++Counter)
        {
            if (list[Counter].BrushName.Equals(Name))
            {
                return Counter;
            }
        }
        return -1;
    }

    public static PredefinedBrush GetBrush(string Name)
    {
        foreach (PredefinedBrush brush in list)
        {
            if (brush.BrushName.Equals(Name))
            {
                return brush;
            }
        }
        return null;
    }

    public static PredefinedBrush GetBrush(Brush Color)
    {
        foreach (PredefinedBrush brush in list)
        {
            if (brush.BrushColor.ToString().Equals(Color.ToString()))
            {
                return brush;
            }
        }
        return null;
    }

    public static List<PredefinedBrush> Brushes  
    {  
        get { return list; }
    } 
  }

  public class PredefinedBrush
  {
    public string BrushName { get; private set; }
    public Brush BrushColor { get; private set; }

    public PredefinedBrush(string name, Brush brush)
    {
      BrushColor = brush;
      BrushName = name;
    }

    public override string ToString()
    {
        return (BrushColor.ToString());
    }
  }
}
