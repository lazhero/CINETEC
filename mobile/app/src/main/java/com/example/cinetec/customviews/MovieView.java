package com.example.cinetec.customviews;

import android.content.Context;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;

import androidx.annotation.Nullable;

import com.example.cinetec.R;
import com.example.cinetec.entities.Movie;
import com.google.android.material.button.MaterialButton;

public class MovieView extends LinearLayout {

    private AspectRatioImageView cover;
    private LinearLayout layout;
    private Movie movie;
    public MovieView(Context context) {
        super(context);
        build(context);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        build(context);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        build(context);
    }

    public MovieView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        build(context);


    }
    private void build(Context context){
        View view=LayoutInflater.from(context).inflate(R.layout.view_movie,this);
        cover=(AspectRatioImageView) findViewById(R.id.cover);
        layout=(LinearLayout) findViewById(R.id.movie_image_layout);
        layout.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                //aqui iria la accion correspondiente :v
            }
        });

    }
    public void setMovie(Movie movie){
        this.movie=movie;

    }
    public void set_cover_size(int width){
        cover.getLayoutParams().width=width;

    }

}
