package com.example.test;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class ListadoPeliculas extends AppCompatActivity {
    ArrayList<Pelicula> peliculas;
    RecyclerView rv;
    int pos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_listado_peliculas);

        getSupportActionBar().setTitle("LISTA COMPLETA");

        peliculas = MainActivity.peliculas;

        rv = findViewById(R.id.recycler_view);
        AdaptadorPeliculas adaptador = new AdaptadorPeliculas(peliculas, rv);

        RecyclerView.LayoutManager layoutManager;
        layoutManager = new LinearLayoutManager(this);

        rv.addItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.VERTICAL));
        rv.setHasFixedSize(true);
        rv.setLayoutManager(layoutManager);
        rv.setAdapter(adaptador);

        View.OnClickListener listener = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                pos = rv.getChildAdapterPosition(v);
                String titulo = peliculas.get(pos).getTitulo();

                Intent intent = new Intent(ListadoPeliculas.this, PeliculaDesc.class);
                intent.putExtra("TITULO", titulo);
                startActivity(intent);
            }
        };
        adaptador.setOnClickListener(listener);
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
}
