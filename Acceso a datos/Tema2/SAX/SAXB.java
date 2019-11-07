package test;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;
import org.xml.sax.helpers.DefaultHandler;

public class SAXB extends DefaultHandler{
    String qName = "";
    String genero = "";

    @Override
    public void startDocument() throws SAXException{
        System.out.println("Comienzo del documento XML");
    }

    @Override
    public void endDocument() throws SAXException{
        System.out.println("\nFin del documento XML");
    }

    @Override 
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
    	if(qName.contentEquals("titulo")) this.qName = "titulo";
    	if(qName.contentEquals("nombre")) this.qName = "nombre";
    	if(qName.contentEquals("apellido")) this.qName = "apellido";
    	if(qName.contentEquals("pelicula")) {
    		for(int i = 0; i < attributes.getLength(); i++) {
    			if(attributes.getLocalName(i).contentEquals("genero"))
    				this.genero = attributes.getValue(i);
    		}
    	}
    }

    @Override 
    public void endElement(String uri, String localName, String qName) throws SAXException{
    	
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException{
        String cad = new String(ch, start, length);
        
        if(this.qName.contentEquals("titulo"))
        	System.out.printf("Titulo: " + cad + " Género: " + this.genero + " ");
        if(this.qName.contentEquals("nombre"))
        	System.out.printf("Director: " + cad + " ");
        if(this.qName.contentEquals("apellido"))
        	System.out.printf(" " + cad + " \n");
    }

    @Override
    public void warning(SAXParseException e) throws SAXException{
        System.out.println("Aviso: " + e.getMessage());
    }

    @Override
    public void error(SAXParseException e) throws SAXException{
        System.out.println("Error: " + e.getMessage());
    }

    @Override
    public void fatalError(SAXParseException e) throws SAXException{
        System.out.println("Error fatal: " + e.getMessage());
    }
}
