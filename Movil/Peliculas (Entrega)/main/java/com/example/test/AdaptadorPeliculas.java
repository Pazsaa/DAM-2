package com.example.test;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class AdaptadorPeliculas extends RecyclerView.Adapter<AdaptadorPeliculas.MyViewHolder> implements View.OnClickListener{
    ArrayList<Pelicula> peliculas;
    RecyclerView rv;

    private View.OnClickListener listener;
    public void setOnClickListener(View.OnClickListener listener){
        this.listener = listener;
    }

    public AdaptadorPeliculas(ArrayList<Pelicula> peliculas, RecyclerView rv){
        this.peliculas = peliculas;
        this.rv = rv;
    }

    @Override
    public void onClick(View v) {
        if(listener != null) listener.onClick(v);
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder{

        private TextView titulo;
        private TextView director;
        private ImageView pegi;
        private ImageView caratula;
        private TextView  sala;
        private TextView  duracion;
        private TextView  fecha;
        private CheckBox favorito;

        public MyViewHolder(View itemView) {
            super(itemView);
            this.titulo = itemView.findViewById(R.id.tituloPelicula);
            this.director = itemView.findViewById(R.id.directorPelicula);
            this.pegi = itemView.findViewById(R.id.pegiPelicula);
            this.caratula = itemView.findViewById(R.id.caratulaPelicula);
            this.sala = itemView.findViewById(R.id.salaPelicula);
            this.duracion = itemView.findViewById(R.id.duracionPelicula);
            this.fecha = itemView.findViewById(R.id.fechaPelicula);
            this.favorito = itemView.findViewById(R.id.favoritoPelicula);

        }
    }

    @NonNull
    @Override
    public AdaptadorPeliculas.MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View elemento = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_listado_completo, parent, false);
        AdaptadorPeliculas.MyViewHolder mvh = new AdaptadorPeliculas.MyViewHolder(elemento);

        elemento.setOnClickListener(this);
        return mvh;
    }

    @Override
    public void onBindViewHolder(@NonNull AdaptadorPeliculas.MyViewHolder holder, int position) {
        Pelicula pelicula = this.peliculas.get(position);
        SimpleDateFormat simpleFormat = new SimpleDateFormat("dd/MM/yyyy");

        holder.titulo.setText(pelicula.getTitulo());
        holder.director.setText("Director: " + pelicula.getDirector());
        holder.pegi.setImageResource(pelicula.getClasi());
        holder.caratula.setImageResource(pelicula.getPortada());
        holder.duracion.setText("Duracion: " + pelicula.getDuracion() + "min");
        holder.fecha.setText("Fecha: " + simpleFormat.format(pelicula.getFecha()));
        holder.sala.setText("Sala: " +pelicula.getSala());
        holder.favorito.setChecked(pelicula.getFavorita());
    }

    @Override
    public int getItemCount() {
        return this.peliculas.size();
    }
}
