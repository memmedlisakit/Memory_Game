using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MemoryGame : Form
    {
        public int LeftPos = 0;
        public int TopPos = 0;
        public int ButtonName = 0;
        public Button btn;
        
        public List<string> Words = new List<string>() { "Elnur", "Atilla", "Nicat", "Ilkin", "Adigozel", "Tebriz", "Anar", "Nermin", "Elnur", "Atilla", "Nicat", "Ilkin", "Adigozel", "Tebriz", "Anar", "Nermin" };
        public MemoryGame()
        {
            InitializeComponent();
            CreateButtons(4);
           



        }
     


        public void CreateButtons(int Count)
        {
            var Rand = new Random();
            int n = Words.Count;
            for (int i = 0; i < n; i++)
            {
                
                int r = i + Rand.Next(n - i); //14
                var t = Words[r]; // Nermin
                Words[r] = Words[i];
                Words[i] = t;
            }
            for (int row = 0; row < Count; row++)
            { 
                for (int column = 0; column < Count; column++)
                { 
                    btn = new Button();
                    btn.Width = 130;
                    btn.Height = btn.Width;
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.White;
                    btn.Left = LeftPos;
                    btn.Top = TopPos;
                    btn.Text = Words[ButtonName];
                    btn.Click += new EventHandler(MatchButton);
                    Controls.Add(btn);
                    
                    LeftPos += btn.Width;
                    ButtonName++;
                }
                TopPos += btn.Height;
                LeftPos = 0;

            }

            
           
        }

        public void MatchButton(object obj,EventArgs e)
        {
            var button=obj as Button;
            foreach (var item in Controls)
            {
                var nextButton = item as Button;
               if (button.Text == nextButton.Text)
                {
                    nextButton.BackColor = Color.Red;
                    button.BackColor = Color.Red;
                }
            }
        }

        
    }
}
