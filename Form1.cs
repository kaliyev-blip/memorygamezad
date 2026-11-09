namespace memorygamezad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] boxes = new PictureBox[8];
        Color[] colors = new Color[8];
        bool[] done = new bool[8];
        int first = -1, second = -1;
        int score = 0, openCount = 0;
        bool wait = false;

        private void NewGame()
        {
            Random R = new Random();
            colors[0] = Color.Red;
            colors[1] = Color.Red;
            colors[2] = Color.Blue;
            colors[3] = Color.Blue;
            colors[4] = Color.Green;
            colors[5] = Color.Green;
            colors[6] = Color.Yellow;
            colors[7] = Color.Yellow;

            for (int i = 0; i < 8; i++)
            {
                int j = R.Next(8);
                Color t = colors[i];
                colors[i] = colors[j];
                colors[j] = t;
            }

            for (int i = 0; i < 8; i++)
            {
                boxes[i].BackColor = Color.Gainsboro;
                done[i] = false;
            }

            score = 0;
            openCount = 0;
            first = -1;
            second = -1;
            wait = false;
            timer1.Stop();
            label2.Text = "0";
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            boxes[0] = pictureBox1;
            boxes[1] = pictureBox2;
            boxes[2] = pictureBox3;
            boxes[3] = pictureBox4;
            boxes[4] = pictureBox5;
            boxes[5] = pictureBox6;
            boxes[6] = pictureBox7;
            boxes[7] = pictureBox8;

            pictureBox9.ImageLocation = "C:\\Users\\STUDENT.STD\\Downloads\\true.png";
            pictureBox10.ImageLocation = "C:\\Users\\STUDENT.STD\\Downloads\\false.png";

            NewGame();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (wait == true)
            {
                return;
            }

            PictureBox p = (PictureBox)sender;
            int i = Array.IndexOf(boxes, p);

            if (done[i] == true || i == first)
            {
                return;
            }

            p.BackColor = colors[i];

            if (first == -1)
            {
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                first = i;
            }
            else
            {
                second = i;

                if (colors[first] == colors[second])
                {
                    score++;
                    label2.Text = score.ToString();
                    done[first] = true;
                    done[second] = true;
                    openCount += 2;
                    pictureBox9.Visible = true;
                    first = -1;
                    second = -1;

                    if (openCount == 8)
                    {
                        MessageBox.Show("Oyun bitdi, xalınız: " + score);
                    }
                }
                else
                {
                    pictureBox10.Visible = true;
                    wait = true;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            boxes[first].BackColor = Color.Gainsboro;
            boxes[second].BackColor = Color.Gainsboro;
            first = -1;
            second = -1;
            wait = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Çıxmaq istəyirsiniz?", "sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}