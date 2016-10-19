using System;
using SQLite;

namespace deznet
{
	/// <summary>
	/// SQL Lite service.
	/// </summary>
	public interface ISQLiteService
	{
		/// <summary>
		/// Gets the connection.
		/// </summary>
		/// <returns>The connection.</returns>
		/// <param name="databaseName">Database name.</param>
		SQLiteConnection GetConnection(string databaseName);

		/// <summary>
		/// Gets the size.
		/// </summary>
		/// <returns>The size.</returns>
		/// <param name="databaseName">Database name.</param>
		long GetSize(string databaseName);
	}
}
