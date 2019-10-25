import org.w3c.dom.*;
import org.w3c.dom.bootstrap.DOMImplementationRegistry;
import org.w3c.dom.ls.DOMImplementationLS;
import org.w3c.dom.ls.LSOutput;
import org.w3c.dom.ls.LSSerializer;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.util.ArrayList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

public class Doom {
    // Ejercicio 1
    public static Document DomTree(String path) {
        Document doc = null;
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setIgnoringComments(true);
            DocumentBuilder builder = factory.newDocumentBuilder();
            doc = builder.parse(path);
        } catch (Exception e) {
            System.out.println("Error generando arbol DOM: " + e.getMessage());
        }

        return doc;
    }

    // Ejercicio 2
    public static void getTitulos(Document doc) {
        NodeList titles = doc.getElementsByTagName("titulo");
        for (int i = 0; i < titles.getLength(); i++) {
            System.out.println(titles.item(i).getFirstChild().getNodeValue());
        }
    }

    // Ejercicio 3
    public static void getTitulosYAutor(Document doc) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        NodeList aux;
        Element padre;

        for (int i = 0; i < titulos.getLength(); i++) {

            padre = (Element) titulos.item(i).getParentNode();

            aux = padre.getElementsByTagName("titulo");
            if (aux.getLength() > 0)
                System.out.print("Titulo: " + aux.item(0).getFirstChild().getNodeValue());

            aux = padre.getElementsByTagName("genero");
            if (aux.getLength() > 0)
                System.out.print("\tGenero: " + aux.item(0).getFirstChild().getNodeValue());

            aux = padre.getElementsByTagName("director");
            String nombre = "";
            for (int j = 0; j < aux.getLength(); j++) {
                nombre += GetNodeVal(aux.item(j), "nombre");
                nombre += " " + GetNodeVal(aux.item(j), "apellido");
                nombre += ", ";
            }

            System.out.print("\tDirector(es): " + nombre);
            System.out.print("\tGenero: " + padre.getAttribute("genero"));
            System.out.println();
        }
    }

    public static String GetNodeVal(Node node, String tag) {
        Element e = (Element) node;
        NodeList childs = e.getElementsByTagName(tag);
        if (childs.getLength() > 0)
            return childs.item(0).getFirstChild().getNodeValue();
        else
            return "Error";
    }

    // Ejercicio 4
    // TODO

    // Ejercicio 5
    public static void getPeliculasWithDirectores(Document doc, int directores) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        NodeList aux;

        for (int i = 0; i < titulos.getLength(); i++) {
            Element padre = (Element) titulos.item(i).getParentNode();
            aux = padre.getElementsByTagName("director");

            if (aux.getLength() >= directores)
                System.out.println(titulos.item(i).getFirstChild().getNodeValue());
        }
    }

    // Ejercicio 6
    public static void getGeneros(Document doc) {
        NodeList peliculas = doc.getElementsByTagName("pelicula");
        ArrayList<String> generos = new ArrayList<String>();

        for (int i = 0; i < peliculas.getLength(); i++) {
            Element pel = (Element) peliculas.item(i);
            String genero = pel.getAttribute("genero");

            if (!generos.contains(genero))
                generos.add(genero);
        }
        System.out.println("Hay " + generos.size() + " generos, son: ");
        System.out.println(generos);
    }

    // Ejercicio 7
    public static void addAttribute(Document doc, String titulo, String atributo, String atributoValor) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element target = null;
        for (int i = 0; i < titulos.getLength(); i++) {
            if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo)) {
                target = (Element) titulos.item(i).getParentNode();
            }
        }

        if (target != null && target.getAttributes().getNamedItem(atributo) == null)
            target.setAttribute(atributo, atributoValor);
    }

    // Ejercicio 7.2
    public static void remAttribute(Document doc, String titulo, String atributo) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element target = null;

        for (int i = 0; i < titulos.getLength(); i++) {
            if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo))
                target = (Element) titulos.item(i).getParentNode();
        }

        if (target != null && target.getAttributes().getNamedItem(atributo) != null)
            target.removeAttribute(atributo);
    }

    // Ejercicio 8
    public static void addPelicula(Document doc, String idioma, String titulo, String genero, String ano, String nombre,
            String apellido) {
        Element pelicula = doc.createElement("pelicula");
        pelicula.setAttribute("idioma", idioma);
        pelicula.setAttribute("genero", genero);
        pelicula.setAttribute("año", ano);

        Element title = doc.createElement("titulo");
        Text titleVal = doc.createTextNode(titulo);
        pelicula.appendChild(title);
        title.appendChild(titleVal);

        Element director = doc.createElement("director");
        pelicula.appendChild(director);

        Element nombr = doc.createElement("nombre");
        Text nombreVal = doc.createTextNode(nombre);
        nombr.appendChild(nombreVal);
        Element apellid = doc.createElement("apellido");
        Text apellidoVal = doc.createTextNode(apellido);
        apellid.appendChild(apellidoVal);

        director.appendChild(nombr);
        director.appendChild(apellid);

        doc.getFirstChild().appendChild(pelicula);
    }

    // Ejercicio 9
    public static void modField(Document doc, String fieldName, String oldVal, String newVal) {
        NodeList nodos = doc.getElementsByTagName("nombre");
        for (int i = 0; i < nodos.getLength(); i++) {
            if (nodos.item(i).getFirstChild().getNodeValue().equals(oldVal))
                nodos.item(i).getFirstChild().setNodeValue(newVal);
        }
    }

    // Ejercicio 10
    public static void addDirector(Document doc, String titulo, String nombre, String apellido) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element pelicula = null;
        for (int i = 0; i < titulos.getLength(); i++) {
            if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo))
                pelicula = (Element) titulos.item(i).getParentNode();
        }

        if (pelicula != null) {
            Element director = doc.createElement("director");
            Element name = doc.createElement("nombre");
            Element surname = doc.createElement("apellido");

            Text nameVal = doc.createTextNode(nombre);
            Text surnameVal = doc.createTextNode(apellido);

            pelicula.appendChild(director);

            director.appendChild(name);
            director.appendChild(surname);

            name.appendChild(nameVal);
            surname.appendChild(surnameVal);
        }
    }

    // Ejercicio 11
    public static void remPelicula(Document doc, String titulo) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element toRemove = null;
        for (int i = 0; i < titulos.getLength(); i++) {
            if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo))
                toRemove = (Element) titulos.item(i).getParentNode();
        }

        if (toRemove != null)
            doc.getFirstChild().removeChild(toRemove);
    }

    // Ejercicio 12
    public static Document newDOM() throws ParserConfigurationException {
        Document doc;
        DocumentBuilderFactory factoria = DocumentBuilderFactory.newInstance();
        factoria.setIgnoringComments(true);        
        DocumentBuilder builder = factoria.newDocumentBuilder();
        doc = builder.newDocument();
         
        Element company = doc.createElement("compañia");
        Element employee = doc.createElement("empleado");
        Element nombre = doc.createElement("nombre");
        Text nombreVal = doc.createTextNode("Juan");
        Element apellidos = doc.createElement("apellidos");
        Text apellidosVal = doc.createTextNode("López Pérez");
        Element apodo = doc.createElement("apodo");
        Text apodoVal = doc.createTextNode("Juanín");
        Element salary = doc.createElement("salario");
        Text salaryVal = doc.createTextNode("1000");

        company.appendChild(employee);
        employee.setAttribute("id", "1");
        employee.appendChild(nombre);
        employee.appendChild(apellidos);
        employee.appendChild(apodo);
        employee.appendChild(salary);

        nombre.appendChild(nombreVal);
        apellidos.appendChild(apellidosVal);
        apodo.appendChild(apodoVal);
        salary.appendChild(salaryVal);
        
        return doc;
    }

    // SAVE DOM
    public static void saveDOM(Document doc, String path) throws ClassNotFoundException, InstantiationException, IllegalAccessException, FileNotFoundException{
        DOMImplementationRegistry registry = DOMImplementationRegistry.newInstance();
        DOMImplementationLS ls = (DOMImplementationLS) registry.getDOMImplementation("XML 3.0 LS 3.0");

        LSOutput output = ls.createLSOutput();
        output.setEncoding("UTF-8");
        output.setByteStream(new FileOutputStream(path));

        LSSerializer serializer = ls.createLSSerializer();

        serializer.setNewLine("\r\n");
        serializer.getDomConfig().setParameter("format-pretty-print", true);

        serializer.write(doc, output);
    }
}