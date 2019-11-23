package com.example.test;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Adapter;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.RadioGroup;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

public class AddPelicula extends AppCompatActivity {
    public static ArrayList<Pelicula> peliculas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_pelicula);

        peliculas = MainActivity.peliculas;

        getSupportActionBar().setTitle("AÑADIR PELI");
        final String[] options = getResources().getStringArray(R.array.options);
        Spinner spinner = findViewById(R.id.spinner);


        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, options);
        spinner.setAdapter(adapter);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){

            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                // Selected
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {
                adapterView.setSelection(0);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_add, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        EditText titulo = findViewById(R.id.tituloText);
        EditText director = findViewById(R.id.directorText);
        EditText duracion = findViewById(R.id.duracionText);
        Spinner sala = findViewById(R.id.spinner);
        RadioGroup pegi = findViewById(R.id.radioGroup);
        DatePicker calendar = findViewById(R.id.calendar);

        switch(item.getItemId()){
            case R.id.saveMenu:
                if(titulo.getText().toString().isEmpty()|| director.getText().toString().isEmpty()
                || duracion.getText().toString().isEmpty())
                    return true;

                int placeHolder = 0;
                switch(pegi.getCheckedRadioButtonId()){
                    case R.id.g:
                        placeHolder = R.drawable.g;
                        break;
                    case R.id.pg:
                        placeHolder = R.drawable.pg;
                        break;
                    case R.id.r:
                        placeHolder = R.drawable.r;
                        break;
                    case R.id.pg13:
                        placeHolder = R.drawable.pg13;
                        break;
                    case R.id.nc17:
                        placeHolder = R.drawable.nc17;
                        break;
                    default:
                        placeHolder = R.drawable.corazon; // testing
                        break;
                }
                Pelicula nueva = new Pelicula(titulo.getText().toString(),
                        director.getText().toString(),
                        Integer.parseInt(duracion.getText().toString()),
                        new Date(calendar.getYear() - 1900, calendar.getMonth(), calendar.getDayOfMonth()),
                        sala.getSelectedItem().toString(),
                        placeHolder,
                        R.drawable.sincara);

                peliculas.add(nueva);
                setResult(RESULT_OK, getIntent());
                finish();
                return true;
            case R.id.discardMenu:
                onBackPressed();
                finish();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }
}
