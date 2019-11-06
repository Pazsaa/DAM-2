import java.io.FileNotFoundException;

import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.*;

public class Main {
    public static void main(String[] args) throws ClassNotFoundException, InstantiationException,
            IllegalAccessException, FileNotFoundException, ParserConfigurationException {
        Document peliculas = Doom.DomTree("C:\\Users\\apazgarcia\\Desktop\\Main 2\\Acceso a datos\\Tema2\\DOM\\Peliculas.xml");
        // Doom.getTitulos(peliculas);
        // Doom.getTitulosYAutor(peliculas);
        // Doom.getPeliculasWithDirectores(peliculas, 2);
        // Doom.getGeneros(peliculas);
        // Doom.addAttribute(peliculas, "Dune", "test", "true");
        // Doom.remAttribute(peliculas, "Dune", "idioma");
        // Doom.addPelicula(peliculas, "en", "Depredador", "Accion", "1987", "John", "Tieman");
        // Doom.modField(peliculas, "nombre", "Larry", "Lana");
        // Doom.addDirector(peliculas, "Dune", "Alfredo", "Landa");
        // Doom.remPelicula(peliculas, "Dune");
        Doom.newDOM("C:\\Users\\apazgarcia\\Desktop\\Test.xml");
    }
}