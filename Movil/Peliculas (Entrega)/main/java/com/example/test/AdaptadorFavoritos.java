package com.example.test;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class AdaptadorFavoritos extends RecyclerView.Adapter<AdaptadorFavoritos.MyViewHolder> implements View.OnClickListener{
    ArrayList<Pelicula> peliculas;
    RecyclerView rv;

    private View.OnClickListener listener;
    public void setOnClickListener(View.OnClickListener listener){
        this.listener = listener;
    }

    public AdaptadorFavoritos(ArrayList<Pelicula> peliculas, RecyclerView rv){
        this.peliculas = peliculas;
        this.rv = rv;
    }

    @Override
    public void onClick(View v) {
        if(listener != null) listener.onClick(v);
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder{

        private TextView titulo;
        private CheckBox favorito;

        public MyViewHolder(View itemView) {
            super(itemView);
            this.titulo = itemView.findViewById(R.id.tituloPelicula);
            this.favorito = itemView.findViewById(R.id.favoritoPelicula);
        }
    }

    @NonNull
    @Override
    public AdaptadorFavoritos.MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View elemento = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_favoritos, parent, false);
        AdaptadorFavoritos.MyViewHolder mvh = new AdaptadorFavoritos.MyViewHolder(elemento);

        elemento.setOnClickListener(this);
        return mvh;
    }

    @Override
    public void onBindViewHolder(@NonNull AdaptadorFavoritos.MyViewHolder holder, int position) {
        Pelicula pelicula = this.peliculas.get(position);

        holder.titulo.setText(pelicula.getTitulo());
        holder.favorito.setChecked(pelicula.getFavorita());
    }

    @Override
    public int getItemCount() {
        return this.peliculas.size();
    }
}
