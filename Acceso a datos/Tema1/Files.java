import java.io.*;
import java.util.Scanner;
import java.util.HashMap;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
public class Files {
	/**
	 *  Ejercicio 1
	 * @param directory
	 * @param flag 0 f / 1 d
	 */
	public void get(File directory, int flag) {
		if(directory.isDirectory()) {
			File[] files = directory.listFiles();
			if(flag == 0) {
				System.out.printf("\nFiles: ");
				for(File f: files) {
					if(f.isFile())
						System.out.printf(f.getName() + " ");
				}
			}
			else {
				System.out.printf("\nDirectories: ");
				for(File f: files) {
					if(f.isDirectory())
						System.out.printf(f.getName() + " ");
				}
			}
		}
		else
			System.out.println("Not a directory.");
	}

	/**
	 * Ejercicio 2
	 * @param dir
	 */
	public void dir(File dir){
		if(dir.isDirectory()){
			File[] files = dir.listFiles();
			for(File f: files){
				System.out.println(f.getAbsolutePath());
				if(!f.isFile())
					
					dir(f);
				}
		}
	}

	/**
	 * Ejercicio 3
	 * @param file
	 * @param c
	 * @return
	 * @throws IOException
	 */
	public int countChar(File file, char c) throws IOException{
		int count = 0;
		try (FileReader fiChin = new FileReader(file)) {
			int i;
			while((i = fiChin.read()) != -1){
				if(i == (int)c) count++;
			}
		} catch (Exception e) {
			return -1;
		}
		return count;
	}

	/**
	 * Ejercicio 4
	 * @param f
	 * @return
	 * @throws FileNotFoundException
	 */
	public ArrayList<Character> maximumOccurrences(File f) throws FileNotFoundException{
		HashMap<Character, Integer> map = new HashMap<>();
		ArrayList<Character> ocurrences = new ArrayList<>();
		String strToRead = "";
		int max = 0;

		try(Scanner sc = new Scanner(f)){
			while(sc.hasNext()){
				strToRead += sc.nextLine();
			}			
		}catch(Exception e){
			System.out.println(e.getMessage());
		}

		for(int i = 0; i < strToRead.length(); i++){
			char c = strToRead.charAt(i);
			if(map.containsKey(c))
				map.put(c, map.get(c) + 1);
			else
				map.put(c, 1);

			if(map.get(c) > max)
				max = map.get(c);
		}

		for(HashMap.Entry<Character, Integer> entry: map.entrySet()){
			if(entry.getValue() == max)
				ocurrences.add(entry.getKey());
		}

		return ocurrences;
	}

	public static void readMaxOccurrences(ArrayList<Character> ocurrences){
		for(char c: ocurrences){
			System.out.println(c);
		}
	}
	
	/**
	 * Ejercicio 5
	 * @param f
	 * @param content
	 */
	public static void findLinesWith(File f, String content){
		int lineIndex = 0;
		String line = "";
		try(Scanner sc = new Scanner(f)){
			while(sc.hasNext()){
				line = sc.nextLine();

				if(line.contains(content)){
					System.out.println(lineIndex + " " + line);
				}
				lineIndex++;
			}
		}
		catch(FileNotFoundException e){
			System.out.println(e.getMessage());
		}
	}

	/**
	 * Ejercicio 6.1
	 * @param f
	 * @param quant ammount of characters to be contained on each resulting file
	 * @param flag true: lines/ false: chars
	 */
	public static void splitFileChars(File f, int quant) throws IOException{
		try(FileReader fr = new FileReader(f)){
			int i;
			char buffer[] = new char[quant];
			int filename = 0;
			while((i = fr.read(buffer)) != -1){
				File file = new File("C:\\Users\\apazgarcia\\Desktop\\EclipseProjects\\" + filename + ".txt");
				file.createNewFile();
				try(FileWriter fw = new FileWriter(file)){
					fw.write(buffer);
				}

				filename++;
			}
		}
		catch(Exception ex){
			System.out.println(ex.getMessage());
		}
	}
	/**
	 * Ejericio 6.2
	 * @param f
	 * @param quant amount of lines to be contained by resulting files.
	 * @throws IOException
	 */
	public static void splitFileLines(File f, int quant) throws IOException{
		int filename = 0;
		try(Scanner sc = new Scanner(f)){
			while(sc.hasNext()){
				File file = new File("C:\\Users\\apazgarcia\\Desktop\\EclipseProjects\\" + filename + ".txt");
				for(int i = 0; i < quant && sc.hasNext(); i++){
					try(PrintWriter pw = new PrintWriter(new FileWriter(file, true))){
						pw.write(sc.nextLine() + "\n");
					}
				}
				filename++;
			}
		}
	}

	/**
	 * Ejercicio 6.3
	 * @param files
	 */
	public static void joinFiles(File[] files){
		File combined = new File("C:\\Users\\apazgarcia\\Desktop\\EclipseProjects\\combined.txt");

		for(File file: files){
			try(Scanner sc = new Scanner(file)){
				while(sc.hasNext()){
					try(PrintWriter pw = new PrintWriter(new FileWriter(combined, true))){
						pw.write(sc.nextLine());
						pw.flush();
					}catch(IOException e){
						System.out.println(e.getMessage());
					}
				}
			}
			catch(FileNotFoundException e){
				System.out.println(e.getMessage());
			}
		}
	}
	
