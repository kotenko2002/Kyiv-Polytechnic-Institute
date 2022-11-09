using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMax
{
    public partial class Game : Form
    {
        char[,] map = new char[Constants.mapSize, Constants.mapSize];
        Button[,] buttons;
        Image cross, zero;
        Label win, lose, draw;

        public Game()
        {
            InitializeComponent();

            cross = new Bitmap(new Bitmap(Constants.cross),
                new Size(Constants.cellSize - 15, Constants.cellSize - 15));
            zero = new Bitmap(new Bitmap(Constants.zero),
                new Size(Constants.cellSize - 15, Constants.cellSize - 15));

            Icon = new Icon(Constants.appIcon);

            Init();
        }
        public void Init()
        {
            map = new char[,]
            {
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '}
            };

            CreateMap();
        }

        public void CreateMap()
        {
            buttons = new Button[Constants.mapSize, Constants.mapSize];

            CreateLabels();

            for (int i = 0; i < Constants.mapSize; i++)
            {
                for (int j = 0; j < Constants.mapSize; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Location = new Point(j * Constants.cellSize, i * Constants.cellSize);
                    button.Size = new Size(Constants.cellSize, Constants.cellSize);
                    button.Click += new EventHandler(PlayerTurn);

                    Controls.Add(button);
                }
            }
        }
        public void CreateLabels()
        {
            lose = new Label();
            lose.Text = "YOU LOSE!";
            lose.ForeColor = Color.Red;
            lose.Font = new Font("Arial", 28, FontStyle.Bold, GraphicsUnit.Point, ((Byte)(0)));
            lose.Top = 900;
            lose.Left = 260;
            lose.AutoSize = true;
            Controls.Add(lose);
            lose.Visible = false;

            win = new Label();
            win.Text = "YOU WIN!";
            win.ForeColor = Color.Green;
            win.Font = new Font("Arial", 30F, FontStyle.Bold, GraphicsUnit.Point, ((Byte)(0)));
            win.Top = 900;
            win.Left = 270;
            win.AutoSize = true;
            win.Visible = false;
            Controls.Add(win);

            draw = new Label();
            draw.Text = "DRAW!";
            draw.ForeColor = Color.Orange;
            draw.Font = new Font("Arial", 30F, FontStyle.Bold, GraphicsUnit.Point, ((Byte)(0)));
            draw.Top = 900;
            draw.Left = 320;
            draw.AutoSize = true;
            draw.Visible = false;
            Controls.Add(draw);
        }

        public void PlayerTurn(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;

            if (map[pressedButton.Location.Y / Constants.cellSize, pressedButton.Location.X / Constants.cellSize] == ' ')
            {
                map[pressedButton.Location.Y / Constants.cellSize, pressedButton.Location.X / Constants.cellSize] = 'X';
                pressedButton.Image = cross;
                Update();

                if (!GameOver('X'))
                {
                    ComputerTurnToPut();
                    GameOver('O');
                }
            }
        }
        public void ComputerTurnToPut()
        {
            int depth = 0;
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    if (map[i, j] == ' ')
                        depth++;

            map = Algorithm.NegaMax(map, depth, 1).Item1;
            for (int i = 0; i < Constants.mapSize; i++)
            {
                for (int j = 0; j < Constants.mapSize; j++)
                {
                    if (map[i, j] == 'X')
                        buttons[i, j].Image = cross;
                    else if (map[i, j] == 'O')
                        buttons[i, j].Image = zero;
                    else
                        buttons[i, j].Image = null;
                }
            }
            Update();
        }
        public bool GameOver(char symbol)
        {
            bool haveWinner = Additional.CheckWinner(map, symbol);
            bool haveDraw = Additional.CheckDraw(map);

            if(haveWinner || haveDraw)
            {
                for (int i = 0; i < Constants.mapSize; i++)
                    for (int j = 0; j < Constants.mapSize; j++)
                        buttons[i, j].Enabled = false;

                Height += 80;
            }
            if (haveWinner)
            {
                if (symbol == 'X')
                    win.Visible = true;
                if (symbol == 'O')
                    lose.Visible = true;
            }
            if (haveDraw)
                draw.Visible = true;

            return haveWinner || haveDraw;
        }
    }
}