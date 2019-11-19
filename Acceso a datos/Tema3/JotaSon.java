package JOTA;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.time.Instant;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;

import javax.json.Json;
import javax.json.JsonArray;
import javax.json.JsonObject;
import javax.json.JsonReader;
import javax.json.JsonValue;
import javax.net.ssl.HttpsURLConnection;

public class JotaSon {	
	public static JsonValue getJson(String ruta) {
		JsonReader reader = null;
		JsonValue jsonV = null;
		
		try {
			if(ruta.toLowerCase().startsWith("http://")) {
				URL url = new URL(ruta);
				InputStream is = url.openStream();
				reader = Json.createReader(is);
			}else if(ruta.toLowerCase().startsWith("https://")){
				URL url = new URL(ruta);
				HttpsURLConnection conn = (HttpsURLConnection)url.openConnection();
				InputStream is = conn.getInputStream();
				reader = Json.createReader(is);
			}
			else {
				reader = Json.createReader(new FileReader(ruta));
			}
			
			jsonV = reader.read();
		}catch(IOException e) {
			System.out.println("Error procesando JSON: " + e.getLocalizedMessage());
		}
		
		if(reader != null) reader.close();
		return jsonV;
	}
	
	// 1
	public static JsonObject getCity(String city) {
		return (JsonObject)getJson("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&lang=es&APPID=a975f935caf274ab016f4308ffa23453");
	}
	
	// 2
	public static JsonObject getLongLat(float longi, float lati) {
		return (JsonObject)getJson("http://api.openweathermap.org/data/2.5/weather?lat=" + lati + "&lon=" + longi + "&APPID=a975f935caf274ab016f4308ffa23453");
	}
	
	// 3
	public static JsonObject getlonglatN(float longi, float lati, int n) {
		return (JsonObject)getJson("http://api.openweathermap.org/data/2.5/find?lat=" + lati + "&lon=" + longi + "&cnt=" + n + "&APPID=a975f935caf274ab016f4308ffa23453");
	}
	
	// 4 -> Google API Key
		
	// 5
	public static int getCityId(String city) {
		JsonObject obj = getCity(city);
		return obj.getInt("id");
	}
	
	// 6
	public static String getCityName(float longi, float lati) {
		JsonObject obj = getLongLat(longi, lati);
		return obj.getString("name");
	}
	
	// 7
	public static String getCityLongLat(String city) {
		JsonObject obj = getCity(city);
		JsonObject coords = obj.getJsonObject("coord");
		return "Longitud: " + coords.get("lon") + "\t Latitud: " + coords.getInt("lat"); 
	}
	
	// 8
	public static String unixTimeToString(long unixTime) {
		final DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyy-MM-dd HH:mm:ss");
		return Instant.ofEpochSecond(unixTime).atZone(ZoneId.of("GMT+1")).format(formatter);
	}
	
	public static String getCityStats(String city) {
		JsonObject obj 		= getCity(city);
		int date 			= obj.getInt("dt");
		String formaDate 	= unixTimeToString((long)date);
		
		JsonObject main 	= obj.getJsonObject("main");
		int temp 			= main.getInt("temp");
		int humidity 		= main.getInt("humidity");
		
		JsonObject clouds	= obj.getJsonObject("clouds");
		int cloudy			= clouds.getInt("all");
		
		JsonObject wind 	= obj.getJsonObject("wind");
		int windy			= wind.getInt("speed");
		
		JsonArray weather	= obj.getJsonArray("weather");
		String  weatherp 	= weather.getJsonObject(0).getString("main");
		
		return  "Fecha: " + formaDate + "\nTemperatura: " + temp + "K" +
				"\nHumedad: " + humidity + "%" + "\nPobabilidad de nubes: " + cloudy + "%" +
				"\nVelocidad del viento: " + windy + "m/s" +
				"\nPronostico: " + weatherp;
	}
	
	// 9
	public static void getCitiesStats(float longi, float lati, int n) {
		JsonArray cities = getlonglatN(longi, lati, n).getJsonArray("list");
		
		for(int i = 0; i < cities.size(); i++) {
			JsonObject obj = cities.getJsonObject(i);
			String cityName = obj.getString("name");
			
			System.out.println("\t" + cityName);
			System.out.println(getCityStats(cityName));
			System.out.print("\n");
		}
	}
	
	// 10
	// 11 -> GOOGLE API KEY
	// 12
	
	// 13
	public static void getTriviaQuestions() {
		JsonObject obj = (JsonObject)getJson("https://opentdb.com/api.php?amount=20&category=18&difficulty=hard&type=multiple");
		JsonArray list = obj.getJsonArray("results");
		
		for(int i = 0; i < list.size(); i++) {
			JsonObject question 	= list.getJsonObject(i);
			String questionText		= question.getString("question");
			JsonArray badChoices	= question.getJsonArray("incorrect_answers");
			String correctChoice	= question.getString("correct_answer");
			
			System.out.println(questionText);
			System.out.println("\t" + correctChoice + "*");
			for(int j = 0; j < badChoices.size(); j++) {
				System.out.println("\t" + badChoices.getString(j));
			}
			System.out.print("\n");
		}
	}
}
