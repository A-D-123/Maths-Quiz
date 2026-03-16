using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maths_Quiz
{
    public partial class QuizForm : Form
    {
        public QuizForm(int bestScore)
        {
            createQuizFrom(bestScore);
        }
        void createQuizFrom(int bestScore)
        {
            this.Name = "Quiz_Form";
            this.Text = "Maths Quiz";
            this.Size = new Size(750, 500);
            this.Font = new Font("Segoe UI", 24);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label bestScoreLabel = new Label();
            bestScoreLabel.Text = $"Best: {bestScore}";
            this.Controls.Add(bestScoreLabel);
        }
    }
}
