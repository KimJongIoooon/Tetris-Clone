using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProofOfConcept
{
    public partial class Form1 : Form
    {
        Game game;



        public Form1()
        {
            InitializeComponent();
            game = new Game(DropTimer);
            game.FillFieldTest();
        }

        private void Button1_Click(object sender, EventArgs e)
        {


            UpdateGraphics();
        }

        private void UpdateGraphics()
        {
            pnlField.Invalidate();
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            game.Tick();
            lblTest.Enabled = !lblTest.Enabled;
            UpdateGraphics();
        }

        private int CovertPixelsToPoints(float pixels)
        {
            Graphics g = CreateGraphics();
            float fBlockSizePoint = pixels * 72 / g.DpiX;
            g.Dispose();
            return Convert.ToInt32(fBlockSizePoint);
        }

        private void PnlField_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            
            int blockSizePixels = 20;
            
            if (game.Started)
            {
                //draw field
                for (int y = 0; y < 24; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (game.Field[x, y].Filled)
                        {
                            Brush brush = ColorToBrush(game.Field[x, y].Color);
                            graphics.FillRectangle(brush, CovertPixelsToPoints(x * blockSizePixels), CovertPixelsToPoints(y * blockSizePixels), CovertPixelsToPoints(blockSizePixels), CovertPixelsToPoints(blockSizePixels));
                        } 

                    }
                }
                //draw shape
                foreach (Point point in game._activeTetramino.Points)
                {
                    int x = game._activeTetramino.X + point.X;
                    int y = game._activeTetramino.Y + point.Y;
                    if(x>=0 && y >= 0)
                    {
                        Brush brush = ColorToBrush(game.Field[x, y].Color);
                        graphics.FillRectangle(brush, CovertPixelsToPoints(x * blockSizePixels), CovertPixelsToPoints(y * blockSizePixels), CovertPixelsToPoints(blockSizePixels), CovertPixelsToPoints(blockSizePixels));
                    }
                }
                
            }
        }

        Brush ColorToBrush(Colors Color)
        {
            Brush brush = Brushes.White;
            switch (Color)
            {
                case Colors.Blue:
                    brush = Brushes.Blue;
                    break;
                case Colors.Turquoise:
                    brush = Brushes.Turquoise;
                    break;
                case Colors.Yellow:
                    brush = Brushes.Yellow;
                    break;
                case Colors.Red:
                    brush = Brushes.Red;
                    break;
                case Colors.Orange:
                    brush = Brushes.Orange;
                    break;
                case Colors.Purple:
                    brush = Brushes.Purple;
                    break;
                case Colors.Green:
                    brush = Brushes.Green;
                    break;
            }
            return brush;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                game.Move(Directions.Right);
                UpdateGraphics();
            }
            if (e.KeyCode == Keys.A)
            {
                game.Move(Directions.Left);
                UpdateGraphics();
            }
            if (e.KeyCode == Keys.Space)
            {
                game.Drop();
                UpdateGraphics();
            }
            if (e.KeyCode == Keys.Enter)
            {
                game.Start();
                UpdateGraphics();
            }
            if (e.KeyCode == Keys.Return)
            {
                game.Stop();
            }
            if(e.KeyCode == Keys.S)
            {
                game.Rotate(Directions.Left);
                UpdateGraphics();
            }
            if(e.KeyCode == Keys.W)
            {
                game.Rotate(Directions.Right);
                UpdateGraphics();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Start game and start or restart timer.

            if (!game.Started)
            {

                TickTimer.Start();

            }
            game.Start();
            
        }

        private void DropTimer_Tick(object sender, EventArgs e)
        {
            game.Drop();
        }
    }
}
