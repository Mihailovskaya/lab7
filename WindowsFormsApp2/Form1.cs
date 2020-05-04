using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Предыдущее положение мыши.
		/// </summary>
		Point lastMousePosition;
		/// <summary>
		/// Предыдущий размер окна.
		/// </summary>
		Size lastClientSize;
		/// <summary>
		/// Разница между новой и старой шириной окна.
		/// </summary>
		int X = 0;
		/// <summary>
		/// Разница между новой и старой высотой окна.
		/// </summary>
		int Y = 0;
		/// <summary>
		/// Координаты мыши.
		/// </summary>
		Point point1;
		/// <summary>
		/// Смещение кнопки от края формы.
		/// </summary>
		int h = 30;

		/// <summary>
		/// Обработчик события нажатия на кнопку. Вызываем Message Box.
		/// </summary>
		private void button1_MouseClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!", "Убегающая кнопка");
			button1.Top = (ClientSize.Height - button1.Height) / 2;
			button1.Left = (ClientSize.Width - button1.Width) / 2;
		}
		/// <summary>
		/// Обработчик события загрузки формы.
		/// </summary>
		private void Form1_Load(object sender, EventArgs e)
		{
			lastClientSize = ClientSize;
			button1.Top = (ClientSize.Height - button1.Height) / 2;
			button1.Left = (ClientSize.Width - button1.Width) / 2;
		}
		/// <summary>
		/// Обработчик события движения мыши. Перемещаем кнопку согласно направлению мыши.
		/// </summary>

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			//перемещение по X
			if (e.X > button1.Left - 10 && e.X < button1.Left + button1.Width + 10)
			{
				if (e.X >= (button1.Left + (button1.Width / 2)))
					button1.Left -= 10;
				else
					button1.Left += 10;
			}
			//перемещение по Y
			if (e.Y >= button1.Top - 10 && e.Y <= button1.Top + button1.Height + 10)
			{
				if (e.Y >= (button1.Top + (button1.Height / 2)))
					button1.Top -= 10;
				else
					button1.Top += 10;
			}
			//обработка достижения стены
			if (button1.Left < 0)
				button1.Left = 50;
			if ((button1.Left + button1.Width) > this.ClientSize.Width)
				button1.Left = this.ClientSize.Width - button1.Width;
			if (button1.Top < 0)
				button1.Top =0;
			if ((button1.Top + button1.Height) > this.ClientSize.Height)
				button1.Top = this.ClientSize.Height - button1.Height;
		}

		
		/// <summary>
		/// Обработчик события изменения размера формы. Корректируем положение кнопки.
		/// </summary>
		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			X = lastClientSize.Width - ClientSize.Width;
			Y = lastClientSize.Height - ClientSize.Height;
			lastClientSize = ClientSize;
			if (X > 0 || Y > 0)
			{
				if (button1.Right > ClientSize.Width)
				{
					button1.Left = ClientSize.Width - button1.Width - h;
				}


				if (button1.Left < 0)
				{
					button1.Left = h;
				}
				if (button1.Top < 0)
				{
					button1.Top = h;
				}


				if (button1.Bottom > ClientSize.Height)
				{
					button1.Top = ClientSize.Height - button1.Height - h;
				}
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
