package test;

import java.util.ArrayList;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;
import org.xml.sax.helpers.DefaultHandler;

public class SAXC extends DefaultHandler{
    String qName = "";
    String tituloHolder = "";
    ArrayList<String> titulos = new ArrayList<String>();
    int wantedDirectores;
    int counterDirectores = 0;
    
    public SAXC(int n) {
    	this.wantedDirectores = n;
    }
    
    public ArrayList<String> getTitulos(){
    	return titulos;
    }
    
    public void setWantedDirectores(int n) {
    	this.wantedDirectores = n;
    }
    
    @Override
    public void startDocument() throws SAXException{
    	
    }

    @Override
    public void endDocument() throws SAXException{
    	for(String str: titulos)
    		System.out.println(str);
    }

    @Override 
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
    	if(qName.contentEquals("director")) this.counterDirectores++;
    	if(qName.contentEquals("titulo")) this.qName = qName;
    	else this.qName = "";
    }

    @Override 
    public void endElement(String uri, String localName, String qName) throws SAXException{
    	if(qName.contentEquals("pelicula")) {
    		if(counterDirectores >= this.wantedDirectores)
    			titulos.add(tituloHolder);
    		
    		this.counterDirectores = 0;
    		this.tituloHolder = "";
    	}
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException{
        String cad = new String(ch, start, length);
        if(this.qName == "titulo")
        	this.tituloHolder = cad;
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
