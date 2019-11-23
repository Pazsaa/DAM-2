package com.example.test;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class AdaptadorMain extends RecyclerView.Adapter<AdaptadorMain.MyViewHolder> implements View.OnClickListener{
    ArrayList<Pelicula> peliculas;
    RecyclerView rv;

    private View.OnClickListener listener;
    public void setOnClickListener(View.OnClickListener listener){
        this.listener = listener;
    }

    public AdaptadorMain(ArrayList<Pelicula> peliculas, RecyclerView rv){
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

        public MyViewHolder(View itemView) {
            super(itemView);
            this.titulo = itemView.findViewById(R.id.tituloPelicula);
            this.director = itemView.findViewById(R.id.directorPelicula);
            this.pegi = itemView.findViewById(R.id.pegiPelicula);
            this.caratula = itemView.findViewById(R.id.caratulaPelicula);
        }
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View elemento = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_listado, parent, false);
        MyViewHolder mvh = new MyViewHolder(elemento);

        elemento.setOnClickListener(this);
        return mvh;
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder,int position) {
        Pelicula pelicula = this.peliculas.get(position);
        holder.titulo.setText(pelicula.getTitulo());
        holder.director.setText(pelicula.getDirector());
        holder.pegi.setImageResource(pelicula.getClasi());
        holder.caratula.setImageResource(pelicula.getPortada());
    }

    @Override
    public int getItemCount() {
        return this.peliculas.size();
    }
}
