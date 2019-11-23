package com.example.test;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class PeliculaDesc extends AppCompatActivity {
    Pelicula target = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pelicula_desc);

        Intent intent = getIntent();
        ArrayList<Pelicula> peliculas = MainActivity.peliculas;

        for(Pelicula peli: peliculas){
            if(peli.getTitulo().equals(intent.getStringExtra("TITULO"))){
                target = peli;
            }
        }

        getSupportActionBar().setTitle(target.getTitulo().toUpperCase());

        ImageView caratula = findViewById(R.id.caratulaPelicula);
        TextView  descripcion = findViewById(R.id.descripcionPelicula);

        descripcion.setMovementMethod(new ScrollingMovementMethod());

        caratula.setImageResource(target.getPortada());
        descripcion.setText(target.getSinopsis());

        caratula.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                watchYoutubeVideo(target.getIdYoutube());
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_back, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch(item.getItemId()){
            case R.id.backButton:
                onBackPressed();
                finish();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    public void watchYoutubeVideo(String id){
        Intent appIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("vnd.youtube:" + id));
        Intent webIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://www.youtube.com/watch?v=" + id));
        try {
            startActivity(appIntent);
        } catch (ActivityNotFoundException ex) {
            startActivity(webIntent);
        }
    }
}
