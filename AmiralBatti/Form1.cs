using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmiralBatti
{
    public partial class Form1 : Form
    {
        int basma = 0;
        int birlerBasma = 0;
        int[] shipLengths = { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4 };
        private const int ROWS = 15;
        private const int COLS = 15;
        private int[,] gameBoard = new int[ROWS, COLS];

        private int[] YatayDikey = new int[10];
        private int[] Satir = new int[10];
        private int[] Sutun = new int[10];
        int x = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
            PlaceShips();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeButtons()
        {
            int buttonSize = 40;
            int padding = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Button button = new Button();
                    button.TabStop = false;
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Top = i * (buttonSize + padding);
                    button.Left = j * (buttonSize + padding);
                    button.Tag = $"{i},{j}"; // Her butona bir etiket (tag) ekliyoruz
                    button.Click += new EventHandler(Button_Click);

                    this.Controls.Add(button);
                }
            }

            Button restartButton = new Button();
            restartButton.Text = "Yeniden Başlat";
            restartButton.Width = 250;
            restartButton.Height = 30;
            restartButton.Top = 15 * (buttonSize + padding);
            restartButton.Left = 0;
            restartButton.Click += new EventHandler(RestartButton_Click);

            this.Controls.Add(restartButton);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string[] coordinates = clickedButton.Tag.ToString().Split(',');
            int row = int.Parse(coordinates[0]);
            int col = int.Parse(coordinates[1]);

            clickedButton.Enabled = false;

            string image = @"C:\Users\mahmut elmuhammed\Desktop\C#\AmiralBatti\deniz.jpg"; // dosya yolu
            Image selectedImage1 = Image.FromFile(image);


            basma++;

            if (gameBoard[row, col] == 1)
            {
                string imagePath = @"C:\Users\mahmut elmuhammed\Desktop\C#\AmiralBatti\icon.jpg";
                Image selectedImage = Image.FromFile(imagePath);
                clickedButton.BackgroundImage = selectedImage;
                clickedButton.BackgroundImageLayout = ImageLayout.Stretch;

                birlerBasma++;
                int flag;
                gameBoard[row, col] = 0;

                for (int i = 0; i < 10; i++)
                {
                    int Uzunluk_1 = shipLengths[i];
                    int dikeyYatay_1 = YatayDikey[i];
                    int satir_1 = Satir[i];
                    int sutun_1 = Sutun[i];
                    flag = Kontrol(Uzunluk_1, dikeyYatay_1, sutun_1, satir_1);
                     
                    if (flag == 1) //gemi tamemen bulunmuşsa
                    {
                        if (dikeyYatay_1 == 1)  //Yatay ise
                        {
                            if (sutun_1 > 0 && satir_1 != 14)
                            {
                                if(satir_1 > 0 && satir_1 != 14) 
                                {
                                    for (int m = satir_1 - 1; m <= satir_1 + 1; m++)
                                    {
                                        for (int n = sutun_1 - 1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            // Butonların indeksini hesapla
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if (satir_1 == 0)
                                {
                                    for (int m = satir_1; m <= satir_1 + 1; m++)
                                    {
                                        for (int n = sutun_1 -1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }
                            }

                            if (sutun_1 == 0)
                            {
                                if (satir_1 == 0)
                                {
                                    for (int m = satir_1; m <= satir_1 + 1; m++)
                                    {
                                        for (int n = sutun_1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if (satir_1 > 0 && satir_1 != 14)
                                {
                                    for (int m = satir_1 -1; m <= satir_1 + 1; m++)
                                    {
                                        for (int n = sutun_1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }
                            }

                            if(satir_1 == 14)
                            {
                                if(sutun_1 == 0)
                                {
                                    for (int m = satir_1 - 1; m <= satir_1 ; m++)
                                    {
                                        for (int n = sutun_1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if(sutun_1 > 0 && (sutun_1 + Uzunluk_1) != 15)
                                {
                                    for (int m = satir_1 - 1; m <= satir_1; m++)
                                    {
                                        for (int n = sutun_1 -1; n <= sutun_1 + Uzunluk_1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if((sutun_1 + Uzunluk_1) == 15)
                                {
                                    for (int m = satir_1 - 1; m <= satir_1; m++)
                                    {
                                        for (int n = sutun_1 - 1; n <= sutun_1 + Uzunluk_1 -1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }
                            }
                        }

                        else if (dikeyYatay_1 == 0)  //Dikey ise
                        {
                            if (satir_1 > 0)
                            {
                                if (sutun_1 > 0 && satir_1 + Uzunluk_1 != 15) 
                                {
                                    for (int m = satir_1 - 1; m <= satir_1 + Uzunluk_1; m++)
                                    {
                                        for (int n = sutun_1 - 1; n <= sutun_1 + 1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if (sutun_1 == 0)
                                {
                                    for (int m = satir_1 -1; m <= satir_1 + Uzunluk_1; m++)
                                    {
                                        for (int n = sutun_1; n <= sutun_1 + 1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }
                            }

                            if (satir_1 == 0)
                            {
                                if (sutun_1 == 0)
                                {
                                    for (int m = satir_1; m <= satir_1 + Uzunluk_1; m++)
                                    {
                                        for (int n = sutun_1; n <= sutun_1 + 1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }

                                else if (sutun_1 > 0 && sutun_1 != 14)
                                {
                                    for (int m = satir_1; m <= satir_1 + Uzunluk_1; m++)
                                    {
                                        for (int n = sutun_1 - 1; n <= sutun_1 + 1; n++)
                                        {
                                            int buttonIndex = m * COLS + n;
                                            string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                            if (coordinat[2] != "X")
                                            {
                                                this.Controls[buttonIndex].Enabled = false;
                                                this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                                this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                            }

                                        }
                                    }
                                }
                            }

                            if(satir_1 + Uzunluk_1 == 15)
                            {
                                for (int m = satir_1 -1; m <= satir_1 + Uzunluk_1 -1; m++)
                                {
                                    for (int n = sutun_1 - 1; n <= sutun_1 + 1; n++)
                                    {
                                        int buttonIndex = m * COLS + n;
                                        string[] coordinat = this.Controls[buttonIndex].Tag.ToString().Split(',');

                                        if (coordinat[2] != "X")
                                        {
                                            this.Controls[buttonIndex].Enabled = false;
                                            this.Controls[buttonIndex].BackgroundImage = selectedImage1;
                                            this.Controls[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }



            }

            else
            {
                clickedButton.BackgroundImage = selectedImage1;
                clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
            }

            if (birlerBasma == 20)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button)
                    {
                        Button button = (Button)ctrl;
                        if (button.Text != "Yeniden Başlat")
                        {
                            button.Enabled = false;
                        }
                    }
                }
                MessageBox.Show("Tebrikler! " +basma.ToString() +" hamlede bittirdiniz");
            }
        }

        private void PlaceShips()
        {
            Random rand = new Random();

            int numOfShips = shipLengths.Length;

            for (int ship = 0; ship < numOfShips; ship++)
            {
                int shipLength = shipLengths[ship];
                bool placed = false;

                while (!placed)
                {
                    int randomRow = rand.Next(0, ROWS);
                    int randomCol = rand.Next(0, COLS);

                    bool valid = true;
                    bool horizontal = rand.Next(0, 2) == 0; // Rastgele yatay veya dikey yerleştirme ,1 yatay 0 dikey

                    //Geminin etrafında gemi var mı yok kontrol etme
                    for (int i = randomRow - 1; i <= randomRow + shipLength; i++)
                    {
                        for (int j = randomCol - 1; j <= randomCol + shipLength; j++)
                        {
                            if (i >= 0 && i < ROWS && j >= 0 && j < COLS)
                            {
                                if (gameBoard[i, j] == 1)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                        if (!valid) break;
                    }

                    //  yatay veya dikey olarak gemi var mı yok mu kontrol etme
                    for (int i = 0; i < shipLength; i++)
                    {
                        int row = randomRow;
                        int col = randomCol;

                        if (horizontal)
                        {
                            col += i;
                        }
                        else
                        {
                            row += i;
                        }

                        if (row < 0 || row > ROWS - 1 || col < 0 || col >= COLS - 1 || gameBoard[row, col] == 1)
                        {
                            valid = false;
                            break;
                        }
                    }

                    // Gemiyi yerleştirme
                    if (valid)
                    {
                        for (int i = 0; i < shipLength; i++)
                        {

                            int row = randomRow;
                            int col = randomCol;

                            if (horizontal)
                            {
                                col += i;
                            }
                            else
                            {
                                row += i;
                            }

                            gameBoard[row, col] = 1;
                            this.Controls[row * 15 + col].Tag = $"{row},{col},X";
                        }   
                        placed = true;
                        YatayDikey[x] = Convert.ToInt32(horizontal);
                        Satir[x] = randomRow;
                        Sutun[x] = randomCol;
                        x++;
                    }
                }
            }

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (gameBoard[i, j] != 1)
                    {
                        this.Controls[i * 15 + j].Tag = $"{i},{j},$";
                    }
                }
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Yeniden başlatma işlemleri burada gerçekleştirilecek
            ResetGame();
        }

        private void ResetGame()
        {
            // Oyun tahtasını ve değişkenleri sıfırlama
            basma = 0;
            birlerBasma = 0;
            x = 0;
            Array.Clear(gameBoard, 0, gameBoard.Length);
            Array.Clear(YatayDikey, 0, YatayDikey.Length);
            Array.Clear(Sutun, 0, Sutun.Length);
            Array.Clear(Satir, 0, Satir.Length);

            // Butonların ve oyun tahtasının yeniden oluşturulması
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button button = (Button)ctrl;
                    button.BackColor = DefaultBackColor;
                    button.ForeColor = DefaultForeColor;
                    button.Enabled = true;
                    button.BackgroundImage = null;

                    if (button.Text != "Yeniden Başlat")
                    {
                        button.Text = "";
                    }

                }
            }

            // Yeniden gemilerin yerleştirilmesi ve oyun tahtasının güncellenmesi
            PlaceShips();
        }

        private int Kontrol(int uzunluk, int yatayDikey, int sutun, int satir)//geminin tamamen bulunup bulunmaduğını kontrol etme                                                          
        {
            int sayi1 = uzunluk;
            int sayi2 = yatayDikey;
            int sayi3 = satir;
            int sayi4 = sutun;

            if (sayi2 == 1) // Yatay ise
            {
                for (int i = 0; i < sayi1; i++)
                {
                    if (gameBoard[sayi3, sayi4] == 1)
                        return 0;
                    else
                        sayi4++;
                }
                return 1;
            }
            else if (sayi2 == 0) // Dikey ise
            {
                for (int i = 0; i < sayi1; i++)
                {
                    if (gameBoard[sayi3, sayi4] == 1)
                        return 0;
                    else
                        sayi3++;
                }
                return 1;
            }
            return -1;
        }

    }
}