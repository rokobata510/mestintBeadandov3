using AICore;
namespace mestintBeadandov3.NemLopott
{
    internal class HorseFeastState : AbstractState, IOperatorHandler<int, int, int, int>, ICloneable
    {
        public mestintBeadandov3.NemLopott.Color[,] currentColors = new Color[3, 3]
        {
            { Color.Blue, Color.Blue, Color.Blue },
            { Color.Black, Color.Black, Color.Black },
            { Color.Red, Color.Red, Color.Red },
        };

        private Color[,] goalColors = new Color[3, 3]
        {
            { Color.Red, Color.Red, Color.Red },
            { Color.Black, Color.Black, Color.Black },
            { Color.Blue, Color.Blue, Color.Blue }
        };

        public override bool IsGoalState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentColors[i, j] != goalColors[i, j])
                        return false;
                }
            }
            return true;
        }



        public bool ApplyOperator(int fromX, int fromY, int toX, int toY)
        {
            if (!IsOperator(fromX, fromY, toX, toY)) return false;
            if (IsState())
            {
                //switch the two selected tiles in the currentColors array
                Color temp = currentColors[fromX, fromY];
                currentColors[fromX, fromY] = currentColors[toX, toY];
                currentColors[toX, toY] = temp;

                return true;
            }
            return false;
        }

        public bool IsOperator(int fromX, int fromY, int toX, int toY)
        {
            if (Math.Abs(fromX - toX) * Math.Abs(fromY - toY) != 2)
            {
                return false;
            }
            if(fromX < 0 || fromX > 2 || fromY < 0 || fromY > 2 || toX < 0 || toX > 2 || toY < 0 || toY > 2)
            {
                return false;
            }
            //check if the number of selected black cells is equal to one
            int black = 0;
            if (currentColors[fromX, fromY] == Color.Black)
                black++;
            if (currentColors[toX, toY] == Color.Black)
                black++;
            if (black == 1)
                return true;
            return false;
        }

        public override bool IsState()
        {
            //count the number of red, blue and black tiles. they should all be == 3
            int red = 0, blue = 0, black = 0;
            for (int i = 0; i < currentColors.GetLength(0); i++)
            {
                for (int j = 0; j < currentColors.GetLength(1); j++)
                {
                    if (currentColors[i, j] == Color.Red)
                        red++;
                    else if (currentColors[i, j] == Color.Blue)
                        blue++;
                    else if (currentColors[i, j] == Color.Black)
                        black++;
                }
            }
            return red == 3 && blue == 3 && black == 3;

        }


        public object Clone()
        {
            HorseFeastState clone = new HorseFeastState();
            clone.currentColors = (Color[,])this.currentColors.Clone();
            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            HorseFeastState other = (HorseFeastState)obj;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentColors[i, j] != other.currentColors[i, j])
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < currentColors.GetLength(0); i++)
            {
                for (int j = 0; j < currentColors.GetLength(1); j++)
                {
                    result += currentColors[i, j] + " ";
                }
                result += "\n";
            }

            return result;
        }




    }

}
