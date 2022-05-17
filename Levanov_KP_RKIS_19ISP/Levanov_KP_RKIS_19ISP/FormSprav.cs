using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Levanov_KP_RKIS_19ISP
{
	public partial class FormSprav : Form
	{
		OleDbConnection dbConnection = new OleDbConnection();
		public FormSprav()
		{
			InitializeComponent();

			dbConnection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Техосмотр.mdb"); //Установка соединения с БД
			dbConnection.Open();
		}

		private void клиентыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.клиентыBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.техосмотрDataSet);

		}

		private void FormSprav_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Справочник". При необходимости она может быть перемещена или удалена.
			this.справочникTableAdapter.Fill(this.техосмотрDataSet.Справочник);
			// TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Оператор_ТО". При необходимости она может быть перемещена или удалена.
			this.оператор_ТОTableAdapter.Fill(this.техосмотрDataSet.Оператор_ТО);
			// TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Автомобиль". При необходимости она может быть перемещена или удалена.
			this.автомобильTableAdapter.Fill(this.техосмотрDataSet.Автомобиль);
			// TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
			this.клиентыTableAdapter.Fill(this.техосмотрDataSet.Клиенты);
		}

		private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e) //Добавление клиента
		{
			this.Size = new Size(1356, 489);

			DobRedKlientLbl.Text = "Добавление";

			IdKlientTxt.Visible = false;
			IdLbl.Visible = false;

			RedBtn.Visible = false;
			OKButton.Visible = true;

			IdKlientTxt.Text = "";
			FioTxt.Text = "";
			PasportTxt.Text = "";
			NumberTxt.Text = "";
			PolisTxt.Text = "";
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e) //Добавление авто
		{
			this.Size = new Size(1356, 489);

			DobRedAutoLbl.Text = "Добавление";
			RedAutoBtn.Visible = false;
			OKAutoBtn.Visible = true;

			IdAutoTxt.Visible = false;
			label1.Visible = false;

			IdAutoTxt.Text = "";
			MarkTxt.Text = "";
			ModelTxt.Text = "";
			GodVipuskaTxt.Text = "";
			ClientIdCmbBox.Text = "";
			GosNumberTxt.Text = "";
			CategoryCmbBox.Text = "";
		}

		private void toolStripMenuItem6_Click_1(object sender, EventArgs e) //Добавление оператора
		{
			this.Size = new Size(1356, 489);

			DobRedOperatorLbl.Text = "Добавление";
			RedOperatorBtn.Visible = false;
			DobOperatorBtn.Visible = true;

			IdOperatorTxt.Visible = false;
			label2.Visible = false;

			IdOperatorTxt.Text = "";
			FioOperatorTxt.Text = "";
			DateRozhdeniadateTimePicker.Text = "01.01.2000";
			EducationTxt.Text = "";
			LicenceTxt.Text = "";
		}

		private void toolStripMenuItem10_Click(object sender, EventArgs e) // Добавление категорий
		{
			this.Size = new Size(1356, 489);

			DobRedCategoryLbl.Text = "Добавление";
			RedCategoryBtn.Visible = false;
			DobCategoryBtn.Visible = true;

			IdCategoryTxt.Visible = false;
			label4.Visible = false;

			IdCategoryTxt.Text = "";
			CategoryTxt.Text = "";
			OpisanieTxt.Text = "";
		}

		private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e) // Редактирование клиентов
		{
			this.Size = new Size(1356, 489);

			DobRedKlientLbl.Text = "Редактирование";
			RedBtn.Visible = true;
			OKButton.Visible = false;

			IdKlientTxt.Visible = true;
			IdLbl.Visible = true;

			IdKlientTxt.Text = клиентыDataGridView.CurrentRow.Cells[0].Value.ToString();
			FioTxt.Text = клиентыDataGridView.CurrentRow.Cells[1].Value.ToString();
			PasportTxt.Text = клиентыDataGridView.CurrentRow.Cells[2].Value.ToString();
			NumberTxt.Text = клиентыDataGridView.CurrentRow.Cells[3].Value.ToString();
			PolisTxt.Text = клиентыDataGridView.CurrentRow.Cells[4].Value.ToString();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e) // Редактирование авто
		{
			this.Size = new Size(1356, 489);

			DobRedAutoLbl.Text = "Редактирование";
			RedAutoBtn.Visible = true;
			OKAutoBtn.Visible = false;

			IdAutoTxt.Visible = true;
			label1.Visible = true;

			IdAutoTxt.Text = автомобильDataGridView.CurrentRow.Cells[0].Value.ToString();
			MarkTxt.Text = автомобильDataGridView.CurrentRow.Cells[1].Value.ToString();
			ModelTxt.Text = автомобильDataGridView.CurrentRow.Cells[2].Value.ToString();
			GodVipuskaTxt.Text = автомобильDataGridView.CurrentRow.Cells[3].Value.ToString();
			ClientIdCmbBox.Text = автомобильDataGridView.CurrentRow.Cells[4].Value.ToString();
			GosNumberTxt.Text = автомобильDataGridView.CurrentRow.Cells[5].Value.ToString();
			CategoryCmbBox.Text = автомобильDataGridView.CurrentRow.Cells[6].Value.ToString();
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e) //Редактирование оператора
		{
			this.Size = new Size(1356, 489);

			DobRedOperatorLbl.Text = "Редактирование";
			RedOperatorBtn.Visible = true;
			DobOperatorBtn.Visible = false;

			IdOperatorTxt.Visible = true;
			label2.Visible = true;

			IdOperatorTxt.Text = оператор_ТОDataGridView.CurrentRow.Cells[0].Value.ToString();
			FioOperatorTxt.Text = оператор_ТОDataGridView.CurrentRow.Cells[1].Value.ToString();
			DateRozhdeniadateTimePicker.Text = оператор_ТОDataGridView.CurrentRow.Cells[2].Value.ToString();
			EducationTxt.Text = оператор_ТОDataGridView.CurrentRow.Cells[3].Value.ToString();
			LicenceTxt.Text = оператор_ТОDataGridView.CurrentRow.Cells[4].Value.ToString();
		}

		private void toolStripMenuItem11_Click(object sender, EventArgs e) // Редактирование категорий
		{
			this.Size = new Size(1356, 489);

			DobRedCategoryLbl.Text = "Редактирование";
			RedCategoryBtn.Visible = true;
			DobCategoryBtn.Visible = false;

			IdCategoryTxt.Visible = true;
			label4.Visible = true;

			IdCategoryTxt.Text = справочникDataGridView.CurrentRow.Cells[0].Value.ToString();
			CategoryTxt.Text = справочникDataGridView.CurrentRow.Cells[0].Value.ToString();
			OpisanieTxt.Text = справочникDataGridView.CurrentRow.Cells[1].Value.ToString();
		}

		private void OKButton_Click(object sender, EventArgs e) //Кнопка добавления клиента
		{
			if (FioTxt.Text == "")
			{
				MessageBox.Show("Введите имя!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				FioTxt.Focus();
			}
			
			else if (PasportTxt.Text == "")
			{
				MessageBox.Show("Введите паспорт!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PasportTxt.Focus();
			}

			else if (NumberTxt.Text == "")
			{
				MessageBox.Show("Введите номер телефона!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PasportTxt.Focus();
			}

			else if (PolisTxt.Text == "")
			{
				MessageBox.Show("Введите Полис ОСАГО!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PasportTxt.Focus();
			}

			else
			{
				try
				{
					string query = $"INSERT INTO Клиенты (ФИО, Паспорт, Номер_телефона, Полис_ОСАГО) VALUES ('{FioTxt.Text}','{PasportTxt.Text}','{NumberTxt.Text}','{PolisTxt.Text}')";
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();

					this.Size = new Size(711, 489);

					MessageBox.Show("Запись успешно добавлена!", "Добавление!");
					this.клиентыTableAdapter.Fill(this.техосмотрDataSet.Клиенты);
				}

				catch
				{
					MessageBox.Show("Что-то пошло не так :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
			}
			
		}

        private void RedBtn_Click(object sender, EventArgs e) // Кнопка редактирования клиента
        {
            if (FioTxt.Text == "")
            {
                MessageBox.Show("Введите имя!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FioTxt.Focus();
            }

            else if (PasportTxt.Text == "")
            {
                MessageBox.Show("Введите паспорт!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasportTxt.Focus();
            }

            else if (NumberTxt.Text == "")
            {
                MessageBox.Show("Введите номер телефона!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasportTxt.Focus();
            }

            else if (PolisTxt.Text == "")
            {
                MessageBox.Show("Введите Полис ОСАГО!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasportTxt.Focus();
            }

            else
            {
                try
                {
                    string query = $"UPDATE Клиенты SET ФИО = '{FioTxt.Text}', Паспорт = '{PasportTxt.Text}', Номер_телефона = '{NumberTxt.Text}', Полис_ОСАГО = '{PolisTxt.Text}' WHERE ID = {IdKlientTxt.Text}";
                    OleDbCommand command = new OleDbCommand(query, dbConnection);
                    command.ExecuteNonQuery();

                    this.Size = new Size(711, 489);

                    MessageBox.Show("Редактирование", "Редактирование прошло успешно");
                    this.клиентыTableAdapter.Fill(this.техосмотрDataSet.Клиенты);
                }

                catch
                {
                    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		private void RedAutoBtn_Click(object sender, EventArgs e) //Кнопка редактирования авто
		{
            if (MarkTxt.Text == null)
            {
                MessageBox.Show("Введите марку!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MarkTxt.Focus();
            }
            else if(ModelTxt.Text == null)
            {
                MessageBox.Show("Введите модель!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FioTxt.Focus();
            }
            else if (GodVipuskaTxt.Text == null)
            {
                MessageBox.Show("Год выпуска!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GodVipuskaTxt.Focus();
            }
            else if (GosNumberTxt.Text == null)
            {
                MessageBox.Show("Введите модель!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GosNumberTxt.Focus();
            }
            else
            {

            
                try
			    {

				    string query = $"UPDATE Автомобиль SET Марка = '{MarkTxt.Text}', Модель = '{ModelTxt.Text}', Год_выпуска = '{GodVipuskaTxt.Text}'," +
				    		   $" Id_клиента = '{ClientIdCmbBox.SelectedValue}', Гос_номер = '{GosNumberTxt.Text}', Категория = '{CategoryCmbBox.SelectedValue}' WHERE ID = {IdAutoTxt.Text}";

				    OleDbCommand command = new OleDbCommand(query, dbConnection);
				    command.ExecuteNonQuery();

				    this.Size = new Size(711, 489);

				    MessageBox.Show("Редактирование", "Редактирование прошло успешно");
				    this.автомобильTableAdapter.Fill(this.техосмотрDataSet.Автомобиль);
			    }

			    catch
			    {
				    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
			    }
            }
        }

		private void OKAutoBtn_Click(object sender, EventArgs e) // Кнопка добавления авто
		{
            if (MarkTxt.Text == null)
            {
                MessageBox.Show("Введите марку!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MarkTxt.Focus();
            }
            else if (ModelTxt.Text == null)
            {
                MessageBox.Show("Введите модель!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FioTxt.Focus();
            }
            else if (GodVipuskaTxt.Text == null)
            {
                MessageBox.Show("Год выпуска!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GodVipuskaTxt.Focus();
            }
            else if (GosNumberTxt.Text == null)
            {
                MessageBox.Show("Введите модель!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GosNumberTxt.Focus();
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO Автомобиль (Марка, Модель, Год_выпуска, Id_клиента, Гос_номер, Категория) VALUES ('{MarkTxt.Text}','{ModelTxt.Text}', '{GodVipuskaTxt.Text}' ," +
                           $"'{ClientIdCmbBox.SelectedValue}', '{GosNumberTxt.Text}', '{CategoryCmbBox.SelectedValue}')";

                    OleDbCommand command = new OleDbCommand(query, dbConnection);
                    command.ExecuteNonQuery();

                    this.Size = new Size(711, 489);

                    MessageBox.Show("Запись успешно добавлена!", "Добавление!");
                    this.автомобильTableAdapter.Fill(this.техосмотрDataSet.Автомобиль);
                }

                catch
                {
                    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
		}

		private void DobOperatorBtn_Click(object sender, EventArgs e) // Кнопка добавления оператора
		{
            if (FioOperatorTxt.Text == null)
            {
                MessageBox.Show("Введите ФИО!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FioOperatorTxt.Focus();
            }
            else if (EducationTxt.Text == null)
            {
                MessageBox.Show("Введите образование!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EducationTxt.Focus();
            }
            else if (LicenceTxt.Text == null)
            {
                MessageBox.Show("Введите лицензию!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LicenceTxt.Focus();
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO [Оператор ТО] (ФИО, Дата_рождения, Образование, Лицензия) VALUES ('{FioOperatorTxt.Text}', '{DateRozhdeniadateTimePicker.Value.ToString("dd.MM.yyyy")}', '{EducationTxt.Text}','{LicenceTxt.Text}')";

                    OleDbCommand command = new OleDbCommand(query, dbConnection);
                    command.ExecuteNonQuery();

                    this.Size = new Size(711, 489);

                    MessageBox.Show("Запись успешно добавлена!", "Добавление!");
                    this.оператор_ТОTableAdapter.Fill(this.техосмотрDataSet.Оператор_ТО);
                }

                catch
                {
                    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
		}

		private void RedOperatorBtn_Click(object sender, EventArgs e) // Кнопка редактирования оператора
		{
            if (FioOperatorTxt.Text == null)
            {
                MessageBox.Show("Введите ФИО!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FioOperatorTxt.Focus();
            }
            else if (EducationTxt.Text == null)
            {
                MessageBox.Show("Введите образование!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EducationTxt.Focus();
            }
            else if (LicenceTxt.Text == null)
            {
                MessageBox.Show("Введите лицензию!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LicenceTxt.Focus();
            }
            else
            {
                try
                {
                    string query = $"UPDATE [Оператор ТО] SET ФИО = '{FioOperatorTxt.Text}', Дата_рождения = '{DateRozhdeniadateTimePicker.Value.ToString("dd.MM.yyyy")}', " +
                               $"Образование = '{EducationTxt.Text}', Лицензия = '{LicenceTxt.Text}' WHERE ID = {IdOperatorTxt.Text}";

                    this.Size = new Size(711, 489);

                    MessageBox.Show("Запись успешно отредактирована!", "Редактирование!");
                    this.оператор_ТОTableAdapter.Fill(this.техосмотрDataSet.Оператор_ТО);
                }

                catch
                {
                    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
		}

		private void DobCategoryBtn_Click(object sender, EventArgs e) //Кнопка добавления категорий
		{
            if(CategoryTxt.Text == null)
            {
                MessageBox.Show("Введите лицензию!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CategoryTxt.Focus();
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO Справочник (Категория, Описание) VALUES ('{CategoryTxt.Text}','{OpisanieTxt.Text}')";

                    OleDbCommand command = new OleDbCommand(query, dbConnection);
                    command.ExecuteNonQuery();

                    this.Size = new Size(711, 489);

                    MessageBox.Show("Запись успешно добавлена!", "Добавление!");
                    this.справочникTableAdapter.Fill(this.техосмотрDataSet.Справочник);
                }

                catch
                {
                    MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
		}

		private void RedCategoryBtn_Click(object sender, EventArgs e) //Кнопка редактирования категорий
		{
			try
			{
				string query = $"UPDATE Справочник SET Категория = '{CategoryTxt.Text}', Описание = '{OpisanieTxt.Text}' WHERE Категория = '{CategoryTxt.Text}'";
				OleDbCommand command = new OleDbCommand(query, dbConnection);
				command.ExecuteNonQuery();

				this.Size = new Size(711, 489);

				MessageBox.Show("Запись успешно отредактирована!", "Редактирование!");
				this.справочникTableAdapter.Fill(this.техосмотрDataSet.Справочник);
			}

			catch
			{

			}
		}

		private void CancelKlientBtn_Click(object sender, EventArgs e) // Кнопка отмена при доб/ред клиентов
		{
			this.Size = new Size(711, 489);
		}

		private void CancelAutoBtn_Click(object sender, EventArgs e) // Кнопка отмена при доб/ред авто
		{
			this.Size = new Size(711, 489);
		}

		private void CancelOperatorBtn_Click(object sender, EventArgs e) // Кнопка отмена при доб/ред операторов
		{
			this.Size = new Size(711, 489);
		}

		private void CancelCategoryBtn_Click(object sender, EventArgs e) // Кнопка отмена при доб/ред Категорий
		{
			this.Size = new Size(711, 489);
		}

		private void удалениеToolStripMenuItem_Click(object sender, EventArgs e) //Удаление клиентов
		{
			var SelectRow = клиентыDataGridView.CurrentRow;
			SelectRow.DefaultCellStyle.BackColor = Color.Red;
			try
			{
				var result = MessageBox.Show($"Вы действительно хотите удалить запись клиента: {клиентыDataGridView.CurrentRow.Cells[1].Value}", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				string query = $"DELETE FROM Клиенты WHERE Id = {клиентыDataGridView.CurrentRow.Cells[0].Value}";
				if (result == DialogResult.Yes)
				{
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();
					// выполняем запрос к MS Access

					MessageBox.Show("Удалена 1 запись!", "Удаление");
					this.клиентыTableAdapter.Fill(техосмотрDataSet.Клиенты);
				}
			}

			catch
			{
				MessageBox.Show("Имеются связанные таблицы!", "Ошибка!");
			}

			SelectRow.DefaultCellStyle.BackColor = Color.White;
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e) // Удаление авто
		{
			var SelectRow = автомобильDataGridView.CurrentRow;
			SelectRow.DefaultCellStyle.BackColor = Color.Red;
			try
			{
				var result = MessageBox.Show($"Вы действительно хотите удалить запись под номером {автомобильDataGridView.CurrentRow.Cells[0].Value}", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				string query = $"DELETE FROM Автомобиль WHERE Id = {автомобильDataGridView.CurrentRow.Cells[0].Value}";
				if (result == DialogResult.Yes)
				{
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();
					// выполняем запрос к MS Access

					MessageBox.Show("Удалена 1 запись!", "Удаление");
					this.автомобильTableAdapter.Fill(техосмотрDataSet.Автомобиль);
				}
			}

			catch
			{
				MessageBox.Show("Имеются связанные таблицы!", "Ошибка!");
			}

			SelectRow.DefaultCellStyle.BackColor = Color.White;
		}

		private void toolStripMenuItem8_Click(object sender, EventArgs e) // Удаление оператор
		{
			var SelectRow = оператор_ТОDataGridView.CurrentRow;
			SelectRow.DefaultCellStyle.BackColor = Color.Red;

			try
			{
				var result = MessageBox.Show($"Вы действительно хотите удалить запись под номером {оператор_ТОDataGridView.CurrentRow.Cells[0].Value}", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				string query = $"DELETE FROM [Оператор ТО] WHERE Id = {оператор_ТОDataGridView.CurrentRow.Cells[0].Value}";
				if (result == DialogResult.Yes)
				{
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();
					// выполняем запрос к MS Access

					MessageBox.Show("Удалена 1 запись!", "Удаление");
					this.оператор_ТОTableAdapter.Fill(техосмотрDataSet.Оператор_ТО);
				}
			}

			catch
			{
				MessageBox.Show("Имеются связанные таблицы!", "Ошибка!");
			}

			SelectRow.DefaultCellStyle.BackColor = Color.White;
		}

		private void toolStripMenuItem12_Click(object sender, EventArgs e) //Удаление категорий
		{
			var SelectRow = справочникDataGridView.CurrentRow;
			SelectRow.DefaultCellStyle.BackColor = Color.Red;

			try
			{
				var result = MessageBox.Show($"Вы действительно хотите удалить категорию: {справочникDataGridView.CurrentRow.Cells[0].Value}", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				string query = $"DELETE FROM Справочник WHERE Категория = '{справочникDataGridView.CurrentRow.Cells[0].Value.ToString()}'";
				if (result == DialogResult.Yes)
				{
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();
					// выполняем запрос к MS Access

					MessageBox.Show("Удалена 1 запись!", "Удаление");
					this.справочникTableAdapter.Fill(техосмотрDataSet.Справочник);
				}
			}

			catch
			{
				MessageBox.Show("Имеются связанные таблицы!", "Ошибка!");
			}

			SelectRow.DefaultCellStyle.BackColor = Color.White;
		}

		private void SearchKlientTxt_TextChanged(object sender, EventArgs e)
		{
			string filter = "ФИО Like \'" + SearchKlientTxt.Text + "*\'" + "or Номер_телефона Like \'" + SearchKlientTxt.Text + "*\'" + "or Полис_ОСАГО Like \'" + SearchKlientTxt.Text + "*\'";
			//MessageBox.Show(s);
			клиентыBindingSource.Filter = filter;
		}

		private void NumberTxt_KeyPress(object sender, KeyPressEventArgs e) // Защита для ввода номера телефона
		{
			NumberTxt.MaxLength = 12;
			if (e.KeyChar == '+' && NumberTxt.TextLength != 0)
			{
				e.KeyChar = (char)0;
			}
			if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || (int)e.KeyChar == 8 || e.KeyChar == '+'))
			{
				e.KeyChar = (char)0;
			}
		}

		private void PolisTxt_KeyPress(object sender, KeyPressEventArgs e) // Защита для ввода Полиса ОСАГО
		{
			PolisTxt.MaxLength = 6;
			if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || (int)e.KeyChar == 8))
			{
				e.KeyChar = (char)0;
			}
		}

		private void FioTxt_KeyPress(object sender, KeyPressEventArgs e) //Защита для ввода ФИО
		{
			{
				char l = e.KeyChar;
				if ((l < 'А' || l > 'я') && l != '\b')
				{
					e.Handled = true;
				}
			}
		}

        private void GodVipuskaTxt_KeyPress(object sender, KeyPressEventArgs e) //Защита для ввода Года выпуска
        {
            GodVipuskaTxt.MaxLength = 4;
            if(!(e.KeyChar >= '0' && e.KeyChar <= '9' || (int)e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }    
        private void GosNumberTxt_KeyPress(object sender, KeyPressEventArgs e) //Защита для ввода Гос.номера
        {
            GosNumberTxt.MaxLength = 6;
        }

        private void EducationTxt_KeyPress(object sender, KeyPressEventArgs e) //Защита для ввода поля образования
        {
            if (char.IsLetter(e.KeyChar)) return;
            if ((char)e.KeyChar == (char)Keys.Back) return;
            if ((char)e.KeyChar == (char)Keys.Space) return;
            e.Handled = true;
        }

        private void LicenceTxt_KeyPress(object sender, KeyPressEventArgs e) //Защита для ввода лицензии
        {
            LicenceTxt.MaxLength = 6;
            if (char.IsDigit(e.KeyChar)) return;
            if ((char)e.KeyChar == (char)Keys.Back) return;
            if ((char)e.KeyChar == (char)Keys.Space) return;
            e.Handled = true;
        }
    }
}
