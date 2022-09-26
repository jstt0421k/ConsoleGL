// ConsoleGL - Console Graphics Library
// Developed by Joonsung Kim
// Ver 0.0.1

using System;
using System.IO;

namespace ConsoleGL
{
    public class Program
    {
        ConsoleGLFunctions CGLF = new ConsoleGLFunctions();
        ConsoleGL CGL = new ConsoleGL();
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("ConsoleGL() >> ConsoleGL is successfully loaded.");
            Console.WriteLine("\n");
            // loadActiveFunctions();
            ConsoleGL.v_sys_screenLengthX = 750;
            ConsoleGL.v_sys_screenLengthY = 460;
            ConsoleGL.clear();
            // int[] v_sys_corA = { 50, 50 };
            // int[] v_sys_corB = { 200, 50 };
            // int[] v_sys_corC = { 200, 200 };
            // int[] v_sys_corD = { 50, 200 };
            // ConsoleGL.drawRect(v_sys_corA.ToList(), v_sys_corB.ToList(), v_sys_corC.ToList(), v_sys_corD.ToList());
            gr_t1();
            /*
            Random v_sys_random = new Random();
            for (int v_sys_lv1 = 0; v_sys_lv1 < 2000; v_sys_lv1++)
            {
                int[] v_sys_centerA = { 150 + v_sys_random.Next(ConsoleGL.v_sys_screenLengthX - 300), 150 + v_sys_random.Next(ConsoleGL.v_sys_screenLengthY - 300) };
                ConsoleGL.drawCircle(v_sys_centerA.ToList(), 10 + v_sys_random.Next(140));
                Console.Clear();
                ConsoleGL.render();
                Thread.Sleep(50);
            }
            */
            Console.ReadKey(true);
        }

