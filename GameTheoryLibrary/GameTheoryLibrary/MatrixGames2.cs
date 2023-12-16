namespace GameTheoryLibrary;

using System;
using System.Runtime.InteropServices;
using Python.Runtime;


public static partial class MatrixGameEvaluator
{
    public static void BestResponseValueFunction(Matrix utilityMatrix, double stepSize=0.01)
    {
        if (stepSize < 0 || stepSize > 1)
            throw new ArgumentException("stepSize in range (0,1]");

        double start = 0;
        double end = 1;

        int numberOfSteps = (int)Math.Ceiling((end - start) / stepSize);
        
        double[] steps = Enumerable.Range(0, numberOfSteps+1).Select(i => start + i * stepSize).ToArray();
        double[] values = new double[numberOfSteps+1];

        for (int i = 0; i < numberOfSteps+1; i++)
        {
            RowStrategy row = new double[] { steps[i], 1 - steps[i] };
            var br = GetBestResponse(-utilityMatrix, row);

            (double rowVal, double colVal) = EvaluateStrategies(utilityMatrix, row, br);
            values[i] = rowVal;
        }

        Scatter(steps, values);
    }

    public static void Scatter(double[] xAxis, double[] yAxis)
    {
        // Set the Python DLL path
        string pythonDllPath = @"C:\Users\eigle\AppData\Local\Programs\Python\Python310\python310.dll"; // Change this path to your Python DLL location

        Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);
        PythonEngine.Initialize();

        //PythonEngine.Initialize();
        using (Py.GIL())
        {
            dynamic matplotlib = Py.Import("matplotlib.pyplot");

            // Example data
            dynamic x = xAxis;
            dynamic y = yAxis;

            // Plotting
            matplotlib.scatter(x, y);
            matplotlib.xlabel("Probability");
            matplotlib.ylabel("Value");
            matplotlib.title("Best Response Function Value");

            // Show the plot
            matplotlib.show();
        }
    }

    public static void Scatter(double[] yAxis)
    {
        double[] xAxis = Enumerable.Range(1, yAxis.Length).Select(x => (double)x).ToArray();
        Scatter(xAxis, yAxis);
    }

    public static void Plot(double[] xAxis, double[] yAxis)
    {
        // Set the Python DLL path
        string pythonDllPath = @"C:\Users\eigle\AppData\Local\Programs\Python\Python310\python310.dll"; // Change this path to your Python DLL location

        Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);
        PythonEngine.Initialize();

        //PythonEngine.Initialize();
        using (Py.GIL())
        {
            dynamic matplotlib = Py.Import("matplotlib.pyplot");

            // Example data
            dynamic x = xAxis;
            dynamic y = yAxis;

            // Plotting
            matplotlib.plot(x, y);
            matplotlib.xlabel("Probability");
            matplotlib.ylabel("Value");
            matplotlib.title("Best Response Function Value");

            // Show the plot
            matplotlib.show();
        }
    }

    public static void Plot(double[] yAxis)
    {
        double[] xAxis = Enumerable.Range(1, yAxis.Length).Select(x => (double)x).ToArray();
        Plot(xAxis, yAxis);
    }
}
