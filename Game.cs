using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Game : Form
    {
        enum STATE
        {
            X,
            O,
            UNKNOWN,
        }

        private STATE state;
        private Button[,] buttons = new Button[3, 3];
        private int count;
        public Game()
        {
            InitializeComponent();
            state = STATE.X;
            buttons[0, 0] = button1;
            buttons[0, 1] = button4;
            buttons[0, 2] = button7;
            buttons[1, 0] = button2;
            buttons[1, 1] = button5;
            buttons[1, 2] = button8;
            buttons[2, 0] = button3;
            buttons[2, 1] = button6;
            buttons[2, 2] = button9;

            count = 0;
            textBoxXPlayer.BackColor = Color.Aqua;
            textBoxOPlayer.BackColor = Color.White;
        }

        void ChangeState()
        {
            if (state == STATE.X)
                state = STATE.O;
            else
                state = STATE.X;
        }

        bool CheckLine(Button button1, Button button2, Button button3)
        {
            if (button1.Text.Equals(state.ToString())  
                && button1.Text.Equals(button2.Text) 
                && button2.Text.Equals(button3.Text)
                && button3.Text.Equals(button1.Text))
                return true;
            else
                return false;
        }

        bool IsWin()
        {
            if (CheckLine(buttons[0, 0], buttons[0, 1], buttons[0, 2])
             || CheckLine(buttons[1, 0], buttons[1, 1], buttons[1, 2])
             || CheckLine(buttons[2, 0], buttons[2, 1], buttons[2, 2])
             || CheckLine(buttons[0, 0], buttons[1, 1], buttons[2, 2])
             || CheckLine(buttons[0, 2], buttons[1, 1], buttons[2, 0])
             || CheckLine(buttons[0, 0], buttons[1, 0], buttons[2, 0])
             || CheckLine(buttons[0, 1], buttons[1, 1], buttons[2, 1])
             || CheckLine(buttons[0, 2], buttons[1, 2], buttons[2, 2]))
                return true;
            else
                return false;
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (!button.Text.Equals(""))
                return;
            ++count;
            button.Text = state.ToString();
            if (IsWin())
            {
                string s = string.Format("Người chơi {0} thắng!!!", state.ToString());
                MessageBox.Show(s);
                buttonReset.PerformClick();
            }
            else if (count == 8)
            {
                MessageBox.Show("Hoà");
                buttonReset.PerformClick();
            }
            else
            {
                ChangeState();
                if (state == STATE.X)
                {
                    textBoxXPlayer.BackColor = Color.Aqua;
                    textBoxOPlayer.BackColor = Color.White;
                }
                else
                {
                    textBoxOPlayer.BackColor = Color.Aqua;
                    textBoxXPlayer.BackColor = Color.White;
                }
            }  
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            state = STATE.X;
            count = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    buttons[i, j].Text = "";
                }    
            }
            textBoxXPlayer.BackColor = Color.Aqua;
            textBoxOPlayer.BackColor = Color.White;
        }
    }
}
