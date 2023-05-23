using mestintBeadandov3.NemLopott;
namespace mestintBeadandov3
{
    public partial class Form1 : Form
    {
        Graphics g;
        int spaceHorisontal = 50;
        int spaceVertical = 50;
        int canWidth;
        int canHeight;
        int index = 0;





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        HorseFeastGraphSearch SearchAlg;
        List<NemLopottNode> solution;
        Pen redPen = new Pen(System.Drawing.Color.Red, 3);
        Pen blackPen = new Pen(System.Drawing.Color.Black, 3);
        Pen bluePen = new Pen(System.Drawing.Color.Blue, 3);

        public Form1()
        {
            InitializeComponent();
            canWidth = 300;
            canHeight = 300;
            //initialize a new red pen object
            g = canvas.CreateGraphics();
            SearchAlg = new DepthFirstHorseFeast();
            solution = SearchAlg.GetSolution(SearchAlg.Search()).ToList();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            PrintState(solution[index].State);
        }

        private void PrintState(HorseFeastState state)
        {
            for (int i = 0; i < state.currentColors.GetLength(0); i++)
            {
                for (int j = 0; j < state.currentColors.GetLength(1); j++)
                {
                    if (state.currentColors[j, i] == NemLopott.Color.Blue) g.DrawEllipse(bluePen, 150 * i, 150 * j, 150, 150);
                    else if (state.currentColors[j, i] == NemLopott.Color.Red) g.DrawEllipse(redPen, 150 * i, 150 * j, 150, 150);

                }
            }
            g.DrawLine(blackPen, 0, 150, 450, 150);
            g.DrawLine(blackPen, 150, 0, 150, 450);
            g.DrawLine(blackPen, 300, 0, 300, 450);
            g.DrawLine(blackPen, 0, 300, 450, 300);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (index < solution.Count - 1)
            {
                index++;
                canvas.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                canvas.Invalidate();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RedoSolution();

        }



        private void DepthFirst_CheckedChanged(object sender, EventArgs e)
        {
            RedoSolution();

        }

        private void Backtrack_CheckedChanged(object sender, EventArgs e)
        {
            RedoSolution();

        }

        private void RedoSolution()
        {
            if (SearchAlg == null)
            {
                throw new Exception("Search Algorithm is null");
            }
            if (DepthFirst.Checked)
            {
                SearchAlg = new DepthFirstHorseFeast();
            }
            else if (Backtrack.Checked)
            {
                SearchAlg = new BacktrackHorseFeast();
            }
            else if (BreadthFirst.Checked)
            {
                SearchAlg = new BreadthFirstHorseFeast();
            }
            else throw new Exception("Search Algorithm is not a valid type");
            SearchAlg = new DepthFirstHorseFeast();
            solution = SearchAlg.GetSolution(SearchAlg.Search()).ToList();
            index = 0;
            canvas.Invalidate();
        }
    }
}