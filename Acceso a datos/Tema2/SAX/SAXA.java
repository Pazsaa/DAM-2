package test;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;
import org.xml.sax.helpers.DefaultHandler;

public class SAXA extends DefaultHandler{
    String qName = "";

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
        if(qName.contentEquals("filmoteca"))
        	System.out.printf("<" + qName + ">");
    	if(qName.contentEquals("pelicula"))
        	System.out.printf("\n <" + qName + ">");
        if(qName.contentEquals("titulo") || qName.contentEquals("director"))
        	System.out.printf("\n  <" + qName + ">");
        if(qName.contentEquals("nombre") || qName.contentEquals("apellido"))
        	System.out.printf("\n   <" + qName + ">");
    }

    @Override 
    public void endElement(String uri, String localName, String qName) throws SAXException{
    	if(qName.contentEquals("filmoteca"))
    		System.out.printf("\n </" + qName + ">");
    	if(qName.contentEquals("pelicula"))
        	System.out.printf("\n </" + qName + ">");
    	if(qName.contentEquals("director"))
        	System.out.printf("\n  </" + qName + ">");
    	if(qName.contentEquals("nombre") || qName.contentEquals("apellido") || qName.contentEquals("titulo"))
    		System.out.printf("</" + qName + ">");
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException{
        String cad = new String(ch, start, length);
        System.out.printf(cad);
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