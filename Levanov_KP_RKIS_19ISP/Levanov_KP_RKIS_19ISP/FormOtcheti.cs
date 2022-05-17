using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Levanov_KP_RKIS_19ISP.Controller;

namespace Levanov_KP_RKIS_19ISP
{
	public partial class FormOtcheti : Form
	{
		Query controller;
		public FormOtcheti()
		{
			InitializeComponent();
			controller = new Query(ConnectionString.Connstr);

			{ //Вкладка номер 1
				dataGridView1.DataSource = controller.ThisMonthEnd();
				dataGridView1.Columns[0].Width = 50;
				dataGridView1.Columns[2].Width = 150;
				dataGridView1.Columns[3].Width = 140;
				dataGridView1.Columns[4].Width = 250;
				dataGridView1.Columns[5].Width = 150;
				dataGridView1.Columns[6].Width = 200;

				toolStripStatusLabel1.Text = "  Количество записей = " + (dataGridView1.RowCount - 1).ToString();
			}

			{ //Вкладка номер 2
				dataGridView2.DataSource = controller.TehOsmotriZadannogoOperatora();

                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    OperatorCmbBox.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                }

                object[] items = OperatorCmbBox.Items.OfType<String>().Distinct().ToArray();
                OperatorCmbBox.Items.Clear();
                OperatorCmbBox.Items.AddRange(items);

                dataGridView2.Columns[0].Width = 250;
                dataGridView2.Columns[1].Width = 50;
                dataGridView2.Columns[2].Width = 100;
                dataGridView2.Columns[3].Width = 150;
                dataGridView2.Columns[4].Width = 140;
                dataGridView2.Columns[5].Width = 140;
                dataGridView2.Columns[6].Width = 150;

                toolStripStatusLabel2.Text = "  Количество записей = " + (dataGridView2.RowCount - 1).ToString();
            }

			{
                dataGridView3.DataSource = controller.KolvoTehOsmotrOperatorovZaPeriod();
                dataGridView3.Columns[0].Width = 250;
                dataGridView3.Columns[1].Width = 150;
			}
            
        }

		private void FormOtcheti_Load(object sender, EventArgs e)
		{
            if (Convert.ToInt32(this.Tag) == 2) //Открытие второго отчета
            {
                tabControl1.SelectedIndex = 1;
            }

            if (Convert.ToInt32(this.Tag) == 3) //Открытие третьего отчета
			{
                tabControl1.SelectedIndex = 2;
			}
        }

        private void OperatorCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = controller.TehOsmotriZadannogoOperatora(OperatorCmbBox.Text);
            toolStripStatusLabel2.Text = "  Количество записей = " + (dataGridView2.RowCount - 1).ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.Size = new Size(1131, 595);
            }

            if (tabControl1.SelectedIndex == 1)
            {
                this.Size = new Size(1353, 595);
            }

            if (tabControl1.SelectedIndex == 2)
			{
                this.Size = new Size(734, 595);
			}
        }

        private void AllOperatorBtn_Click(object sender, EventArgs e)
        {
            OperatorCmbBox.Text = null;
            dataGridView2.DataSource = controller.TehOsmotriZadannogoOperatora();
            toolStripStatusLabel2.Text = "  Количество записей = " + (dataGridView2.RowCount - 1).ToString();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = controller.KolvoTehOsmotrOperatorovZaPeriod(dTP1.Value.ToString("MM-dd-yyyy"),dTP2.Value.ToString("MM-dd-yyyy"));
        }
    }
}
