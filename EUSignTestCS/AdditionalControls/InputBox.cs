using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EUSignTestCS.AdditionalControls
{
	public partial class InputBox : Form
	{
		public InputBox()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		public string Value
		{
			get
			{
				return textBox.Text;
			}

			set
			{
				textBox.Text = value;
			}
		}

		public char PasswordChar
		{
			get
			{
				return textBox.PasswordChar;
			}

			set
			{
				textBox.PasswordChar = value;
			}
		}

		public string Promt
		{
			get
			{
				return label.Text;
			}

			set
			{
				label.Text = value;
			}
		}

		public string Title
		{
			get
			{
				return this.Text;
			}

			set
			{
				this.Text = value;
			}
		}

		public static string Show(string promt, 
			string title, string defaultText, bool secure = false)
		{
			InputBox inputBox = new InputBox();
			inputBox.Promt = promt;
			inputBox.Title = title;
			inputBox.Value = defaultText;
			if (secure)
				inputBox.PasswordChar = '*';
			else 
				inputBox.PasswordChar = '\0';

			if (inputBox.ShowDialog() == DialogResult.OK)
				return inputBox.Value;
			else
				return "";
		}
	}
}
