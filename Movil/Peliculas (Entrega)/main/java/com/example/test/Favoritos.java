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
import android.view.animation.Animation;
import android.view.animation.BounceInterpolator;
import android.view.animation.ScaleAnimation;
import android.widget.CheckBox;
import android.widget.CompoundButton;

import java.util.ArrayList;

public class Favoritos extends AppCompatActivity {
    ArrayList<Pelicula> peliculas;
    RecyclerView rv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favoritos);

        getSupportActionBar().setTitle("FAVORITOS");

        peliculas = MainActivity.peliculas;

        rv = findViewById(R.id.recycler_layout);

        AdaptadorFavoritos adaptador = new AdaptadorFavoritos(peliculas, rv);

        RecyclerView.LayoutManager layoutManager;
        layoutManager = new LinearLayoutManager(this);

        rv.addItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.VERTICAL));
        rv.setHasFixedSize(true);
        rv.setLayoutManager(layoutManager);
        rv.setAdapter(adaptador);

        View.OnClickListener listener = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CheckBox fav = v.findViewById(R.id.favoritoPelicula);

                // TEST ANIMATION
                final ScaleAnimation scaleAnimation = new ScaleAnimation(0.7f, 1.0f, 0.7f, 1.0f, Animation.RELATIVE_TO_SELF, 0.7f, Animation.RELATIVE_TO_SELF, 0.7f);
                scaleAnimation.setDuration(500);
                BounceInterpolator bounceInterpolator = new BounceInterpolator();
                scaleAnimation.setInterpolator(bounceInterpolator);
                fav.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener(){
                    @Override
                    public void onCheckedChanged(CompoundButton compoundButton, boolean isChecked) {
                        //animation
                        compoundButton.startAnimation(scaleAnimation);
                    }
                });
                //EOF TEST

                fav.setChecked(fav.isChecked() ? false : true);
            }
        };

        adaptador.setOnClickListener(listener);
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        for(int i = 0; i < rv.getChildCount(); i++){
            CheckBox fav = rv.findViewHolderForAdapterPosition(i).itemView.findViewById(R.id.favoritoPelicula);
            peliculas.get(i).favorita = fav.isChecked();
        }
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
