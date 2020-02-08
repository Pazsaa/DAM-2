import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class JDBC {
	private static Connection connection;
	private static Connection secondaryConnection;
	
	public static void Connect(){
		try{
			connection = DriverManager.getConnection("jdbc:sqlite:/C:\\Users\\apazg\\Desktop\\sqlite-tools-win32-x86-3310100/add.db");
			if(connection != null) System.out.println("--- CONNECTED (SQLITE) ---");
			else System.out.println("Unable to connect to db");
		}
		catch(SQLException e) {
			System.out.println("SQLException: " + e.getLocalizedMessage());
            System.out.println("SQLState: " + e.getSQLState());
            System.out.println("Código error: " + e.getErrorCode());
		}
	}
	
	public static void connectToSecondary(String db, String server, String user, String password) {
		try{
			String url = String.format("jdbc:mariadb://%s:3306/%s", server, db);
			
			secondaryConnection = DriverManager.getConnection(url, user, password);
			if(secondaryConnection != null) System.out.println("--- Connected! (MariaDB) ----");
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
            System.out.println(" --- DISCONNECTED (SQLITE) ---");
        } catch (SQLException e) {
            System.out.println("Error closing connection: " + e.getLocalizedMessage());
        }
	}
	
	public static void disconnectFromSecondary() {
		try {
			secondaryConnection.close();
			System.out.println("--- Disconnected (MariaDB) ---- ");
		}
		catch (SQLException e) {
            System.out.println("Error closing connection: " + e.getLocalizedMessage());
        }
	}

	public static void Ejercicio6(int code, String name, int seats) throws SQLException {
		String query = "replace into aulas values (" + code + ",'" + name + "'," + seats + ")"; 
		
		Connect();
		
		Statement statement = connection.createStatement();
		
		int affectedRows = statement.executeUpdate(query);
		System.out.println("Affected " + affectedRows + " row(s)");
		statement.close();
		
		Disconnect();
	}
	
	public static void Ejercicio9() throws SQLException {
		String query = "insert into aulas values (10, 't', 22)";
		
		Connect();
		connectToSecondary("add", "127.0.0.1", "root", "");
		connection.setAutoCommit(false);
		secondaryConnection.setAutoCommit(false);
		
		Statement statement = connection.createStatement();
		Statement secondaryStatement = secondaryConnection.createStatement();
		
		try{
			statement.executeUpdate(query);
			secondaryStatement.executeUpdate(query);
			
			connection.commit();
			secondaryConnection.commit();
		}
		catch(SQLException e) {
			System.out.println(e.getLocalizedMessage());
			System.out.println("Rolling back...");
			
			connection.rollback();
			secondaryConnection.rollback();
		}
		
		Disconnect(); disconnectFromSecondary();
	}
	
	public static void main(String[] args) {
		try {
			System.out.println("Ejercicio 6 (replace into aulas");
			Ejercicio6(5, "Ciencias", 22);
			
			System.out.println("Ejercicio 9 (insert into both db");
			Ejercicio9();
		}
		catch(SQLException e) {
			System.out.println(e.getLocalizedMessage());
		}
	}
}

