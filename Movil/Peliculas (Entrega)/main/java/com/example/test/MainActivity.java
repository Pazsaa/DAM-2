package com.example.test;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    public static ArrayList<Pelicula> peliculas;
    RecyclerView rv;
    int REQUEST = 1;
    int pos;
    boolean fullscreen = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().setTitle("PELICULAS");

        peliculas = Peliculas.peliculas;

        rv = findViewById(R.id.recycler_view);
        AdaptadorMain adaptadorMain = new AdaptadorMain(peliculas, rv);

        RecyclerView.LayoutManager layoutManager;
        layoutManager = new LinearLayoutManager(this);

        rv.addItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.VERTICAL));
        rv.setHasFixedSize(true);
        rv.setLayoutManager(layoutManager);
        rv.setAdapter(adaptadorMain);

        final TextView tituloActual = findViewById(R.id.tituloActual);
        View.OnClickListener listener = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                pos = rv.getChildAdapterPosition(v);
                tituloActual.setText(peliculas.get(pos).getTitulo());
            }
        };
        adaptadorMain.setOnClickListener(listener);

        final ImageButton fullFran = findViewById(R.id.fullFran);
        fullFran.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                fullscreen = !fullscreen;
                setFullScreen(fullscreen);

                if(fullscreen){
                    fullFran.setImageResource(R.drawable.fullscreen_off);
                }
                else{
                    fullFran.setImageResource(R.drawable.fullscreen_on);
                }
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        if(requestCode == REQUEST && resultCode == RESULT_OK){
            finish();
            startActivity(getIntent());
        }

        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch(item.getItemId()){
            case R.id.films:
                Intent listado = new Intent(MainActivity.this, ListadoPeliculas.class);
                startActivity(listado);
                return true;
            case R.id.favs:
                Intent favoritos = new Intent(MainActivity.this, Favoritos.class);
                startActivity(favoritos);
                return true;
            case R.id.añadir:
                Intent add = new Intent(MainActivity.this, AddPelicula.class);
                startActivityForResult(add, REQUEST);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    public void setFullScreen(boolean fullscreen){
        WindowManager.LayoutParams attrs = getWindow().getAttributes();
        if(fullscreen){
            attrs.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
            getSupportActionBar().hide();
        }else{
            attrs.flags &= ~WindowManager.LayoutParams.FLAG_FULLSCREEN;
            getSupportActionBar().show();
        }
    }
}
