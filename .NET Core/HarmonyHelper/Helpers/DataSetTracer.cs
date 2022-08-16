using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{

	public static class DataSetTracer
	{
		static public void Trace(this DataSet ds, bool traceData = true)
		{
			string xsd = ds.GetXmlSchema();
			//Debug.WriteLine(xsd);

			Debug.WriteLine(string.Format("DataSetName: {0}", ds.DataSetName));

			DataTableCollection tables = ds.Tables;
			Trace(tables, traceData);

		}

		static void Trace(this DataTableCollection tables, bool traceData = true)
		{
			int nTables = tables.Count;
			for (int t = 0 ; t < nTables ; ++t)
			{
				DataTable dt = tables[t];
				Debug.Indent();
				Debug.WriteLine(string.Format("DataTable[{0}]:", t));
				Trace(dt, traceData);
				if (traceData)
					dt.TraceData();
				Debug.Unindent();
			}
		}

		public static void Trace(this DataTable dt, bool traceData = true)
		{
			Debug.Indent();
			Debug.WriteLine(string.Format("TableName: {0}", dt.TableName));

			Trace(dt.Columns, traceData);
			Trace(dt.Rows, traceData);

			Debug.Unindent();
		}

		static void Trace(this DataColumnCollection columns, bool traceData = true)
		{
			Debug.WriteLine("Columns:");
			Debug.Indent();
			Debug.WriteLine(string.Format("Count: {0}", columns.Count));

			Debug.WriteLine("List:");
			Debug.Indent();

			for (int c = 0 ; c < columns.Count ; ++c)
			{
				DataColumn dc = columns[c];
				Debug.WriteLine(string.Format("[{0}]: {1}", c, dc.ColumnName));
			}

			Debug.Unindent();

			Debug.Unindent();
		}

		static void Trace(this DataRowCollection rows, bool traceData = true)
		{
			int count = rows.Count;

			Debug.WriteLine("Rows:");
			if (traceData)
				rows.TraceData();

			Debug.Indent();
			Debug.WriteLine(string.Format("Count: {0}", count));
			Debug.Unindent();
		}


		static void TraceData(this DataSet ds)
		{
			ds.Tables.TraceData();
		}
		static void TraceData(this DataTableCollection tables)
		{
			int nTables = tables.Count;
			for (int t = 0 ; t < nTables ; ++t)
			{
				var table = tables[t];
				table.TraceData();
			}
		}

		static void TraceData(this DataTable dt)
		{
			TraceData(dt.Columns);
			Trace(dt.Rows);
		}

		static void TraceData(this DataColumnCollection columns)
		{
			int count = columns.Count;
			for (int c = 0 ; c < count ; ++c)
			{
				DataColumn dc = columns[c];
				Debug.WriteLine(string.Format("[{0}]: {1}", c, dc.ColumnName));
			}
		}
		static void TraceData(this DataRowCollection rows)
		{
			int count = rows.Count;

			Debug.WriteLine("Rows:");
			Debug.Indent();

			for (int c = 0 ; c < count ; ++c)
			{
				var row = rows[c];
				row.TraceData();
			}


			Debug.WriteLine(string.Format("Count: {0}", count));
			Debug.Unindent();
		}

		static void TraceData(this DataRow row)
		{
			Debug.WriteLine($"{string.Join(", ", row.ItemArray.ToList())}");
		}

	}//class

}//ns