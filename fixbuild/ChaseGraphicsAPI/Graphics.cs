﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System;
using fixbuild.ChaseGraphicsAPI;
namespace fixbuild.ChaseGraphicsAPI
{

    class Graphics
    {
        public static bool THE;
        private Canvas canvas;
        private Pen pen;
        private MouseState mouseState;
        private UInt32 px, py;
        private List<Tuple<Sys.Graphics.Point, Color>> savedPixels;

        public Graphics()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Black);
            pen = new Pen(Color.White);
            mouseState = MouseState.None;
            px = 3;
            py = 3;
            savedPixels = new List<Tuple<Sys.Graphics.Point, Color>>();
            MouseManager.ScreenHeight = (UInt32)canvas.Mode.Rows;
            MouseManager.ScreenWidth = (UInt32)canvas.Mode.Columns;
            Button(50, 0, 0, pen);

            if (THE == true)
            {
                for (int i = 0; i <= 350; i++)
                {
                    canvas.DrawRectangle(pen, i, i, i, i);
                    pen.Color = Color.Blue;
                }
            }
            pen.Color = Color.White;
            }
        public void Button(int size, int x, int y, Pen draw)
        {
            for (int i = 0; i <= size; i++)
            {
                canvas.DrawRectangle(draw, x, y, i, i);
            }
        }

            public void MouseHandler()
        {

            px = MouseManager.X;
            py = MouseManager.Y;
            mouseState = MouseManager.MouseState;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+2),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+2),
            };
            if (mouseState == MouseState.Middle && py <= 50 && py <= 50)
            {
                pen.Color = Color.Red;
            } else
            {
                pen.Color = Color.White;
            }
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
            }
            
                        
            pen.Color = Color.White;
        }
        }
    }

