using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Levanov_KP_RKIS_19ISP.Controller
{
	class Query
	{
		OleDbConnection connection;
		OleDbCommand command;
		OleDbDataAdapter dataAdapter;
		DataTable bufferTable;
		DataTable bufferTable2;
        DataTable bufferTable3;


		public Query(string Conn)
		{
			connection = new OleDbConnection(Conn);
			bufferTable = new DataTable();
			bufferTable2 = new DataTable();
            bufferTable3 = new DataTable();
		}

		public DataTable ThisMonthEnd()
		{
			connection.Open();
			dataAdapter = new OleDbDataAdapter("SELECT[Диагностическая карта].Id, Автомобиль.Гос_номер, [Диагностическая карта].Дата_проведения, [Диагностическая карта].Срок_действия, [Оператор ТО].Фио, [Диагностическая карта].Сумма_оплаты, [Диагностическая карта].Примечание FROM[Оператор ТО] INNER JOIN(Автомобиль INNER JOIN[Диагностическая карта] ON Автомобиль.Id = [Диагностическая карта].Id_авто) ON[Оператор ТО].Id = [Диагностическая карта].Проверяющий WHERE(((Month([Срок_действия])) = Month(Date())) AND((Year([Срок_действия])) = Year(Date())));",connection);
			bufferTable.Clear();
			dataAdapter.Fill(bufferTable);
			connection.Close();
			return bufferTable;
		}

		public DataTable TehOsmotriZadannogoOperatora()
		{
			connection.Open();
			dataAdapter = new OleDbDataAdapter("SELECT [Оператор ТО].ФИО, [Диагностическая карта].Id, Автомобиль.Гос_номер, [Диагностическая карта].Дата_проведения, [Диагностическая карта].Срок_действия, [Диагностическая карта].Сумма_оплаты, [Диагностическая карта].Примечание FROM Автомобиль INNER JOIN([Оператор ТО] INNER JOIN[Диагностическая карта] ON[Оператор ТО].Id = [Диагностическая карта].Проверяющий) ON Автомобиль.Id = [Диагностическая карта].Id_авто;", connection);
            bufferTable2.Clear();
			dataAdapter.Fill(bufferTable2);
			connection.Close();
			return bufferTable2;
		}

        public DataTable TehOsmotriZadannogoOperatora(string Operator)
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter($"SELECT [Оператор ТО].ФИО, [Диагностическая карта].Id, Автомобиль.Гос_номер, [Диагностическая карта].Дата_проведения, [Диагностическая карта].Срок_действия, [Диагностическая карта].Сумма_оплаты, [Диагностическая карта].Примечание FROM Автомобиль INNER JOIN([Оператор ТО] INNER JOIN[Диагностическая карта] ON[Оператор ТО].Id = [Диагностическая карта].Проверяющий) ON Автомобиль.Id = [Диагностическая карта].Id_авто WHERE((([Оператор ТО].ФИО) = '{Operator}'));", connection);
            bufferTable2.Clear();
            dataAdapter.Fill(bufferTable2);
            connection.Close();
            return bufferTable2;
        }

		public DataTable KolvoTehOsmotrOperatorovZaPeriod()
		{
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT [Оператор ТО].ФИО, Count([Оператор ТО].ФИО) AS [Количество] FROM[Оператор ТО] INNER JOIN[Диагностическая карта] ON[Оператор ТО].[Id] = [Диагностическая карта].[Проверяющий] GROUP BY[Оператор ТО].ФИО;", connection);
            bufferTable3.Clear();
            dataAdapter.Fill(bufferTable3);
            connection.Close();
            return bufferTable3;
		}

        public DataTable KolvoTehOsmotrOperatorovZaPeriod(string dateS,string datePo)
        {
            connection.Open();

			dataAdapter = new OleDbDataAdapter($"SELECT [Оператор ТО].ФИО, Count([Оператор ТО].ФИО) AS [Количество] FROM[Оператор ТО] INNER JOIN[Диагностическая карта] ON[Оператор ТО].[Id] = [Диагностическая карта].[Проверяющий] WHERE((([Диагностическая карта].Дата_проведения) >#{dateS}# And ([Диагностическая карта].Дата_проведения)<#{datePo}#)) GROUP BY[Оператор ТО].ФИО; ", connection);

			bufferTable3.Clear();
            dataAdapter.Fill(bufferTable3);
            connection.Close();
            return bufferTable3;
        }
	}
}