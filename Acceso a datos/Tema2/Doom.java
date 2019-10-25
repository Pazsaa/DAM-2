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

public class Doom {
    // Ejercicio 1
    public static Document DomTree(String path){
        Document doc = null;
        try{
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setIgnoringComments(true);
            DocumentBuilder builder = factory.newDocumentBuilder();
            doc = builder.parse(path);
        }
        catch(Exception e){
            System.out.println("Error generando arbol DOM: " + e.getMessage());
        }

        return doc;
    }

    // Ejercicio 2
    public static void getTitulos(Document doc){
        NodeList titles = doc.getElementsByTagName("titulo");
        for(int i = 0; i < titles.getLength(); i++){
            System.out.println(titles.item(i).getFirstChild().getNodeValue());
        }
    }

    // Ejercicio 3
    public static void getTitulosYAutor(Document doc){
        NodeList titulos = doc.getElementsByTagName("titulo");
        NodeList aux;
        Element padre;

        for(int i = 0; i < titulos.getLength(); i++){
            
            padre = (Element)titulos.item(i).getParentNode();

            aux = padre.getElementsByTagName("titulo");
            if(aux.getLength() > 0)
                System.out.print("Titulo: " + aux.item(0).getFirstChild().getNodeValue());

            aux = padre.getElementsByTagName("genero");
            if(aux.getLength() > 0)
                System.out.print("\tGenero: " + aux.item(0).getFirstChild().getNodeValue());      
        
            aux = padre.getElementsByTagName("director");
            String nombre = "";
            for(int j = 0; j < aux.getLength(); j++){
                nombre += GetNodeVal(aux.item(j), "nombre");
                nombre += " " + GetNodeVal(aux.item(j), "apellido");
                nombre += ", ";
            }

            System.out.print("\tDirector(es): " + nombre);
            System.out.print("\tGenero: " + padre.getAttribute("genero"));
            System.out.println();
        }
    }

    public static String GetNodeVal(Node node, String tag){
        Element e = (Element)node;
        NodeList childs = e.getElementsByTagName(tag);
        if(childs.getLength() > 0)
            return childs.item(0).getFirstChild().getNodeValue();
        else 
            return "Error";
    }

    // Ejercicio 4
    // TODO

    // Ejercicio 5
    public static void getPeliculasWithDirectores(Document doc, int directores){
        NodeList titulos = doc.getElementsByTagName("titulo");
        NodeList aux;

        for(int i = 0; i < titulos.getLength(); i++){
            Element padre = (Element)titulos.item(i).getParentNode();
            aux = padre.getElementsByTagName("director");

            if(aux.getLength() >= directores)
                System.out.println(titulos.item(i).getFirstChild().getNodeValue());
        }
    }

    // Ejercicio 6
    public static void getGeneros(Document doc){
        NodeList peliculas = doc.getElementsByTagName("pelicula");
        ArrayList<String> generos = new ArrayList<String>();

        for(int i = 0; i < peliculas.getLength(); i++){
            Element pel = (Element) peliculas.item(i);
            String genero = pel.getAttribute("genero");

            if(!generos.contains(genero))
                generos.add(genero);
        }
        System.out.println("Hay " + generos.size() + " generos, son: ");
        System.out.println(generos);
    }

    // Ejercicio 7
    public static void addAttribute(Document doc, String titulo, String atributo, String atributoValor){
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element target = null;
        for (int i = 0; i < titulos.getLength(); i++) {
            if(titulos.item(i).getFirstChild().getNodeValue().equals(titulo)){
                target = (Element)titulos.item(i).getParentNode();
            }   
        }

        if(target != null && target.getAttributes().getNamedItem(atributo) == null)
            target.setAttribute(atributo, atributoValor);
    }

    // Ejercicio 7.2
    public static void remAttribute(Document doc, String titulo, String atributo){
        NodeList titulos = doc.getElementsByTagName("titulo");
        Element target = null;

        for(int i = 0; i < titulos.getLength(); i++){
            if(titulos.item(i).getFirstChild().getNodeValue().equals(titulo))
                target = (Element)titulos.item(i).getParentNode();
        }

        if(target != null && target.getAttributes().getNamedItem(atributo) != null)
            target.removeAttribute(atributo);
    }

    // Ejercicio 8
    public static void addPelicula(Document doc, String idioma, String titulo, String genero, String ano, String nombre, String apellido){
        Element pelicula = doc.createElement("pelicula");
        pelicula.setAttribute("idioma", idioma);
        pelicula.setAttribute("titulo", titulo);
        pelicula.setAttribute("genero", genero);
        pelicula.setAttribute("año", ano);

        Element director = doc.createElement("director");
        pelicula.appendChild(director);

        Element nombr = doc.createElement("nombre");
        Element apellid = doc.createElement("apellido");
        director.appendChild(nombr); director.appendChild(apellid);

        doc.getFirstChild().appendChild(pelicula);
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