        public static void gr_t1()
        {
            int v_sys_rT = 1;
            int v_sys_rL = 27;
            int v_sys_rectL = 5;
            int v_sys_ln = 2;
            for (int v_sys_lv3 = 0; v_sys_lv3 < v_sys_ln; v_sys_lv3++)
            {
                int[] v_sys_corA = { 10 + v_sys_rL * 2 * v_sys_rectL * v_sys_lv3, 30 };

                for (int v_sys_lv1 = 0; v_sys_lv1 < v_sys_rL; v_sys_lv1++)
                {
                    int[] v_sys_corB = { v_sys_corA[0] + 20, v_sys_corA[1] };
                    int[] v_sys_corC = { v_sys_corA[0] + 20, v_sys_corA[1] + 20 };
                    int[] v_sys_corD = { v_sys_corA[0], v_sys_corA[1] + 20 };
                    ConsoleGL.drawRect(v_sys_corA.ToList(), v_sys_corB.ToList(), v_sys_corC.ToList(), v_sys_corD.ToList());
                    v_sys_corA[0] += v_sys_rectL;
                    v_sys_corA[1] += v_sys_lv1;
                    Console.Clear();
                    ConsoleGL.render();
                    Thread.Sleep(v_sys_rT);
                }
                for (int v_sys_lv1 = 0; v_sys_lv1 < v_sys_rL; v_sys_lv1++)
                {
                    int[] v_sys_corB = { v_sys_corA[0] + 20, v_sys_corA[1] };
                    int[] v_sys_corC = { v_sys_corA[0] + 20, v_sys_corA[1] + 20 };
                    int[] v_sys_corD = { v_sys_corA[0], v_sys_corA[1] + 20 };
                    ConsoleGL.drawRect(v_sys_corA.ToList(), v_sys_corB.ToList(), v_sys_corC.ToList(), v_sys_corD.ToList());
                    v_sys_corA[0] += v_sys_rectL;
                    v_sys_corA[1] -= (v_sys_rL - 1 - v_sys_lv1);
                    Console.Clear();
                    ConsoleGL.render();
                    Thread.Sleep(v_sys_rT);
                }
            }
        }
    }

    public class ConsoleGL
    {
        ConsoleGLFunctions CGLF = new ConsoleGLFunctions();
        public static List<List<string>> v_sys_coordinatePlane = new List<List<string>>();
        public static int v_sys_screenLengthX;
        public static int v_sys_screenLengthY;

        public static void render()
        {
            for (int v_printCoord_lv1 = 0; v_printCoord_lv1 < v_sys_coordinatePlane.Count; v_printCoord_lv1++)
            {
                for (int v_printCoord_lv2 = 0; v_printCoord_lv2 < v_sys_coordinatePlane[0].Count; v_printCoord_lv2++)
                {
                    Console.Write(v_sys_coordinatePlane[v_printCoord_lv1][v_printCoord_lv2]);
                }
                Console.Write("\n");
            }
        }

        public static void clear()
        {
            List<string> v_sys_cL = new List<string>();
            for (int v_sys_lv3 = 0; v_sys_lv3 < v_sys_screenLengthX; v_sys_lv3++)
            {
                v_sys_cL.Add("##");
            }
            v_sys_coordinatePlane.Add(v_sys_cL);
            for (int v_sys_lv1 = 1; v_sys_lv1 < v_sys_screenLengthY - 1; v_sys_lv1++)
            {
                List<string> v_sys_xPlotList = new List<string>();
                v_sys_xPlotList.Add("##");
                for (int v_sys_lv2 = 1; v_sys_lv2 < v_sys_screenLengthX - 1; v_sys_lv2++)
                {
                    v_sys_xPlotList.Add("  ");
                }
                v_sys_xPlotList.Add("##");
                v_sys_coordinatePlane.Add(v_sys_xPlotList);
            }
            v_sys_coordinatePlane.Add(v_sys_cL);
            return;
        }

        public static void drawLine(List<int> v_drawLine_start, List<int> v_drawLine_end)
        {
            if (v_drawLine_start[0] <= v_drawLine_end[0]) {
                if (v_drawLine_start[0] != v_drawLine_end[0])
                {
                    float v_drawLine_slope = (v_drawLine_start[1] - v_drawLine_end[1]) / (v_drawLine_start[0] - v_drawLine_end[0]);
                    float v_drawLine_yIntercept = v_drawLine_start[1] - v_drawLine_slope * v_drawLine_start[0];
                    for (int v_drawLine_lv1 = 0; v_drawLine_lv1 < Math.Abs(v_drawLine_start[0] - v_drawLine_end[0]); v_drawLine_lv1++)
                    {
                        List<int> v_drawLine_functionCoord = new List<int>();
                        v_drawLine_functionCoord.Add(v_drawLine_start[0] + v_drawLine_lv1);
                        v_drawLine_functionCoord.Add((int) Math.Floor((v_drawLine_start[0] + v_drawLine_lv1) * v_drawLine_slope + v_drawLine_yIntercept));
                        if (v_drawLine_functionCoord[1] < v_sys_coordinatePlane.Count && v_drawLine_functionCoord[0] < v_sys_coordinatePlane[0].Count)
                        {
                            v_sys_coordinatePlane[v_drawLine_functionCoord[1]][v_drawLine_functionCoord[0]] = "##";
                        }
                    }
                }
                else
                {
                    for (int v_drawLine_lv2 = 0; v_drawLine_lv2 < Math.Abs(v_drawLine_start[1] - v_drawLine_end[1]); v_drawLine_lv2++)
                    {
                        List<int> v_drawLine_tL1 = new List<int>();
                        v_drawLine_tL1.Add(v_drawLine_start[1]);
                        v_drawLine_tL1.Add(v_drawLine_end[1]);
                        v_sys_coordinatePlane[v_drawLine_lv2 + ConsoleGLFunctions.getMin(v_drawLine_tL1)][v_drawLine_start[0]] = "##";
                    }
                    return;
                }
            }
            else
            {
                drawLine(v_drawLine_end, v_drawLine_start);
            }
            return;
        }

        public static void drawPoint(List<int> v_drawPoint_coord)
        {
            v_sys_coordinatePlane[v_drawPoint_coord[1]][v_drawPoint_coord[0]] = "##";
        }

        public static void drawRect(List<int> v_drawRect_corA, List<int> v_drawRect_corB, List<int> v_drawRect_corC, List<int> v_drawRect_corD)
        {
            List<List<int>> v_drawRect_corList = new List<List<int>>() { v_drawRect_corA, v_drawRect_corB, v_drawRect_corC, v_drawRect_corD, v_drawRect_corA};
            for (int v_drawRect_lv1 = 0; v_drawRect_lv1 < 4; v_drawRect_lv1++)
            {
                drawLine(v_drawRect_corList[v_drawRect_lv1], v_drawRect_corList[v_drawRect_lv1 + 1]);
            }
            return;
        }
        public static void drawCircle(List<int> v_drawCircle_centerCoord, int v_drawCircle_radius)
        {
            for (int v_drawCircle_lv1 = v_drawCircle_centerCoord[0] - v_drawCircle_radius; v_drawCircle_lv1 <= v_drawCircle_centerCoord[0] + v_drawCircle_radius; v_drawCircle_lv1++)
            {
                int[] v_drawCircle_fLa = { v_drawCircle_lv1, (int) Math.Floor(v_drawCircle_centerCoord[1] + Math.Sqrt(Math.Pow(v_drawCircle_radius, 2) - Math.Pow(v_drawCircle_lv1 - v_drawCircle_centerCoord[0], 2))) };
                int[] v_drawCircle_fLb = { v_drawCircle_lv1, (int) Math.Floor(v_drawCircle_centerCoord[1] - Math.Sqrt(Math.Pow(v_drawCircle_radius, 2) - Math.Pow(v_drawCircle_lv1 - v_drawCircle_centerCoord[0], 2))) };
                drawPoint(v_drawCircle_fLa.ToList());
                drawPoint(v_drawCircle_fLb.ToList());
            }
        }
    }

    public class ConsoleGLFunctions
    {
        public static int getMin(List<int> v_getMin_input)
        {
            int v_getMin_tempReturnVal = v_getMin_input[0];
            for (int v_getMin_lv1 = 0; v_getMin_lv1 < v_getMin_input.Count; v_getMin_lv1++)
            {
                if (v_getMin_input[v_getMin_lv1] <= v_getMin_tempReturnVal)
                {
                    v_getMin_tempReturnVal = v_getMin_input[v_getMin_lv1];
                }
            }
            return v_getMin_tempReturnVal;
        }
    }
}