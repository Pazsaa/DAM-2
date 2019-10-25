import java.io.FileNotFoundException;

import org.w3c.dom.*;

public class Main {
    public static void main(String[] args)
            throws ClassNotFoundException, InstantiationException, IllegalAccessException, FileNotFoundException {
        Document peliculas = Doom.DomTree("C:\\Users\\apazgarcia\\Desktop\\Main\\Acceso a datos\\Tema 2\\Peliculas.xml");
        // Doom.getTitulos(peliculas);
        // Doom.getTitulosYAutor(peliculas);
        // Doom.getPeliculasWithDirectores(peliculas, 2);
        // Doom.getGeneros(peliculas);
        // Doom.addAttribute(peliculas, "Dune", "test", "true");
        Doom.remAttribute(peliculas, "Dune", "idioma");
        Doom.saveDOM(peliculas, "C:\\Users\\apazgarcia\\Desktop\\PeliculasTest.xml");
    }
}