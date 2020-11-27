using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace chiffrePuzzle
{
    public partial class Form1 : Form
    {
        private bool gameStarted;
        private bool gamePaused;
        private int count = 0;
        private int counter;
        private List<Button> listButtons;
        private List<string> currentListNumbers;

        public Form1()
        {
            InitializeComponent();
            gameStarted = false;
            gamePaused = false;
            listButtons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            // center the form
            this.CenterToScreen();
            this.MaximizeBox = false; //remove the maximize button
            this.MinimizeBox = false; //remove the minimize button
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //fixed window size
        }

        private List<string> GetRandomNumbers()
        {
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "" };
            Random random = new Random();
            List<string> randomNumbers = new List<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number;
                do
                {
                    number = random.Next(0, numbers.Length);
                }
                while (randomNumbers.Contains(numbers[number]));

                randomNumbers.Add(numbers[number]);
            }

            return randomNumbers;
        }

        private void hideButtonsText()
        {
            List<string> emptyList = new List<string>(Enumerable.Repeat("", listButtons.Count));
            setButtonsText(emptyList);
        }

        private void pauseGame()
        {
            if (!gamePaused)
            {
                saveCurrentNumbers();
                hideButtonsText();
                gamePaused = true;
                btnStart.Text = "Continue game";
                // pause the timer
                timer1.Stop();
                lblStatus.Text = "Paused";

            }
            else //continue the game
            {
                gamePaused = false;
                setButtonsText(currentListNumbers);
                btnStart.Text = "Pause game";
                // resume the timer
                timer1.Start();
                lblStatus.Text = "";
            }
        }

        private void startTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            TimeSpan t = TimeSpan.FromSeconds(counter);
            timer1.Start();
            gameStarted = true;
            lblTimer.Text = (t).ToString(@"mm\:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {

                timer1.Dispose();
                MessageBox.Show("Time is up!! Game over");
                btnStart.Text = "Restart";
                gameStarted = false;
            }
            TimeSpan t = TimeSpan.FromSeconds(counter);
            lblTimer.Text = t.ToString(@"mm\:ss");

        }

        private void setButtonsText(List<string> nNbs)
        {
            for (int i = 0; i < listButtons.Count; i++)
            {
                listButtons[i].Text = nNbs[i];
            }
        }

        private void saveCurrentNumbers()
        {
            for (int i = 0; i < listButtons.Count; i++)
            {
                currentListNumbers[i] = listButtons[i].Text;
            }
        }

        private void generateNumbers()
        {
            currentListNumbers = GetRandomNumbers();
            setButtonsText(currentListNumbers);
        }

        private void downAction()
        {
            count = 1;

            if (btn4.Text == "" && count == 1)
            {
                btn4.Text = btn1.Text;
                btn1.Text = "";
                count = count + 1;
            }
            if (btn5.Text == "" && count == 1)
            {
                btn5.Text = btn2.Text;
                btn2.Text = "";
                count = count + 1;
            }
            if (btn6.Text == "" && count == 1)
            {
                btn6.Text = btn3.Text;
                btn3.Text = "";
                count = count + 1;
            }
            if (btn7.Text == "" && count == 1)
            {
                btn7.Text = btn4.Text;
                btn4.Text = "";
                count = count + 1;
            }
            if (btn8.Text == "" && count == 1)
            {
                btn8.Text = btn5.Text;
                btn5.Text = "";
                count = count + 1;
            }
            if (btn9.Text == "" && count == 1)
            {
                btn9.Text = btn6.Text;
                btn6.Text = "";
                count = count + 1;
            }
            win();
        }

        private void upAction()
        {
            count = 1;
            if (btn1.Text == "" && count == 1)
            {
                btn1.Text = btn4.Text;
                btn4.Text = "";
                count = count + 1;
            }
            if (btn2.Text == "" && count == 1)
            {
                btn2.Text = btn5.Text;
                btn5.Text = "";
                count = count + 1;
            }
            if (btn3.Text == "" && count == 1)
            {
                btn3.Text = btn6.Text;
                btn6.Text = "";
                count = count + 1;
            }
            if (btn4.Text == "" && count == 1)
            {
                btn4.Text = btn7.Text;
                btn7.Text = "";
                count = count + 1;
            }
            if (btn5.Text == "" && count == 1)
            {
                btn5.Text = btn8.Text;
                btn8.Text = "";
                count = count + 1;
            }
            if (btn6.Text == "" && count == 1)
            {
                btn6.Text = btn9.Text;
                btn9.Text = "";
                count = count + 1;
            }
            win();
        }

        private void rightAction()
        {
            count = 1;
            if (btn2.Text == "" && count == 1)
            {
                btn2.Text = btn1.Text;
                btn1.Text = "";
                count = count + 1;
            }
            if (btn5.Text == "" && count == 1)
            {
                btn5.Text = btn4.Text;
                btn4.Text = "";
                count = count + 1;
            }
            if (btn8.Text == "" && count == 1)
            {
                btn8.Text = btn7.Text;
                btn7.Text = "";
                count = count + 1;
            }
            if (btn3.Text == "" && count == 1)
            {
                btn3.Text = btn2.Text;
                btn2.Text = "";
                count = count + 1;
            }
            if (btn6.Text == "" && count == 1)
            {
                btn6.Text = btn5.Text;
                btn5.Text = "";
                count = count + 1;
            }
            if (btn9.Text == "" && count == 1)
            {
                btn9.Text = btn8.Text;
                btn8.Text = "";
                count = count + 1;
            }
            win();
        }

        private void leftAction()
        {
            count = 1;
            if (btn1.Text == "" && count == 1)
            {
                btn1.Text = btn2.Text;
                btn2.Text = "";
                count = count + 1;
            }
            if (btn2.Text == "" && count == 1)
            {
                btn2.Text = btn3.Text;
                btn3.Text = "";
                count = count + 1;
            }
            if (btn4.Text == "" && count == 1)
            {
                btn4.Text = btn5.Text;
                btn5.Text = "";
                count = count + 1;
            }
            if (btn5.Text == "" && count == 1)
            {
                btn5.Text = btn6.Text;
                btn6.Text = "";
                count = count + 1;
            }
            if (btn7.Text == "" && count == 1)
            {
                btn7.Text = btn8.Text;
                btn8.Text = "";
                count = count + 1;
            }
            if (btn8.Text == "" && count == 1)
            {
                btn8.Text = btn9.Text;
                btn9.Text = "";
                count = count + 1;
            }
            win();
        }

        private void win()
        {
            if (btn1.Text == "1" && btn2.Text == "2" && btn3.Text == "3" && btn4.Text == "4" && btn5.Text == "5" && btn6.Text == "6" && btn7.Text == "7" && btn8.Text == "8" && btn9.Text == "")
            {
                timer1.Dispose();
                gameStarted = false;
                MessageBox.Show("Congratulations!!! You Won ");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                counter = 60 * 4; // 4 Minutes
                generateNumbers();
                startTimer();
                gameStarted = true;
                btnStart.Text = "Pause game";
            }
            else //pause the game
            {
                pauseGame();
            }
        }

        private void btnPuzzleKeyDown(object sender, KeyEventArgs e)
        {
            if (!gamePaused && gameStarted)  // if the game has started and the game is NOT paused stop the arrow keys input
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        upAction();
                        break;
                    case Keys.Down:
                        downAction();
                        break;
                    case Keys.Left:
                        leftAction();
                        break;
                    case Keys.Right:
                        rightAction();
                        break;
                }
        }

        private void btnPuzzlePreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)//to handle the arrow keys
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

    }
}