	/**
	 * Ejercicio 7
	 * @param file
	 * @param operacion
	 */
	public void fileControll(File file, char operacion){
		ArrayList<String> lines = getLines(file);
		File f = new File("C:\\Users\\apazgarcia\\Desktop\\test.txt");

		switch(operacion){
			case 'n':
				// Count lines n words
				int words = 0;
				try(Scanner sc = new Scanner(file)){
					while(sc.hasNext()){
						sc.next();
						words++;
					}
				}catch(FileNotFoundException e){
					System.out.println(e.getMessage());
				}

				System.out.println("Numero de lineas: " + getLines(file).size());
				System.out.println("Numero de palabras: " + words);
				break;
			case 'A':
				// Fichero nuevo ordenando lineas ascendente (sensible)
				Collections.sort(lines);
				writeLines(lines, f);
				break;
			case 'D':
				// ^ descendente (sensible)
				Collections.sort(lines, Collections.reverseOrder());
				writeLines(lines, f);
				break;
			case 'a':
				// ^ ascendente
				Collections.sort(lines, new Comparator<String>() {
					@Override
					public int compare(String s1, String s2) {
						return s1.compareToIgnoreCase(s2);
					}
				});
				writeLines(lines, f);
				break;
			case 'd':
				// ^ descendente
				Collections.sort(lines, Collections.reverseOrder(new Comparator<String>() {
					@Override
					public int compare(String s1, String s2) {
						return s1.compareToIgnoreCase(s2);
					}
				}));
				writeLines(lines, f);
				break;
			default:
				break;
		}
	}

	public ArrayList<String> getLines(File file){
		ArrayList<String> lines = new ArrayList<String>();
		try(Scanner sc = new Scanner(file)){
			while(sc.hasNextLine()){
				lines.add(sc.nextLine());
			}
		}catch(FileNotFoundException e){
			System.out.println(e.getMessage());
		}
		return lines;
	}

	public void writeLines(ArrayList<String> lines, File f){
		try(PrintWriter pw = new PrintWriter(new FileWriter(f))){
			for(String str: lines)
				pw.write(str);
		}catch(IOException ex){
			System.out.println(ex.getMessage());
		}
	}

	/**
	 * Ejercicio 8
	 */
	public void copyBinary(File in, File out){
		try(FileInputStream fi = new FileInputStream(in); FileOutputStream fo = new FileOutputStream(out)){
			int c;
			while((c = fi.read()) != -1){
				fo.write(c);
			}
		}catch(Exception e){
			System.out.println(e.getMessage());
		}
	}

	public void copyBinaryBuffer(File in, File out){
		try(FileInputStream fi = new FileInputStream(in); FileOutputStream fo = new FileOutputStream(out)){
			byte[] buffer = new byte[1000];
			int c;
			while((c = fi.read(buffer)) != -1){
				fo.write(buffer, 0, c);
			}
		}
		catch(Exception e){
			System.out.println(e.getMessage());
		}
	}

	/**
	 * Ejercicio 9
	 */
	// Inserta unico alumno en fichero
	public void altaAlumno(File f, String nombre, int fechaNac, int codigo){
		Alumno alumno = new Alumno(nombre, fechaNac, codigo);

		try(DataOutputStream dout = new DataOutputStream(new FileOutputStream(f, true))){
			dout.writeUTF(alumno.nombre);
			dout.writeInt(alumno.fechaNac);
			dout.writeInt(alumno.codigo);
		}
		catch(Exception e){
			System.out.println(e.getMessage());
		}
	}

	// Obtiene todos los alumnos del fichero en un arraylist
	public ArrayList<Alumno> getAlumnos(File f){
		ArrayList<Alumno> alumnos = new ArrayList<Alumno>();
		try(DataInputStream din = new DataInputStream(new FileInputStream(f))){
			while(true){
				alumnos.add(new Alumno(din.readUTF(), din.readInt(), din.readInt()));
			}
		}catch(IOException e){
			System.out.println(e.getLocalizedMessage());
			return alumnos;
		}
	}

	// SOBREESCRIBE el fichero con todos los alumnos del arraylist
	public void writeAlumnos(File f, ArrayList<Alumno> a){
		try(DataOutputStream dout = new DataOutputStream(new FileOutputStream(f, false))){
			for(Alumno alumno : a){
				dout.writeUTF(alumno.nombre);
				dout.writeInt(alumno.fechaNac);
				dout.writeInt(alumno.codigo);
			}
		}
		catch(Exception e){
			System.out.println(e.getMessage());
		}
	}

	// Modifica un alumno (en base a su codigo) en el arraylist, después sobreescribe todo el archivo.
	public void modAlumno(File f, ArrayList<Alumno> a, int codigo, String nNombre, int nFecha, int nCodigo){
		boolean found = false;
		for(Alumno al : a ){
			if(codigo == al.codigo){
				al.nombre = nNombre;
				al.fechaNac = nFecha;
				al.codigo = nCodigo;
				found = !found;
			}
		}

		if(found)
		// Write whole arraylist to file
		// Could be done on exit (save changes?);
			writeAlumnos(f, a);
		else
			System.out.println("Alumno no encontrado");
	}
}
