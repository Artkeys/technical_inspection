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
    public partial class FormMain : Form
    {
        OleDbConnection dbConnection = new OleDbConnection();
        public FormMain()
        {
            InitializeComponent();

            dbConnection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Техосмотр.mdb"); //Установка соединения с БД
            dbConnection.Open();

        }

        private void диагностическая_картаBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.диагностическая_картаBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.техосмотрDataSet);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Автомобиль". При необходимости она может быть перемещена или удалена.
            this.автомобильTableAdapter.Fill(this.техосмотрDataSet.Автомобиль);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Оператор_ТО". При необходимости она может быть перемещена или удалена.
            this.оператор_ТОTableAdapter.Fill(this.техосмотрDataSet.Оператор_ТО);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "техосмотрDataSet.Диагностическая_карта". При необходимости она может быть перемещена или удалена.
            this.диагностическая_картаTableAdapter.Fill(this.техосмотрDataSet.Диагностическая_карта);

            автомобильBindingSource2.Sort = "Гос_номер";
            автомобильBindingSource3.Sort = "Гос_номер";
            операторТОBindingSource1.Sort = "ФИО";
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSprav formSprav = new FormSprav();
            formSprav.Show(); //Открытие формы со справочниками
        }

        private void SearchBtn_Click(object sender, EventArgs e) //Поиск
        {
            string s = null;
            if (checkBoxId.Checked == true)
            {
                if (s == null)
                {
                    s = $"Id_авто = {GosNumberSearchTxt.SelectedValue}";
                }

                else
                {
                    s += $" AND Id_авто = {GosNumberSearchTxt.SelectedValue}";
                }

            }

            if (CheckBoksDataProvedenia.Checked == true)
            {
                if (s == null)
                {
                    s = "Дата_проведения >='" + dateTimePickerS.Value.ToString("dd.MM.yyyy") + "'" + "AND Дата_проведения <='" + dateTimePickerPo.Value.ToString("dd.MM.yyyy") + "'";
                }

                else
                {
                    s += " AND Дата_проведения >= '" + dateTimePickerS.Value.ToString("dd.MM.yyyy") + "'" + "AND Дата_проведения <= '" + dateTimePickerPo.Value.ToString("dd.MM.yyyy") + "'";
                }
            }

            диагностическая_картаBindingSource.Filter = s;

        }

        private void SbrosBtn_Click(object sender, EventArgs e)
        {
            диагностическая_картаBindingSource.Filter = null;
        }

        private void DobDiagKart_Click(object sender, EventArgs e) // Добавлени диаг карты
        {
            this.Size = new Size(1600, 561);

            labelDobRed.Text = "Добавление";

            IDDiagKartTxt.Visible = false;
            labelId.Visible = false;

            RedBtn.Visible = false;
            DobBtn.Visible = true;

            GosNumberCmbBox.Text = "";
            DateProvedenia.Value = DateTime.Today;
            SrokDeystviya.Value = DateTime.Today.AddYears(2);
            OperatorCmb.Text = "";
            SummOplateTxt.Text = "";
            PrimechanieTxt.Text = "";
        }

        private void DobBtn_Click(object sender, EventArgs e) //Кнопка добавления диагностической карты
        {
			if (GosNumberCmbBox.SelectedValue == null)
			{
				MessageBox.Show("Выберите Гос.номер", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				GosNumberCmbBox.Focus();
			}
			else if (OperatorCmb.SelectedValue == null)
			{
				MessageBox.Show("Выберите оператора!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				OperatorCmb.Focus();
			}
			else
			{
				try
				{
				
					string query = $"INSERT INTO [Диагностическая карта] (Id_авто, Дата_проведения, Срок_действия, Проверяющий, Сумма_оплаты, Примечание) " +
					$"VALUES ({GosNumberCmbBox.SelectedValue},'{DateProvedenia.Value.ToString("dd.MM.yyyy")}','{SrokDeystviya.Value.ToString("dd.MM.yyyy")}'," +
					$"{OperatorCmb.SelectedValue}, '{SummOplateTxt.Text}', '{PrimechanieTxt.Text}')";
					OleDbCommand command = new OleDbCommand(query, dbConnection);
					command.ExecuteNonQuery();

					this.Size = new Size(907, 561);

					MessageBox.Show("Запись успешно добавлена!", "Добавление!");
					this.диагностическая_картаTableAdapter.Fill(this.техосмотрDataSet.Диагностическая_карта);
				}

				catch
				{
					MessageBox.Show("Что-то пошло не так :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}      
        }

        private void RedDiagKarta_Click(object sender, EventArgs e) //Редактирование диагностической карты
        {
            this.Size = new Size(1600, 561);

            labelDobRed.Text = "Редактирование";

            IDDiagKartTxt.Visible = true;
            labelId.Visible = true;

            RedBtn.Visible = true;
            DobBtn.Visible = false;

            IDDiagKartTxt.Text = диагностическая_картаDataGridView.CurrentRow.Cells[0].Value.ToString();
            GosNumberCmbBox.SelectedValue = диагностическая_картаDataGridView.CurrentRow.Cells[1].Value;
            DateProvedenia.Value = Convert.ToDateTime(диагностическая_картаDataGridView.CurrentRow.Cells[2].Value);
            SrokDeystviya.Value = Convert.ToDateTime(диагностическая_картаDataGridView.CurrentRow.Cells[3].Value);
            OperatorCmb.SelectedValue = диагностическая_картаDataGridView.CurrentRow.Cells[4].Value;
            SummOplateTxt.Text = диагностическая_картаDataGridView.CurrentRow.Cells[5].Value.ToString();
            PrimechanieTxt.Text = диагностическая_картаDataGridView.CurrentRow.Cells[6].Value.ToString();
        }

        private void RedBtn_Click(object sender, EventArgs e) //Кнопка редактирования диагностической карты
        {
            try
            {
                string query = $"UPDATE [Диагностическая карта] SET Id_авто = {GosNumberCmbBox.SelectedValue}, Дата_проведения = '{DateProvedenia.Value.ToString("dd.MM.yyyy")}', " +
                    $"Срок_действия = '{SrokDeystviya.Value.ToString("dd.MM.yyyy")}', Проверяющий = {OperatorCmb.SelectedValue}, Сумма_оплаты = '{SummOplateTxt.Text}', " +
                    $"Примечание = '{PrimechanieTxt.Text}' WHERE Id = {IDDiagKartTxt.Text}";
                OleDbCommand command = new OleDbCommand(query, dbConnection);
                command.ExecuteNonQuery();

                this.Size = new Size(907, 561);

                MessageBox.Show("Редактирование", "Редактирование прошло успешно");
                this.диагностическая_картаTableAdapter.Fill(this.техосмотрDataSet.Диагностическая_карта);
            }

            catch
            {
                MessageBox.Show("Ошибка!", "Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e) // Кнопка сброса
        {
            this.Size = new Size(907, 561);
        }

        private void DelRedKarta_Click(object sender, EventArgs e) //Удаление диагностической карты
        {
            var SelectRow = диагностическая_картаDataGridView.CurrentRow;
            SelectRow.DefaultCellStyle.BackColor = Color.Red;
            try
            {

                GosNumberCmbBox.SelectedValue = диагностическая_картаDataGridView.CurrentRow.Cells[1].Value;
                var result = MessageBox.Show($"Вы действительно хотите удалить запись диагностической карты с Гос. номером: {GosNumberCmbBox.Text}", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string query = $"DELETE FROM [Диагностическая карта] WHERE Id = {диагностическая_картаDataGridView.CurrentRow.Cells[0].Value}";
                if (result == DialogResult.Yes)
                {
                    OleDbCommand command = new OleDbCommand(query, dbConnection);
                    command.ExecuteNonQuery();
                    // выполняем запрос к MS Access

                    MessageBox.Show("Удалена 1 запись!", "Удаление");
                    this.диагностическая_картаTableAdapter.Fill(техосмотрDataSet.Диагностическая_карта);
                }
            }

            catch
            {
                MessageBox.Show("Имеются связанные таблицы!", "Ошибка!");
            }

            SelectRow.DefaultCellStyle.BackColor = Color.White;
        }
        private void GosNumberCmbBox_SelectedIndexChanged(object sender, EventArgs e) //Заполнение поля категория
        {
            CategoryCmbBox.SelectedIndex = GosNumberCmbBox.SelectedIndex;

        }

        private void CategoryCmbBox_SelectedIndexChanged(object sender, EventArgs e) //Заполнение поля сумма
        {

            switch (CategoryCmbBox.Text)
            {
                case "A":
                    {
                        SummOplateTxt.Text = "240";
                        break;
                    }

                case "B":
                    {
                        SummOplateTxt.Text = "710";
                        break;
                    }

                case "C":
                    {
                        SummOplateTxt.Text = "1200";
                        break;
                    }

                case "D":
                    {
                        SummOplateTxt.Text = "1270";
                        break;
                    }

                case "D1":
                    {
                        SummOplateTxt.Text = "1270";
                        break;
                    }
            }
        }

        private void GodVipuskaCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CategoryCmbBox.Text)
            {
                case "A":
                    {
                        if (DateTime.Today.Year - Convert.ToInt32(GodVipuskaCmbBox.Text) <= 10)
                        {
                            SrokDeystviya.Value = DateTime.Today.AddYears(2);
                            break;
                        }

                        else
                        {
                            SrokDeystviya.Value = DateTime.Today.AddYears(1);
                            break;
                        }

                        break;
                    }

                case "B":
                    {
                        if (DateTime.Today.Year - Convert.ToInt32(GodVipuskaCmbBox.Text) <= 10)
						{
                            SrokDeystviya.Value = DateTime.Today.AddYears(2);
                            break;
                        }
                        
                        else
						{
                            SrokDeystviya.Value = DateTime.Today.AddYears(1);
                            break;
                        }
                    }

                case "C":
                    {
                        SrokDeystviya.Value = DateTime.Today.AddYears(1);
                        break;
                    }

                case "D":
                    {
                        SrokDeystviya.Value = DateTime.Today.AddMonths(6);
                        break;
                    }

                case "D1":
                    {
                        SrokDeystviya.Value = DateTime.Today.AddMonths(6);
                        break;
                    }
            }
        }

		private void техосмотрКончаетсяВДанномМесяцеToolStripMenuItem_Click(object sender, EventArgs e)
		{
            FormOtcheti formOtcheti = new FormOtcheti();
            formOtcheti.Show();
		}

        private void техосмотрыПоОператоамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOtcheti formOtcheti = new FormOtcheti();
            formOtcheti.Tag = 2;
            formOtcheti.Show();
        }

		private void количествоТехосмотровОператоровПоПериодуToolStripMenuItem_Click(object sender, EventArgs e)
		{
            FormOtcheti formOtcheti = new FormOtcheti();
            formOtcheti.Tag = 3;
            formOtcheti.Show();
		}
	}
}