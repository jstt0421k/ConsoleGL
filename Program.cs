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
            ConsoleGL.v_sys_screenLengthX = 600;
            ConsoleGL.v_sys_screenLengthY = 350;
            ConsoleGL.clear();
            int[] v_sys_corA = { 50, 50 };
            int[] v_sys_corB = { 200, 50 };
            // int[] v_sys_corC = { 200, 200 };
            // int[] v_sys_corD = { 50, 200 };
            // ConsoleGL.drawRect(v_sys_corA.ToList(), v_sys_corB.ToList(), v_sys_corC.ToList(), v_sys_corD.ToList());
            // parabolicMotion();
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
            consolePong();
            // clock(); -> Fuck dis shit
            // cube();
            /*
            Console.WriteLine("ConsoleGL() >> DEBUG_1");
            ConsoleGL.drawLine(v_sys_corA.ToList(), v_sys_corB.ToList(), ConsoleColor.Red);
            ConsoleGL.render();
            Console.WriteLine("ConsoleGL() >> DEVUG_2");
            */
            Console.ReadKey(true);
        }

        public static void cube()
        {
            int[] v_cube_corA = { 50, 100 };
            int[] v_cube_corB = { 75, 150 };
            ConsoleGL.v_sys_screenLengthX = 401;
            ConsoleGL.v_sys_screenLengthY = 301;
            ConsoleGL.clear();
            ConsoleGL.drawCube(v_cube_corA.ToList(), v_cube_corB.ToList());
            ConsoleGL.render();
        }

        public static void consolePong()
        {
            bool gameWin = false;
            int playerObjY = 150;
            int ballObjX = 300;
            int ballObjY = 150;
            int ballObjVx = 10;
            int ballObjVy = 7;
            while (gameWin == false)
            {
                ConsoleGL.clear();
                if (Console.KeyAvailable == true)
                {
                    if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                    {
                        if (playerObjY - 50 > 5)
                        {
                            playerObjY -= 6;
                        }
                    }
                    else
                    {
                        if (playerObjY + 50 < 295)
                        {
                            playerObjY += 6;
                        }
                    }
                }
                int[] v_consolePong_corA = { 600 - 40, playerObjY - 50 };
                int[] v_consolePong_corB = { 600 - 20, playerObjY - 50 };
                int[] v_consolePong_corC = { 600 - 20, playerObjY + 50 };
                int[] v_consolePong_corD = { 600 - 40, playerObjY + 50 };
                ConsoleGL.drawSquare(v_consolePong_corA.ToList(), 20, 100, v_drawSquare_fill: true);
                // ConsoleGL.drawRect(v_consolePong_corA.ToList(), v_consolePong_corB.ToList(), v_consolePong_corC.ToList(), v_consolePong_corD.ToList());
                int[] v_consolePong_ccorA = { 20, ballObjY + 50 };
                int[] v_consolePong_ccorB = { 40, ballObjY + 50 };
                int[] v_consolePong_ccorC = { 40, ballObjY - 50 };
                int[] v_consolePong_ccorD = { 20, ballObjY - 50 }; 
                if (ballObjY + 50 > 295)
                {
                    v_consolePong_ccorA[1] = 295;
                    v_consolePong_ccorB[1] = 295;
                    v_consolePong_ccorC[1] = 195;
                    v_consolePong_ccorD[1] = 195;
                }
                else if (ballObjY - 50 < 5)
                {
                    v_consolePong_ccorA[1] = 5;
                    v_consolePong_ccorB[1] = 5;
                    v_consolePong_ccorC[1] = 105;
                    v_consolePong_ccorD[1] = 105;
                }
                ConsoleGL.drawSquare(v_consolePong_ccorD.ToList(), 20, 100, v_drawSquare_fill: true);
                // ConsoleGL.drawRect(v_consolePong_ccorA.ToList(), v_consolePong_ccorB.ToList(), v_consolePong_ccorC.ToList(), v_consolePong_ccorD.ToList());
                ballObjX += ballObjVx;
                ballObjY += ballObjVy;
                int[] v_consolePong_center = { ballObjX, ballObjY };
                ConsoleGL.drawCircle(v_consolePong_center.ToList(), 9);
                int[] v_consolePong_vCorA = { ballObjX + 10, ballObjY + 10 };
                /*
                int[] v_consolePong_vCorB = { ballObjX + 10, ballObjY - 10 };
                int[] v_consolePong_vCorC = { ballObjX - 10, ballObjY - 10 };
                int[] v_consolePong_vCorD = { ballObjX - 10, ballObjY + 10 };
                ConsoleGL.drawRect(v_consolePong_vCorA.ToList(), v_consolePong_vCorB.ToList(), v_consolePong_vCorC.ToList(), v_consolePong_vCorD.ToList());
                */
                if (ballObjY + 10 > 295 || ballObjY - 10 < 5) {
                    ballObjVy = ballObjVy * (-1);
                }
                if (ballObjX + 5 > 595 - 40 && playerObjY - 50 < ballObjY && ballObjY < playerObjY + 50)
                {
                    ballObjVx = ballObjVx * (-1);
                }
                if (ballObjX - 5 < 5 + 40)
                {
                    ballObjVx = ballObjVx * (-1);
                }
                // Add x direction collision
                int[] v_consolePong_lineStart = { 300, 0 };
                int[] v_consolePong_lineEnd = { 300, 300 };
                ConsoleGL.drawLine(v_consolePong_lineStart.ToList(), v_consolePong_lineEnd.ToList());
                Console.Clear();
                ConsoleGL.render();
                Thread.Sleep(10);
                if (ballObjX + 10 > 595 || ballObjX - 10 < 5)
                {
                    gameWin = true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleGL.render();
            Console.WriteLine("Game Ended!");
        }

        public static void clock()
        {
            // Fuck dis shit
            int v_clock_R = 350 / 2;
            int v_clock_rS = 300 / 2;
            ConsoleGL.v_sys_screenLengthX = v_clock_R * 2 + 40;
            ConsoleGL.v_sys_screenLengthY = v_clock_R * 2 + 40;
            int[] v_clock_center = { v_clock_R + 20, v_clock_R + 20 };
            ConsoleGL.drawCircle(v_clock_center.ToList(), v_clock_R);
            int v_clock_t = 0;
            int v_clock_theta = 0;
            int[] v_clock_lineEnd = { 0, 0 };
            while (true)
            {
                v_clock_theta = (v_clock_t * 6) % 360;
                if (0 <= v_clock_theta && v_clock_theta < 90)
                {
                    v_clock_lineEnd[0] = (int) Math.Floor(v_clock_R + 20 + v_clock_rS * Math.Sin(v_clock_theta * Math.PI / 180));
                    v_clock_lineEnd[1] = (int) Math.Floor(v_clock_R + 20 - v_clock_rS * Math.Cos(v_clock_theta * Math.PI / 180));
                }
                else if (90 <= v_clock_theta && v_clock_theta < 180)
                {
                    v_clock_lineEnd[0] = (int) Math.Floor(v_clock_R + 20 + v_clock_rS * Math.Cos((v_clock_theta - 90) * Math.PI / 180));
                    v_clock_lineEnd[1] = (int) Math.Floor(v_clock_R + 20 - (-1) * v_clock_rS * Math.Sin((v_clock_theta - 90) * Math.PI / 180));
                }
                else if (180 <= v_clock_theta && v_clock_theta < 270)
                {
                    v_clock_lineEnd[0] = (int) Math.Floor(v_clock_R + 20 + (-1) * v_clock_rS * Math.Sin((v_clock_theta - 180) * Math.PI / 180));
                    v_clock_lineEnd[1] = (int) Math.Floor(v_clock_R + 20 - (-1) * v_clock_rS * Math.Cos((v_clock_theta - 180) * Math.PI / 180));
                }
                else
                {
                    v_clock_lineEnd[0] = (int) Math.Floor(v_clock_R + 20 + (-1) * v_clock_rS * Math.Cos((v_clock_theta - 270) * Math.PI / 180));
                    v_clock_lineEnd[1] = (int) Math.Floor(v_clock_R + 20 - v_clock_rS * Math.Sin((v_clock_theta - 270) * Math.PI / 180));
                }
                ConsoleGL.drawCircle(v_clock_center.ToList(), v_clock_R);
                ConsoleGL.drawLine(v_clock_center.ToList(), v_clock_lineEnd.ToList());
                ConsoleGL.render();
                Console.WriteLine(v_clock_lineEnd[0]);
                Console.WriteLine(v_clock_lineEnd[1]);
                Thread.Sleep(1000);
                ConsoleGL.clear();
                Console.Clear();
                v_clock_t += 1;
            }
        }

        public static void parabolicMotion()
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

    // Actual ConsoleGL Library
    public class ConsoleGL
    {
        ConsoleGLFunctions CGLF = new ConsoleGLFunctions();
        public static List<List<string>> v_sys_coordinatePlane = new List<List<string>>();
        public static List<List<ConsoleColor>> v_sys_color = new List<List<ConsoleColor>>();
        public static int v_sys_screenLengthX;
        public static int v_sys_screenLengthY;

        public static void render()
        {
            for (int v_printCoord_lv1 = 0; v_printCoord_lv1 < v_sys_coordinatePlane.Count; v_printCoord_lv1++)
            {
                for (int v_printCoord_lv2 = 0; v_printCoord_lv2 < v_sys_coordinatePlane[0].Count; v_printCoord_lv2++)
                {
                    Console.ForegroundColor = v_sys_color[v_printCoord_lv1][v_printCoord_lv2];
                    Console.Write(v_sys_coordinatePlane[v_printCoord_lv1][v_printCoord_lv2]);
                }
                Console.Write("\n");
            }
        }

        public static void clear()
        {
            v_sys_coordinatePlane.Clear();
            v_sys_color.Clear();
            List<string> v_sys_cL = new List<string>();
            List<ConsoleColor> v_sys_c = new List<ConsoleColor>();
            for (int v_sys_lv3 = 0; v_sys_lv3 < v_sys_screenLengthX; v_sys_lv3++)
            {
                v_sys_cL.Add("##");
                v_sys_c.Add(ConsoleColor.White);
            }
            v_sys_coordinatePlane.Add(v_sys_cL);
            for (int v_sys_lv1 = 1; v_sys_lv1 < v_sys_screenLengthY - 1; v_sys_lv1++)
            {
                List<string> v_sys_xPlotList = new List<string>();
                List<ConsoleColor> v_sys_xC = new List<ConsoleColor>();
                v_sys_xPlotList.Add("##");
                v_sys_xC.Add(ConsoleColor.White);
                for (int v_sys_lv2 = 1; v_sys_lv2 < v_sys_screenLengthX - 1; v_sys_lv2++)
                {
                    v_sys_xPlotList.Add("  ");
                    v_sys_xC.Add(ConsoleColor.White);
                }
                v_sys_xPlotList.Add("##");
                v_sys_xC.Add(ConsoleColor.White);
                v_sys_coordinatePlane.Add(v_sys_xPlotList);
                v_sys_color.Add(v_sys_xC);
            }
            v_sys_coordinatePlane.Add(v_sys_cL);
            v_sys_color.Add(v_sys_c);
            return;
        }

        public static void drawLine(List<int> v_drawLine_start, List<int> v_drawLine_end, ConsoleColor v_drawLine_color = ConsoleColor.White)
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
                            v_sys_color[v_drawLine_functionCoord[1]][v_drawLine_functionCoord[0]] = v_drawLine_color;
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
                        v_sys_color[v_drawLine_lv2 + ConsoleGLFunctions.getMin(v_drawLine_tL1)][v_drawLine_start[0]] = v_drawLine_color;
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

        public static void drawSquare(List<int> v_drawSqare_cor, int v_drawSquare_width, int v_drawSqare_height, bool v_drawSquare_fill = false)
        {
            int[] v_drawSquare_corA = v_drawSqare_cor.ToArray();
            int[] v_drawSquare_corB = { v_drawSquare_corA[0] + v_drawSquare_width, v_drawSquare_corA[1] + v_drawSqare_height };
            int[] v_drawSquare_corC = { v_drawSquare_corA[0] + v_drawSquare_width, v_drawSquare_corA[1] };
            int[] v_drawSquare_corD = { v_drawSquare_corA[0], v_drawSquare_corA[1] + v_drawSqare_height };
            drawRect(v_drawSquare_corA.ToList(), v_drawSquare_corB.ToList(), v_drawSquare_corC.ToList(), v_drawSquare_corD.ToList());
            if (v_drawSquare_fill == true)
            {
                for (int v_drawSquare_lv1 = 0; v_drawSquare_lv1 < v_drawSquare_width / 2; v_drawSquare_lv1++)
                {
                    v_drawSquare_corA[0] += 1;
                    v_drawSquare_corB[0] -= 1;
                    v_drawSquare_corC[0] -= 1;
                    v_drawSquare_corD[0] += 1;
                    drawRect(v_drawSquare_corA.ToList(), v_drawSquare_corB.ToList(), v_drawSquare_corC.ToList(), v_drawSquare_corD.ToList());
                }
            }
        }
        /*
        public static void drawPolygon(List<int> v_drawPolygon_center, int v_drawPolygon_sides, int v_drawPolygon_radius)
        {

        }*/

        public static void drawCube(List<int> v_drawCube_corA, List<int> v_drawCube_corB)
        {
            int[] v_drawCube_corC = { v_drawCube_corB[0] - v_drawCube_corB[1] + v_drawCube_corA[1], v_drawCube_corB[0] + v_drawCube_corB[1] - v_drawCube_corA[0] };
            int[] v_drawCube_corD = { v_drawCube_corA[0] + v_drawCube_corA[1] - v_drawCube_corB[1], v_drawCube_corA[1] + v_drawCube_corB[0] - v_drawCube_corA[0] };
            drawRect(v_drawCube_corA, v_drawCube_corB, v_drawCube_corC.ToList(), v_drawCube_corD.ToList());
        }

        //public static void addColor()
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