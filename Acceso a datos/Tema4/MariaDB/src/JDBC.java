import java.sql.Statement;
import java.sql.Connection;
import java.sql.DatabaseMetaData;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;

public class JDBC {
	
	private static Connection connection;
	public static void Connect(String db, String server, String user, String password) {
		try{
			String url = String.format("jdbc:mariadb://%s:3306/%s", server, db);
			
			connection = DriverManager.getConnection(url, user, password);
			if(connection != null) System.out.println("--- Connected! ----");
			else System.out.println("Unable to connect to db!");
		}
		catch(SQLException e){
			 System.out.println("SQLException: " +e.getLocalizedMessage());
			 System.out.println("SQLState: " +e.getSQLState());
			 System.out.println("Código error: " +e.getErrorCode());
		}
	}
	
	public static void Disconnect() {
		try {
			connection.close();
			System.out.println("---- Disconnected! ----");
		} catch (SQLException e) {
			System.out.println("Error trying to close connection: " + e.getLocalizedMessage());
		}
	}
	
	public static void Ejercicio1(String chain) throws SQLException {
		String query = "select * from alumnos where nombre like '%" + chain + "%'";
		int resultCount = 0;
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		ResultSet res = statement.executeQuery(query);
		
		while(res.next()) {
			System.out.println(res.getString("nombre"));
			++ resultCount;
		}
		
		System.out.println("RESULT COUNT: " + resultCount);		
		Disconnect();
	}
	
	public static void Ejercicio2_a(int cod, String name, String sur, int height, int classroom) throws SQLException {
		String query = "insert into alumnos values (" + cod + ",'" + name + "','" + sur + "'," + height + "," + classroom + ")";
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		try {
			statement.executeUpdate(query);
			System.out.println("Row added!");
		} catch (SQLException e) {
			System.out.println(e.getLocalizedMessage());
		}
		
		Disconnect();
	}
	
	public static void Ejercicio2_b(int cod, String name) throws SQLException {
		String query = "insert into asignaturas values (" + cod + ",'" + name + "')";
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		try{
			statement.executeUpdate(query);
			System.out.println("Row added!");
		}catch(SQLException e) {
			System.out.println(e.getLocalizedMessage());
		}
		
		Disconnect();
	}
	
	public static void Ejercicio5_b() throws SQLException {
		String query = "select * from notas where NOTA >= 5";
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		
		ResultSet res = statement.executeQuery(query);
		while(res.next()) {
			int nota = res.getInt("nota");
			String queryAsignatura = "select NOMBRE from asignaturas where COD=" + res.getInt("asignatura");
			String queryAlumno = "select nombre from alumnos where codigo=" + res.getInt("alumno");
			
			ResultSet asignatura = statement.executeQuery(queryAsignatura);
			ResultSet alumno = statement.executeQuery(queryAlumno);
			
			String resAlumno = "";
			String resAsignatura = "";
			
			while(alumno.next()) resAlumno = alumno.getString("nombre");
			while(asignatura.next()) resAsignatura = asignatura.getString("NOMBRE");
			
			System.out.println(resAlumno + " --- " + resAsignatura + " --- " + nota);
		}
		
		Disconnect();
	}

	public static PreparedStatement prepared = null;
	public static void Ejercicio6(String chain, int height) throws SQLException{
		String query = "select * from alumnos where nombre like ? and altura > ?";
		Connect("add", "127.0.0.1", "root", "");
		// Non prepared statement
			/*String queryNonPrepared = "select * from alumnos where nombre like '" + chain +"' and altura > " + height;
			Statement statement = connection.createStatement();
			ResultSet res = statement.executeQuery(queryNonPrepared);*/
		// EOF Non prepared statement
		
		prepared = connection.prepareStatement(query);
		
		prepared.setString(1, "%" + chain +"%");
		prepared.setInt(2, height);
		
		ResultSet res = prepared.executeQuery();
		while(res.next()) System.out.println(res.getString("nombre") + " ---- " + res.getInt("altura"));
		
		Disconnect();
	}
	
	public static void Ejercicio9_d() throws SQLException {
		String query = "show full tables where table_type = 'VIEW'";
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		ResultSet res = statement.executeQuery(query);
		
		while(res.next()) {
			System.out.println("Tab name: " + res.getString("Tables_in_add"));
			System.out.println("Tab type: " + res.getString("Table_type"));
		}
		
		Disconnect();
	}
	
	public static void Ejercicio9_g(String db) throws SQLException {
		Connect("add", "127.0.0.1", "root", "");
		
		DatabaseMetaData metaData = connection.getMetaData();
		ResultSet dbs = metaData.getCatalogs();
		ResultSet cols = metaData.getColumns(db, null, "a%", null);
		ResultSetMetaData meta = cols.getMetaData();
		
		while(cols.next()) {
			for(int i = 1; i <= meta.getColumnCount(); i++) {
				System.out.println("Col pos: " + i);
				System.out.println("Col name: " + meta.getColumnName(i));
				System.out.println("Col allows null: " + meta.isNullable(i));
			}
			
			System.out.println("Tab name: " + cols.getString("TABLE_NAME"));
			System.out.println("Tab type: " + cols.getString("TYPE_NAME"));
			System.out.println("Tab auto increment: " + cols.getString("IS_AUTOINCREMENT"));
		}
		
		while(dbs.next()) System.out.println("DB name: " + dbs.getString(1));
		
		Disconnect();
	}
	
	public static void Ejercicio10() throws SQLException {
		String query = "select *, nombre as non from alumnos";
		
		Connect("add", "127.0.0.1", "root", "");
		Statement statement = connection.createStatement();
		ResultSet res = statement.executeQuery(query);
		ResultSetMetaData meta = res.getMetaData();
		
		for(int i = 1; i <= meta.getColumnCount(); i++) {
			System.out.println("Col name: " + meta.getColumnName(i));
			System.out.println("Col label: " + meta.getColumnLabel(i));
			System.out.println("Col data type: " + meta.getColumnClassName(i));
			System.out.println("Col autoincrement: " + meta.isAutoIncrement(i));
			System.out.println("Col nullable: " + meta.isNullable(i));
		}
		
		Disconnect();
	}
	
	public static void main(String[] args) {
		try{
			System.out.println("Ejercicio 1");
			System.out.println("Alumnos que contienen \"ar\"");
			Ejercicio1("ar");
			
			System.out.println("Ejercicio 2_a (alumnos)");
			Ejercicio2_a(666, "Alberto", "Paz García", 191, 20);
			
			System.out.println("Ejercicio 2_b (asignaturas)");
			Ejercicio2_b(66, "Biología");
			
			System.out.println("Ejercicio 5_b (aprovados)");
			Ejercicio5_b();
			
			System.out.println("Ejercicio 6 (alumnos con patron y altura)");
			Ejercicio6("ar", 150);
			
			System.out.println("Ejercicio 9_d (Views)");
			Ejercicio9_d();
			
			System.out.println("Ejercicio 9_g (DB info)");
			Ejercicio9_g("add");
			
			System.out.println("Ejercicio 10 (query data)");
			Ejercicio10();
		}
		catch(SQLException e) {
			System.out.println(e.getLocalizedMessage());
		}
	}
}
