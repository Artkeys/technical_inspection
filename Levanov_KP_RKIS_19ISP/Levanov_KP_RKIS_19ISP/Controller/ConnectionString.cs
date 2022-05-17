using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Levanov_KP_RKIS_19ISP.Controller
{
	class ConnectionString
	{
		public static string Connstr
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["Levanov_KP_RKIS_19ISP.Properties.Settings.ТехосмотрConnectionString"].ConnectionString;
			}
		}
	}
}
